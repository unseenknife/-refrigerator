class AddIngredientFridge extends React.Component {
    render() {
        return (
            <div>
                <h2>Voeg ingredient toe aan de winkel</h2>
                <div id="ingredientform"></div>
            </div>
        );
    }
}

ReactDOM.render(<AddIngredientFridge />, document.getElementById('createingredientfridge'));