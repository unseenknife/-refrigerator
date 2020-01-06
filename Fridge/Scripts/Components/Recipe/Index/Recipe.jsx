class Recipe extends React.Component {
    render() {
        return (
            <div>
                <h2>Recepten</h2>
                <div id="recipelist"></div>
                <a className="btn btn-default" href="recipe/create">Recept toevoegen</a>
            </div>
        );
    }
}

ReactDOM.render(<Recipe />, document.getElementById('recipe'));