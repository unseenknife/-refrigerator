class WalletCard extends React.Component {

    state = {
        wallet: ""
    }

    componentDidMount() {
        fetch('home/GetWallet')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ wallet: data.toFixed(2) });
            });
    }

    render() {
        return (
            <div>
                <div className="col-md-4">
                    <h2>Portemonnee</h2>
                    <img src="../Content/Images/Wallet.png" alt="Wallet" />
                    <h3>Bedrag: €{this.state.wallet}</h3>
                </div>
            </div>
        );
    }
}

ReactDOM.render(<WalletCard />, document.getElementById('walletcard'));