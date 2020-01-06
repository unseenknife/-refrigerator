class RecipeList extends React.Component {
    state = {
        Id: "",
        Name: "",
        Servings: "",
        Table: []
    }

    componentDidMount() {
        fetch('../api/ApiRecipe')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ Table: data });
            });
    }

    render() {
        return (
            <div>
                <hr />
                <table className="table" id="Table" name="Table">
                    <thead>
                        <tr>
                            <th scope="col">Recepten</th>
                            <th scope="col">Porties</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.Table.map(function (recipe, index) {
                                return [<tr key={index}><td><a href={"recipe/details/" + recipe.id}>{recipe.name}</a></td><td>{recipe.servings}</td></tr>];
                            })
                        }
                    </tbody>
                </table>
            </div>

        );
    }
}

ReactDOM.render(<RecipeList />, document.getElementById('recipelist'));