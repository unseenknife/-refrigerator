class EditRecipe extends React.Component {
    render() {
        return (
            <div>
                <h2>Bewerk recept</h2>
                <div id="editrecipeform"></div>
            </div>
        );
    }
}

ReactDOM.render(<EditRecipe />, document.getElementById('editrecipe'));