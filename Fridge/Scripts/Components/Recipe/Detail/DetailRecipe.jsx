class DetailRecipe extends React.Component {
    render() {
        return (
            <div>
                <h2>Details</h2>
                <div id="detailrecipeinfo"></div>
            </div>
        );
    }
}

ReactDOM.render(<DetailRecipe />, document.getElementById('detailrecipe'));