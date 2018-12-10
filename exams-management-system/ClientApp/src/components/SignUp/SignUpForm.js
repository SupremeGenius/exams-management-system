import React  from 'react';

const INITIAL_STATE = {
  username:    '',
  email:       '',
  passwordOne: '',
  passwordTwo: '',
  error:       null,
};

class SignUpForm extends React.Component {
  constructor(props) {
    super(props);

    this.state = {...INITIAL_STATE};
  }

  onSubmit = event => {
    // const { username, email, passwordOne } = this.state;
  }

  onChange = event => {
    this.setState({ [event.target.name]: event.target.value });
  };

  render() {
    const {
      username,
      email,
      passwordOne,
      passwordTwo,
      error,
      registrationNumber,
    } = this.state;

    const isInvalid =
      passwordOne !== passwordTwo ||
      passwordOne === '' ||
      email === '' ||
      registrationNumber === '' ||
      username === '';

    return (
      <form className='sign-up-form' onSubmit={this.onSubmit}>
        <input
          name        = "username"
          value       = {username}
          onChange    = {this.onChange}
          type        = "text"
          placeholder = "Full Name"
        />
        <input
          name        = "registrationNumber"
          value       = {registrationNumber}
          onChange    = {this.onChange}
          type        = "text"
          placeholder = "Registration Number"
        />
        <input
          name        = "email"
          value       = {email}
          onChange    = {this.onChange}
          type        = "text"
          placeholder = "Email Address"
        />
        <input
          name        = "passwordOne"
          value       = {passwordOne}
          onChange    = {this.onChange}
          type        = "password"
          placeholder = "Password"
        />
        <input
          name        = "passwordTwo"
          value       = {passwordTwo}
          onChange    = {this.onChange}
          type        = "password"
          placeholder = "Confirm Password"
        />
        <button disabled={isInvalid} type="submit">
          Sign Up
        </button>

        {error && <p>{error.message}</p>}
      </form>
    );
  }
}

export default SignUpForm