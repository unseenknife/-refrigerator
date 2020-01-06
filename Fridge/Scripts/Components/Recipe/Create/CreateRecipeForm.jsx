class CreateRecipeForm extends React.Component {
    state = {
        name: "",
        prepareTime: "",
        servings: "",
        description: ""
    }

    onChange = (e) => {
        this.setState({
            [e.target.name]: [e.target.value]
        });
    }

    render() {
        return (
            <div className="form-horizontal">
                <hr />
                <form action="/Recipe/Create" className="form-horizontal" method="post" role="form">
                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="name">Naam</label>
                        <div className="col-md-10">
                            <input className="form-control text-box single-line" id="name" name="name" type="text" onChange={this.onChange} required />
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="prepareTime">Bereidingsduur</label>
                        <div className="col-md-10">
                            <input className="form-control text-box single-line" id="prepareTime" name="prepareTime" type="number" onChange={this.onChange} required />
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="servings">Porties</label>
                        <div className="col-md-10">
                            <input className="form-control text-box single-line" id="servings" name="servings" type="number" onChange={this.onChange} required />
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="description">Beschrijving</label>
                        <div className="col-md-10">
                            <input className="form-control text-box single-line" id="description" name="description" type="text" onChange={this.onChange} />
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

ReactDOM.render(<CreateRecipeForm />, document.getElementById('createrecipeform'));