import React from 'react';

import Input from '../core/Input'
import TextField from '@material-ui/core/TextField';
import Button from "@material-ui/core/Button";

const INITIAL_STATE = {
  fullName: 'Nume Default',
  email: 'Email Default',
  grupa: 'Grupa Default',
  registrationNumber: 'nr mat Default1278312873612SL',
  error: null,
  role: { value: 'Student' }
};

class SignUpForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {};
    this.state = { ...INITIAL_STATE, isEditing: false };
    this.toggleEdit = this.toggleEdit.bind(this);
  }

  onSubmit = event => {
    // const { fullName, email, passwordOne } = this.state;
  }

  toggleEdit() {
    this.setState({ isEditing: !this.state.isEditing })
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
      grupa,
      role,
      registrationNumber,
      professorTitle,
    } = this.state;

    if (this.state.isEditing) {

      return (
        <form className='sign-up-form' onSubmit={this.onSubmit}>
          <Input
            title='Nume Complet'
            value={fullName}
            name='fullName'
            onChange={(v) => this.onChange(v, 'fullName')}
          />

          <Input
            title='Email'
            value={email}
            onChange={(v) => this.onChange(v, 'email')}
          />

          <div className="sign-up-form__row">

            {
              role.value === 'Student' &&
              <Input
                title="Numar Matricol"
                value={registrationNumber}
                onChange={(v) => this.onChange(v, 'registrationNumber')}
              />
            }

            {
              role.value === 'Profesor' &&
              <Input
                title="Titlu"
                value={professorTitle}
                onChange={(v) => this.onChange(v, 'professorTitle')}
                placeholder='Conf. Dr.'
              />
            }
          </div>
          <Input
            title='Grupa'
            value={grupa}
            onChange={(v) => this.onChange(v, 'grupa')}
          />
          <Button
            onClick={this.toggleEdit}
            className="sign-up-form__submit"
            variant="contained"
            color="primary"
            size="large"
            style={{ marginTop: "30px", backgroundColor: '#0075ff' }}> Modifica
        </Button>
        </form>
      );
    }
    return (
      <form className='sign-up-form' onSubmit={this.onSubmit}>
        <h1>Student Info</h1>
        <hr></hr> {/*trebuie stilizat a arata , nu arata xD */}
        Nume: <TextField
          defaultValue={fullName}
          margin="normal"
          InputProps={{
            readOnly: true,
          }}
        />
        Email: <TextField
          defaultValue={email}
          margin="normal"
          InputProps={{
            readOnly: true,
          }}
        />
        Grupa: <TextField
          defaultValue={grupa}
          margin="normal"
          InputProps={{
            readOnly: true,
          }}
        />
        <div>
          {role.value === 'Student' && <h1> Nr.Matricol </h1>}
          {role.value === 'Professor' && <h1>Titlu </h1>}
        {
          role.value === 'Student' &&
           <TextField
            defaultValue={registrationNumber}
            margin="normal"
            InputProps={{
              readOnly: true,
            }}
          />
        }

        {
          role.value === 'Profesor' &&
           <TextField
            defaultValue={professorTitle}
            margin="normal"
            InputProps={{
              readOnly: true,
            }}
          />
          }
          </div>
        <Button
          onClick={this.toggleEdit}
          className="sign-up-form__submit"
          variant="contained"
          color="primary"
          size="large"
          style={{ marginTop: "30px", backgroundColor: '#0075ff' }}> Edit
        </Button>
      </form>
    );
  }
}

export default SignUpForm;
