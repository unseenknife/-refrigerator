class Register extends React.Component {

    render() {
        return (
            <div>
                <h2>Registreren</h2>
                <div id="registerform"></div>
            </div>
        );
    }
}

ReactDOM.render(<Register />, document.getElementById('register'));