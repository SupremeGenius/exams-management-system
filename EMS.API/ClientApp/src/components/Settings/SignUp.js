import React      from 'react';

// import Button from "@material-ui/core/Button";

import Paper      from "../core/Paper";
import SignUpForm from './SignUpForm'
import { SignInLink } from '../SignIn'

import '../../styles/css/SignUp.css'

class SignUpPage extends React.Component {
  render() {
    return (
      <div className='sign-up'>
        <div className="sign-up__container">
          <Paper className='sign-up__paper'>
            <SignUpForm />
          </Paper>

          <SignInLink />
        </div>
      </div>
    )
  }
}


export default SignUpPage;
