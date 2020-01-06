class LoginForm extends React.Component {

    state = {
        Email: "",
        Password: ""
    }

    onChange = (e) => {
        this.setState({
            [e.target.name]: [e.target.value]
        });
    }

    render() {
        return (
            <div>
                <form action="/Account/Login" className="form-horizontal" method="post" role="form">
                    <hr />
                    <div className="form-group">
                        <label className="col-md-1 control-label" htmlFor="Email">Email</label>
                        <input className="form-control" data-val="true" data-val-email="Het veld Email is geen geldig e-mailadres." data-val-required="Het veld Email is vereist." id="Email" name="Email" type="text" value={this.state.Email} onChange={this.onChange} />
                        <span className="text-danger" data-valmsg-for="Email" data-valmsg-replace="true"></span>
                    </div>
                    <div className="form-group">
                        <label className="col-md-1 control-label" htmlFor="Password">Password</label>
                        <input className="form-control" data-val="true" data-val-required="Het veld Password is vereist." id="Password" name="Password" type="password" value={this.state.Password} onChange={this.onChange} />
                        <span className="text-danger" data-valmsg-for="Password" data-valmsg-replace="true"></span>
                    </div>
                    <div className="form-group">
                        <div className="col-md-offset-1">
                            <input type="submit" value="Inloggen" className="btn btn-default" />
                        </div>
                    </div>
                    <div className="col-md-offset-1">
                        <p>
                            <a href="/Account/Register">Registreren als nieuwe gebruiker.</a>
                        </p>
                    </div>
                </form>
            </div>
        );
    }
}

ReactDOM.render(<LoginForm />, document.getElementById('loginform'));