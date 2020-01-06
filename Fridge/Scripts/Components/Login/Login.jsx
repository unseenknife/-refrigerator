class Login extends React.Component {
    render() {
        return (
            <div>
                <h2>Inloggen</h2>
                <div id="loginform"></div>
            </div>
        );
    }
}

ReactDOM.render(<Login />, document.getElementById('login'));