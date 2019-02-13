import React, { Component } from "react";
import { connect } from "react-redux";

import { Redirect } from 'react-router-dom'

import { logoutUser } from '../../actions/Auth'

class SignOut extends Component {

  componentWillMount() {
    this.props.logoutUser();
  }

  render() {
    return <Redirect to='/signin' />
  }
}


const mapStateToProps = state => ({
  user: state.user.user
});

export default connect(mapStateToProps, { logoutUser })(SignOut);