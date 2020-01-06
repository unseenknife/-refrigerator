class Banner extends React.Component {
    render() {
        return (
            <div>
                <div className="jumbotron"></div>
            </div>
        );
    }
}

ReactDOM.render(<Banner />, document.getElementById('banner'));