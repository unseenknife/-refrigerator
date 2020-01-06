class Ingredients extends React.Component {
    render() {
        return (
            <div>
                <h2>Mijn koelkast</h2>
                <div id="personalingredientlist"></div>
                <a className="btn btn-default" href="ingredient/edit">Ingredienten toevoegen aan koelkast</a>
            </div>
        );
    }
}

ReactDOM.render(<Ingredients />, document.getElementById('ingredients'));