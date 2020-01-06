class IngredientForm extends React.Component {

    state = {
        name: "1",
        Quantity: "1",
        dropdown: [],
        info: ""
    }

    onChange = (e) => {
        this.setState({
            [e.target.name]: [e.target.value][0]
        });
        this.sleep(200).then(() => {
            this.updateInfo();
        });
    }

    sleep(time) {
        return new Promise((resolve) => setTimeout(resolve, time));
    }

    updateInfo(){
        fetch('../api/ApiIngredient/' + this.state.name)
        .then(response => response.json())
            .then(data => {
            this.setState({ info: data });
        });
    }

    componentDidMount() {
        fetch('../api/ApiIngredient')
            .then(response => response.json())
            .then(data => {
                this.setState({ dropdown:data});
            });

        fetch('../api/ApiIngredient/' + this.state.name)
            .then(response => response.json())
            .then(data => {
                this.setState({ info:data});
            });

    }

    render() {
        return (
            <div className="form-horizontal">
                <hr />
                <form action="/Ingredient/Edit" className="form-horizontal" method="post" role="form">
                <div className="form-group">
                    <label className="control-label col-md-1" htmlFor="Name">Name</label>
                    <select className="form-control" id="name" name="name" onChange={this.onChange}>
                        {
                            this.state.dropdown.map(function (ingredient, index) {
                                return <option key={index} value={ingredient.id}> {ingredient.name} </option>;
                            })
                        }
                    </select>
                </div>
                <div className="form-group">
                    <label className="control-label col-md-1" htmlFor="Quantity">Aantal</label>
                    <input className="form-control" id="Quantity" name="Quantity" type="number" onChange={this.onChange} />
                </div>
                <div className="form-group">
                    <div className="col-md-offset-1">
                        <input type="submit" defaultValue="Add" className="btn btn-default" />
                    </div>
                </div>
                </form>
                <hr />
                <div className="col-md-offset-1">
                    <h3>Product informatie</h3>
                    <p>Naam: {this.state.info.name}</p>
                    <p>Prijs: €{(this.state.info.price * 1).toFixed(2)}</p>
                    <p>Totaal prijs: €{(this.state.info.price * this.state.Quantity).toFixed(2)}</p>
                    <p>Beschrijving: {this.state.info.description}</p>
                    <p>Hoeveelheid: {this.state.info.quantity} {this.state.info.unit} </p>
                </div>
            </div>

        );
    }
}

ReactDOM.render(<IngredientForm />, document.getElementById('ingredientform'));