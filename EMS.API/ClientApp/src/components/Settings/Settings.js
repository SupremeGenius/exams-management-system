import React      from 'react';

// import Button from "@material-ui/core/Button";

import Paper      from "../core/Paper";
import SettingsForm from './SettingsForm'

import '../../styles/css/SignUp.css'

class Settings extends React.Component {
  render() {
    return (
      <div className='sign-up'>
        <div className="sign-up__container">
          <Paper className='sign-up__paper'>
            <SettingsForm />
          </Paper>

        </div>
      </div>
    )
  }
}


export default Settings;
