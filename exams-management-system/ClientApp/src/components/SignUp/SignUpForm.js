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

  onChange = (value, key) => {
    this.setState({
      [key]: value,
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

    return (
      <form className='sign-up-form' onSubmit={this.onSubmit}>
        <Input
          title    = 'Nume Complet'
          value    = {fullName}
          name     = 'fullName'
          onChange = {(v) => this.onChange(v, 'fullName')}
          />
        <Input
          title    = 'Email'
          value    = {email}
          onChange = {(v) => this.onChange(v, 'email')}
          />
        <Input
          title    = "Numar Matricol"
          value    = {registrationNumber}
          onChange = {(v) => this.onChange(v, 'registrationNumber')}
        />
      </form>
    );
  }
}

export default SignUpForm;
