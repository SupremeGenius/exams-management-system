import React from 'react';

import Button    from "@material-ui/core/Button";
import Input     from '../core/Input'

class SettingsPassword extends React.Component {
  constructor(props) {
    super(props);

    this.state = {};
  }
  
  onSubmit = (e) => {
    e.preventDefault()
    console.log(e);
  }

  onChange = (value, key) => {
    this.setState({
      [key]: value,
    });
  };

  render() {
    const {
      currentPassword,
      newPassword,
    } = this.state;

    return (
      <div className="settings-password">
        <form onSubmit={this.onSubmit}>
          <Input
            title    = 'Parola Actuala'
            value    = {currentPassword}
            name     = 'currentPassword'
            onChange = {(v) => this.onChange(v, 'currentPassword')}
            type     = "password"

          />

          <Input
            title    = 'Parola Noua'
            value    = {newPassword}
            name     = 'newPassword'
            onChange = {(v) => this.onChange(v, 'newPassword')}
            type     = "password"
          />

          <Button
            className = "settings-details__submit pull-right"
            variant   = "contained"
            color     = "primary"
            size      = "large"
            type      = 'submit'
            style     = {{ marginTop: "30px", backgroundColor: '#0075ff'}}> Actualizeaza Parola
          </Button>
        </form>
      </div>
    )
  }
}

export default SettingsPassword;
