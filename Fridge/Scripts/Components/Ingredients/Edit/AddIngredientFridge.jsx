class AddIngredientFridge extends React.Component {
    render() {
        return (
            <div>
                <h2>Voeg ingredient toe aan je koelkast</h2>
                <h5>Staat het er niet tussen?</h5>
                <a className="btn btn-default" href="create">Ingredienten toevoegen aan winkel</a>
                 
                <div id="ingredientform"></div>
            </div>
        );
    }
}

ReactDOM.render(<AddIngredientFridge />, document.getElementById('addingredientfridge'));