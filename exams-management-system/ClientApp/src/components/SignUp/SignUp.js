import React      from 'react';

import Card   from "@material-ui/core/Card";
// import Button from "@material-ui/core/Button";

import SignUpForm from './SignUpForm'

import './SignUp.scss'

class SignUpPage extends React.Component {
  constructor(props) {
    super(props);

  }

  render() {
    return (
      <div className='sign-up'>
        <Card classes={{root:'sing-up__card'}} className='sing-up__card' style={{width: 500}}>
          <h1 className='sign-up__title'>Welcome back</h1>
          <SignUpForm />
        </Card>

      </div>
    )
  }
}


export default SignUpPage;
