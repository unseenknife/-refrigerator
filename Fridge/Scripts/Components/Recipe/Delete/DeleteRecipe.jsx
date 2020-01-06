class DeleteRecipe extends React.Component {
    render() {
        return (
            <div>
                <h2>Verwijder recept</h2>
                <div id="deleterecipeinfo"></div>
            </div>
        );
    }
}

ReactDOM.render(<DeleteRecipe />, document.getElementById('deleterecipe'));