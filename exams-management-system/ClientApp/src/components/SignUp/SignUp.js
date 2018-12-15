import React      from 'react';

// import Button from "@material-ui/core/Button";

import Paper      from "../core/Paper";
import Logo       from "../core/Logo";
import SignUpForm from './SignUpForm'
import { SignInLink } from '../SignIn'

import '../../styles/css/SignUp.css'

class SignUpPage extends React.Component {
  render() {
    return (
      <div className='sign-up'>
        <div className="sign-up__container">
          <Paper className='sign-up__paper'>
            <h1 className='sign-up__title'> Welcome to <Logo /> </h1>
            <SignUpForm />
          </Paper>

          <SignInLink />
        </div>
      </div>
    )
  }
}


export default SignUpPage;
