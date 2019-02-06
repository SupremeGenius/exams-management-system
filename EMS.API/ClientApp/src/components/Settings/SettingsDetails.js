import React from 'react';

import Input     from '../core/Input'
import Button    from "@material-ui/core/Button";
import Variables from '../../constants/variables';

const INITIAL_STATE = {
  fullName: 'Gigel Stroe',
  email: 'gigel.stroethis.gmail.com',
  group: 'I3A4',
  registrationNumber: '1278312873612SL',
  professorTitle: 'Conf. Dr.',
  error: null,
  // role: 'Professor',
  role: 'Student',
};

class SettingsDetails extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      ...INITIAL_STATE,
    };
  }

  onChange = (value, key) => {
    this.setState({
      [key]: value,
    });
  };


  onSubmit = (e) => {
    e.preventDefault()
    console.log(e);
  }

  render() {
    const {
      fullName,
      email,
      group,
      role,
      registrationNumber,
      professorTitle,
    } = this.state;

    return (
      <div className="settings-details">
      <form onSubmit={this.onSubmit}>
        <Input
          title    = 'Nume Complet'
          value    = {fullName}
          name     = 'fullName'
          onChange = {(v) => this.onChange(v, 'fullName')}
        />

        <Input
          title    = 'Email'
          value    = {email}
          name     = 'email'
          readOnly = {role === Variables.studentRole}
        />

        {(()=> {
          switch (role) {
            case Variables.studentRole:
              return (
                <React.Fragment>
                  <Input
                    title    = 'Numar Matricol'
                    value    = {registrationNumber}
                    name     = 'registrationNumber'
                    readOnly = {true}
                  />

                  <Input
                    title    = 'Grupa'
                    value    = {group}
                    name     = 'group'
                    readOnly = {true}
                  />
                </React.Fragment>
              );
            case Variables.professorRole:
              return <Input
                title    = 'Titlu'
                value    = {professorTitle}
                name     = 'professorTitle'
              />;
            default: return null;

          }
        })()}

        <Button
          className = "settings-details__submit pull-right"
          variant = "contained"
          color   = "primary"
          size    = "large"
          type    = 'submit'
          style   = {{ marginTop: "30px", backgroundColor: '#0075ff'}}> Salveaza Modificarile
        </Button>
      </form>
      </div>
    )
  }
}

export default SettingsDetails;
