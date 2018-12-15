import React    from 'react';

import InputDropdown from '../core/InputDropdown'
import Input         from '../core/Input'
import Button        from "@material-ui/core/Button";

const INITIAL_STATE = {
  fullName:       '',
  email:          '',
  passwordOne:    '',
  passwordTwo:    '',
  error:          null,
  role:           {value:'Student', label: 'Student'},
  professorTitle: '',
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
      role,
      passwordOne,
      passwordTwo,
      registrationNumber,
      professorTitle,
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

        <div className="sign-up-form__row">
          <InputDropdown
            className   = 'sign-up-form__role-dropdown'
            title       = "Rol"
            value       = {role}
            onChange    = {(v) => this.onChange(v, 'role')}
            options     = {['Student', 'Profesor']}
            placeholder = 'Alege un rol'
          />

          {
            role.value === 'Student' &&
              <Input
                title    = "Numar Matricol"
                value    = {registrationNumber}
                onChange = {(v) => this.onChange(v, 'registrationNumber')}
              />
          }

          {
            role.value === 'Profesor' &&
              <Input
                title       = "Titlu"
                value       = {professorTitle}
                onChange    = {(v) => this.onChange(v, 'professorTitle')}
                placeholder = 'Conf. Dr.'
              />
          }
        </div>


        <Input
          title       = 'Parola'
          value       = {passwordOne}
          onChange    = {(v) => this.onChange(v, 'passwordOne')}
          type        = 'password'
          placeholder = '1 Parola Mai Grea $/#43'
        />

        <Input
          title    = 'Confirma Parola'
          value    = {passwordTwo}
          onChange = {(v) => this.onChange(v, 'passwordTwo')}
          type     = 'password'
        />

        <Button
          onClick = {this.onSubmit}
          className = "sign-up-form__submit"
          variant = "contained"
          color   = "primary"
          size    = "large"
          style   = {{ marginTop: "30px", backgroundColor: '#0075ff'}}> Creaza Cont
        </Button>
      </form>
    );
  }
}

export default SignUpForm;
