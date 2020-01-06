class RecipeCard extends React.Component {
    render() {
        return (
            <div>
                <div className="col-md-4">
                    <h2>Recepten</h2>
                    <img src="../Content/Images/Cookbook.jpg" alt="Cookbook" />
                    <p>Bekijk hier alle recepten</p>
                    <p><a className="btn btn-default" href="/Recipe">Recepten</a></p>
                </div>
            </div>
        );
    }
}

ReactDOM.render(<RecipeCard />, document.getElementById('recipecard'));