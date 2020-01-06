class IngredientCard extends React.Component {

    state = {
        image: ""
    }

    componentDidMount() {
        fetch('ingredient/PersonalIngredientHomeList')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ image: data });
            });
    }

    render() {
        return (
            <div>
                <div className="col-md-4">
                    <h2>Mijn koelkast</h2>
                    <img src={this.state.image} alt="Fridge" />
                    <p>Bekijk hier alle ingrediënten die je in je koelkast hebt</p>
                    <p><a className="btn btn-default" href="/Ingredient">Koelkast</a></p>
                </div>
            </div>
        );
    }
}

ReactDOM.render(<IngredientCard />, document.getElementById('ingredientcard'));