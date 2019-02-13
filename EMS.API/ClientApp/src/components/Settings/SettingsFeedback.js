import React from 'react';

import Input     from '../core/Input'
import Button    from "@material-ui/core/Button";

class SettingsFeedback extends React.Component {
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
    // aici o sa pun un textarea
    return (
      <div className="settings-feedback">
        <form onSubmit={this.onSubmit}>
          <Input
            title    = 'Lasa un feedback'
            value    = {this.state.feedback}
            name     = 'feedback'
            maxRows  = {5}
            onChange = {(v) => this.onChange(v, 'feedback')}
          />

          <Button
            className = "settings-details__submit pull-right"
            variant   = "contained"
            color     = "primary"
            size      = "large"
            type      = 'submit'
            style     = {{ marginTop: "30px", backgroundColor: '#0075ff'}}> Trimite Feedback
          </Button>
        </form>
      </div>
    )
  }
}

export default SettingsFeedback;
