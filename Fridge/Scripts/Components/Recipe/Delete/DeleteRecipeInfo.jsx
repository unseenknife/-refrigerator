class DeleteRecipeInfo extends React.Component {
    state = {
        recipe: []
    }

    componentDidMount() {
        fetch('../../api/ApiRecipe/GetDetail',
            {
                headers: {
                    'Accept': 'application/json, text/plain',
                    'Content-Type': 'application/json'
                },
                method: "POST",
                body: window.location.pathname.split("/recipe/delete/").pop()
            })
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ recipe: data });
            });
    }

    render() {
        return (
            <div>
                <hr />
                <p>Naam: {this.state.recipe.name}</p>
                <p>Bereidingstijd: {this.state.recipe.prepareTime} minuten</p>
                <p>Porties: {this.state.recipe.servings}</p>
                <p>Beschrijving: {this.state.recipe.description}</p>
                <form action="/Recipe/delete" method="post" role="form">
                    <input className="form-control" id="id" name="id" type="hidden" value={this.state.recipe.id} />
                    <input type="submit" value="Delete" class="btn btn-default" />
                </form>
            </div>
        );
    }
}

ReactDOM.render(<DeleteRecipeInfo />, document.getElementById('deleterecipeinfo'));