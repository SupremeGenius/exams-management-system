import React from 'react';

import Paper          from "../core/Paper";
import Logo           from "../core/Logo";
import SignInForm     from './SignInForm'
import { SignUpLink } from '../SignUp'

import '../../styles/css/SignIn.css'

class SignInPage extends React.Component {
  render() {
    return (
      <div className='sign-in'>
        <div className="sign-in__container">
          <Paper className='sign-in__paper'>
            <h1 className='sign-in__title'> Welcome to <Logo /> </h1>
            <SignInForm />
          </Paper>

          <SignUpLink />
        </div>
      </div>
    )
  }
}


export default SignInPage;
