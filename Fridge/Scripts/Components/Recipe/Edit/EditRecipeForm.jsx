class EditRecipeForm extends React.Component {
    state = {
        recipe: []
    }

    onChange = (e) => {
        this.setState({
            recipe: {
                [e.target.name]: [e.target.value],
                id: this.state.recipe.id,
                userId: this.state.recipe.userId
            }
        });
    }

    componentDidMount() {
        fetch('../../api/ApiRecipe/GetDetail',
            {
                headers: {
                    'Accept': 'application/json, text/plain',
                    'Content-Type': 'application/json'
                },
                method: "POST",
                body: window.location.pathname.split("/recipe/edit/").pop()
            })
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ recipe: data });
            });
    }

    render() {
        return (
            <div className="form-horizontal">
                <hr />
                <form action="/Recipe/Edit" className="form-horizontal" method="post" role="form">
                    <div className="form-group">
                        <div className="col-md-10">
                            <input className="form-control" id="id" name="id" type="hidden" value={this.state.recipe.id} />
                        </div>
                    </div>
                    <div className="form-group">
                        <div className="col-md-10">
                            <input className="form-control" id="userId" name="userId" type="hidden" value={this.state.recipe.userId} />
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="name">Naam</label>
                        <div className="col-md-10">
                            <input className="form-control text-box single-line" id="name" name="name" type="text" onChange={this.onChange} value={this.state.recipe.name} required />
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="prepareTime">Bereidingsduur</label>
                        <div className="col-md-10">
                            <input className="form-control text-box single-line" id="prepareTime" name="prepareTime" type="number" onChange={this.onChange} value={this.state.recipe.prepareTime} required />
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="servings">Porties</label>
                        <div className="col-md-10">
                            <input className="form-control text-box single-line" id="servings" name="servings" type="number" onChange={this.onChange} value={this.state.recipe.servings} required />
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="description">Beschrijving</label>
                        <div className="col-md-10">
                            <input className="form-control text-box single-line" id="description" name="description" type="text" onChange={this.onChange} value={this.state.recipe.description} />
                        </div>
                    </div>
                    <div className="form-group">
                        <div className="col-md-offset-2 col-md-10">
                            <input type="submit" defaultValue="Add" className="btn btn-default" />
                        </div>
                    </div>
                </form>
            </div>

        );
    }
}

ReactDOM.render(<EditRecipeForm />, document.getElementById('editrecipeform'));