import React from "react";
//import LoginCard from "./LoginCard";
import Card from "@material-ui/core/Card";
import Button from "@material-ui/core/Button";
import "../../styles/LoginPage/LoginCardStyle.css";
import { connect } from "react-redux";
//import logo from "../../images/dogo.png";
import background from "../../images/bg.jpg";
import { Link, Redirect  } from "react-router-dom";
import { loginUser } from "../../actions/Auth";


class Login extends React.Component {
    constructor() {
        super();

        this.state = {
            email: "",
            password: "",
            nrmat: "",
            errors: {}
        };

        this.handleChange = this.handleChange.bind(this);
        this.onClick = this.onClick.bind(this);
    }

    handleChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    onClick(event) {
        const userData = {
            email: this.state.email,
            password: this.state.password,
        };

        this.props.loginUser(userData, this.props.history);
    }

 

    render() {
        // redirect here
        if (this.props.auth.isAuthenticated) {
            return <Redirect to="/" />;
        }
        return (
            <div>
                <img
                    alt="background"
                    src={background}
                    style={{
                        minHeight: "100%",
                        minWidth: "1024px",
                        width: "100%",
                        height: "auto",
                        position: "fixed",
                        top: 0,
                        left: 0
                    }}
                />
                <Card
                    classes={{ root: "classes-login" }}
                    className="login-form"
                    style={{
                        width: "400px",
                        display: "flex",
                        alignItems: "center",
                        textAlign: "center",
                        marginTop: "50px"
                    }}
                >
                    <div style={{ padding: "5px" }} >
                        {/* dunno why is not rendering => research more maybe
                   <LoginCard /> */}
                        <input
                            style={{ marginTop: "10px", color: "grey" }}
                            id="emailFields"
                            type="text"
                            name="email"
                            placeholder="email"
                            value={this.state.email}
                            onChange={this.handleChange}>
                        </input>
                        <input
                            style={{ marginTop: "10px", color: "grey" }}
                            type="password"
                            name="password"
                            placeholder="password"
                            value={this.state.password}
                            onChange={this.handleChange}>
                        </input>
                    </div>
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
                    <div
                        style={{
                            position: "relative",
                            color: "white",
                            marginTop: 35,
                            marginBottom: 15
                        }}
                    >
                        Forgot your password ?
                    </div>
                    <div style={{ position: "relative", color: "#bde8fc" }}>
                        Please click
                        <Link
                            to="/register"
                            style={{
                                fontWeight: "bold",
                                color: "blue",
                                textDecoration: "none"
                            }}
                        >
                            {" "}
                            HERE{" "}
                        </Link>
                        if you don't have an account
                    </div>

                    <div
                        style={{
                            position: "relative",
                            color: "#bde8fc",
                            marginTop: 60,
                            paddingLeft: 20
                        }}
                    >
                        © 2018 - Exams Management System is a EDGVV Project. Please{" "}
                        <span style={{ fontWeight: "bold", color: "blue" }}>
                            contact us
                    </span>{" "}
                        for any question or problem that you encounter.
                </div>
                </Card>
            </div>
        );
    }
}

const mapStateToProps = state => ({
    auth: state.auth,
    errors: state.errors
});

export default connect(mapStateToProps, { loginUser })(Login);
