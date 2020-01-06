class PersonalIngredientList extends React.Component {

    state = {
        Name: "",
        Quantity: "",
        Unit: "",
        Table: []
    }

    componentDidMount() {
        fetch('ingredient/PersonalIngredientList')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ Table:data });
            });
    }

    render() {
        return (
            <div>
                <hr />
                <table className="table" id="Table" name="Table">
                    <thead>
                        <tr>
                            <th scope="col">Ingredient</th>
                            <th scope="col">Aantal</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.Table.map(function (ingredient) {
                                return [<tr><td>{ingredient.Name}</td><td>{ingredient.Quantity} {ingredient.Unit}</td></tr>];
                            })
                        }
                    </tbody>
                </table>
            </div>

        );
    }
}

ReactDOM.render(<PersonalIngredientList />, document.getElementById('personalingredientlist'));