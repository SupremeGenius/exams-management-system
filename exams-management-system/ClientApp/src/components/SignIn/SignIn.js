import React from 'react';

import Paper from "../core/Paper";
import Logo from "../core/Logo";
import SignInForm from './SignInForm'

import '../../styles/css/SignUp.css'

class SignInPage extends React.Component {
    render() {
        return (
            <div className='sign-up'>
                <Paper className='sign-up__paper'>
                    <h1 className='sign-up__title'> Welcome to <Logo /> </h1>
                    <SignInForm />
                </Paper>

            </div>
        )
    }
}


export default SignInPage;
