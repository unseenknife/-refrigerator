class Home extends React.Component {
    render() {
        return (
            <div>
                <div id="banner"></div>
                <div className="row">
                    <div id="recipecard"></div>
                    <div id="ingredientcard"></div>
                    <div id="walletcard"></div>
                </div>
            </div>
        );
    }
}

ReactDOM.render(<Home />, document.getElementById('home'));