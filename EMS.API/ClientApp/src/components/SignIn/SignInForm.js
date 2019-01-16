import React from 'react';
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";

import Button from "@material-ui/core/Button";

import Input from '../core/Input'
import { loginUser } from "../../actions/Auth";

class SignUpForm extends React.Component {
    constructor() {
        super();

        this.state = {
            email: "",
            password: "",
            role: "",
            errors: null
        };
        this.onSubmit = this.onSubmit.bind(this);
        this.onChange = this.onChange.bind(this);
    }

    onChange(value, key) {
        this.setState({
            [key]: value,
        });
    };

    onSubmit(event) {
        const userData = {
            email: this.state.email,
            password: this.state.password,
            role: "professor"
        };
        this.props.loginUser(userData, this.props.history);
    }

    render() {
        // redirect here
        if (this.props.auth.isAuthenticated) {
            return <Redirect to = "/" / > ;
        }
        if (this.props.errors.errors) {
            this.props.errors.errors.Email ? alert(this.props.errors.errors.Email) : this.props.errors.errors.Password ? alert(this.props.errors.errors.Password) : alert(this.props.errors.errors)
            this.props.errors.errors = null
        }

        return ( <
            div className = 'sign-in-form' >
            <
            Input title = 'Email'
            value = { this.state.email }
            onChange = {
                (v) => this.onChange(v, 'email') }
            /> <
            Input title = "Password"
            type = "password"
            value = { this.state.password }
            onChange = {
                (v) => this.onChange(v, 'password') }
            /> <
            Button onClick = { this.onSubmit }
            variant = "contained"
            color = "primary"
            size = "medium"
            style = {
                { marginTop: "30px", width: "30%", backgroundColor: '#0075ff' } } > Sign In <
            /Button> <
            /div>
        );
    }
}

const mapStateToProps = state => ({
    auth: state.auth,
    errors: state.errors
});

export default connect(mapStateToProps, { loginUser })(SignUpForm);