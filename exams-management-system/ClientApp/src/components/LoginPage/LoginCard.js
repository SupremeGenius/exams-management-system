import React from "react";
import Card from "@material-ui/core/Card";
import "../../styles/LoginPage/LoginCardStyle.css";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Checkbox from "@material-ui/core/Checkbox";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { loginUser } from "../../actions/authActions";
import { withRouter } from "react-router-dom";

class LoginCard extends React.Component {
    constructor() {
        super();

        this.state = {
            email: "",
            password: "",
            // errors: {}
        };

        this.handleChange = this.handleChange.bind(this);
        this.onClick = this.onClick.bind(this);
    }

    handleChange(event) {
        console.log(event.target.value)
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    onClick(event) {
        const userData = {
            grant_type: "password",
            username: this.state.email,
            password: this.state.password,
            client_id: "dashboard",
            client_secret:
                "$2b$10$rfxL7VOyA1bLtLtYr9xLW.RSpj5Sd6LaH5zBT/8YPxbJxGMKvBkcy"
        };

        this.props.loginUser(userData, this.props.history);
    }

    render() {
        return (
            <Card
                style={{
                    width: "330px",
                    display: "flex",
                    alignItems: "center",
                    textAlign: "center",
                    marginTop: "50px"
                }}
            >
                <input
                    type="text"
                    name="email"
                    value={this.state.email}
                    onChange={this.handleChange}>
                </input>
                <Button
                    onClick={this.onClick}
                    className="button-login"
                    variant="contained"
                    color="primary"
                    size="medium"
                    style={{ marginTop: "30px", width: "30%" }}
                >
                    Login
        </Button>
            </Card >
        );
    }
}

LoginCard.propTypes = {
    loginUser: PropTypes.func.isRequired,
    auth: PropTypes.object.isRequired,
    errors: PropTypes.object.isRequired
};

const mapStateToProps = state => ({
    auth: state.auth,
    errors: state.errors
});

export default withRouter(
    connect(
        mapStateToProps,
        {}
    )(LoginCard)
);
