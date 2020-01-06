class CreateRecipe extends React.Component {
    render() {
        return (
            <div>
                <h2>Voeg recept toe</h2>
                <div id="createrecipeform"></div>
            </div>
        );
    }
}

ReactDOM.render(<CreateRecipe />, document.getElementById('createrecipe'));