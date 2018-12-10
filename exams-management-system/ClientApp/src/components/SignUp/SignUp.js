import React      from 'react';

import Card   from "@material-ui/core/Card";
// import Button from "@material-ui/core/Button";

import SignUpForm from './SignUpForm'

import '../../styles/css/SignUp.css'

class SignUpPage extends React.Component {
  render() {
    return (
      <div className='sign-up'>
        <Card classes={{root:'sing-up__card'}} className='sing-up__card' style={{width: 500, margin: 'auto', padding: '40px 0', textAlign: 'center'}}>
          <h1 className='sign-up__title'> EMS </h1>
          <SignUpForm />
        </Card>

      </div>
    )
  }
}


export default SignUpPage;
