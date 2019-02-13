import React, { Component } from "react";

import { Redirect } from 'react-router-dom'
//localStorage.removeItem('jwtToken')

class SignOut extends React.Component {
  render() {
    return <Redirect to='/signin' />
  }
}


export default SignOut;