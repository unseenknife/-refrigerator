using System;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Fridge.Controllers;

namespace Fridge
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            RegisterCacheEntry();
        }

        private const string DummyCacheItemKey = "GagaGuguGigi";

        /// <summary>
        /// Register an item into the cache for a week
        /// </summary>
        /// <returns></returns>
        private bool RegisterCacheEntry()
        {
            if (null != HttpContext.Current.Cache[DummyCacheItemKey]) return false;

            HttpContext.Current.Cache.Add(DummyCacheItemKey, "Test", null,
                DateTime.MaxValue, TimeSpan.FromDays(7),
                CacheItemPriority.Normal,
                new CacheItemRemovedCallback(CacheItemRemovedCallback));

            return true;
        }

        /// <summary>
        /// When an item is removed from the cache instruct the application to execute another function
        /// </summary>
        public void CacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            HitPage();
            // Do the service works
            WalletController wallet = new WalletController();
            wallet.AllowanceIncrease();
        }

        private const string DummyPageUrl =
            "http://localhost:47432/Cache/Index";

        /// <summary>
        /// Check whether the dummy page is reached the cache
        /// </summary>
        private void HitPage()
        {
            WebClient client = new WebClient();
            client.DownloadData(DummyPageUrl);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            // If the dummy page is hit, then it means we want to add another item

            // in cache

            if (HttpContext.Current.Request.Url.ToString() == DummyPageUrl)
            {
                // Add the item in cache and when successful, do the work.

                RegisterCacheEntry();
            }
        }
    }
}