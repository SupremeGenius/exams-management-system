import React    from 'react';

import Input  from '../core/Input'
import Button from '../core/Button'

const INITIAL_STATE = {
  fullName:    '',
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
    // const { fullName, email, passwordOne } = this.state;
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
      fullName,
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
      fullName === '';

    return (
      <form className='sign-up-form' onSubmit={this.onSubmit}>
        <Input
          title       = 'Nume Complet'
          value       = {fullName}
          />
        <Input
          title       = 'Email'
          value       = {email}
          />
        <Input
          title    = "Numar Matricol"
          value    = {registrationNumber}
        />
      </form>
    );
  }
}

export default SignUpForm;
