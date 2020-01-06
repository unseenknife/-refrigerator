class DetailRecipeInfo extends React.Component {
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
                body: window.location.pathname.split("/recipe/details/").pop()
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
                <a href={"../edit/" + this.state.recipe.id}>Edit recipe</a> <a href={"../delete/" + this.state.recipe.id}>Delete recipe</a>
                <hr />
                <p><a className="btn btn-default" href={"../prepare/" + this.state.recipe.id}>Klaarmaken</a></p >
                
            </div>
        );
    }
}

ReactDOM.render(<DetailRecipeInfo />, document.getElementById('detailrecipeinfo'));