class IngredientForm extends React.Component {

    state = {
        name: "",
        price: "",
        quantity: "",
        description: "",
        unit: "gram",
        categoryId: "1"
    }

    onChange = (e) => {
        this.setState({
            [e.target.name]: [e.target.value][0]
        });
    }
    
    render() {
        return (
            <div className="form-horizontal">
                <hr />
                <form action="/Ingredient/Create" className="form-horizontal" method="post" role="form">
                
                <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="name">Naam</label>
                    <div className="col-md-10">
                            <input className="form-control text-box single-line" id="name" name="name" type="text" onChange={this.onChange} />
                    </div>
                    </div>

                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="description">Beschrijving</label>
                        <div className="col-md-10">
                            <textarea className="form-control text-box single-line" id="description" name="description"  onChange={this.onChange}>
                                </textarea>
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="categoryId">Category</label>
                    <div className="col-md-10">
                            <select className="form-control single-line" id="categoryId" name="categoryId" onChange={this.onChange}>
                            
                                <option value="1"> Pasta's </option>
                                <option value="2"> Groenten</option>
                                <option value="3"> Fruit</option>
                                <option value="4"> Overig</option>
                                <option value="5"> Vis</option>
                                <option value="6"> Vlees</option>
                                    
                        </select>
                    </div>
                    </div>

                <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="price">Prijs</label>
                    <div className="col-md-10">
                            <input className="form-control" id="price" name="price" type="number" step="any" onChange={this.onChange} />
                    </div>
                </div>
                <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="quantity">Aantal</label>
                    <div className="col-md-10">
                            <input className="form-control" id="quantity" name="quantity" type="number" onChange={this.onChange} />
                    </div>
                </div>
                <div className="form-group">
                        <label className="control-label col-md-2" htmlFor="unit">Eenheid</label>
                    <div className="col-md-10">
                            <select className="form-control" id="unit" name="unit" onChange={this.onChange}>

                            <option value="gram"> gram </option>
                            <option value="kg"> kg</option>
                            <option value="stuks"> stuks</option>
                            <option value="ml"> ml</option>

                        </select>
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

ReactDOM.render(<IngredientForm />, document.getElementById('ingredientform'));