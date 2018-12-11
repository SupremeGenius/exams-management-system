import React    from 'react';

import Input from '../core/input'
import Button from '../core/Button'

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

  handleChange = name => event => {
    this.setState({
      [name]: event.target.value,
    });
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

    const { classes } = this.props;

    const isInvalid =
      passwordOne !== passwordTwo ||
      passwordOne === '' ||
      email === '' ||
      registrationNumber === '' ||
      username === '';

    return (
      <form className='sign-up-form' onSubmit={this.onSubmit}>
        <Input
          label    = "Numar Matricol"
          onChange = {this.handleChange('nrMat')}
          value    = {registrationNumber}
        />
        <Input
          label    = "Email"
          onChange = {this.handleChange('email')}
          value    = {email}
        />
        <Input
          label    = "Password"
          onChange = {this.handleChange('passwordOne')}
          value    = {passwordOne}
          type     = "password"
        />
        <Input
          label    = "Confirm Password"
          onChange = {this.handleChange('passwordTwo')}
          value    = {passwordTwo}
          type     = "password"
        />

        <Button disabled={isInvalid} type='submit'>
          Sign Up
        </Button>

        {error && <p>{error.message}</p>}
      </form>
    );
  }
}

export default SignUpForm;
