import React, { Component } from "react";
import QrReader from "react-qr-reader";

import { Redirect } from 'react-router-dom'

import { checkExam } from '../../actions/QR'


class QR extends Component {
  constructor(props) {
    super(props);
    this.state = {
      delay: 300,
      result: null
    };
    this.handleScan = this.handleScan.bind(this);
  }
  handleScan(data) {
    if (data) {
      console.log(this.props.location.state.id)
      checkExam(this.props.location.state.id); //examId, studentId luam din storage
      this.setState({
        result: data
      });
    }
  }
  handleError(err) {
    console.error(err);
  }
  render() {
    if (this.state.result !== null) {
      return <Redirect to={{ pathname: '/exams', state: JSON.parse(this.state.result) }} />
    }
    return (
      <div>
        <QrReader
          delay={this.state.delay}
          onError={this.handleError}
          onScan={this.handleScan}
          style={{ width: "300%" }}
        />
        <p>Apropie pentru a scana</p>
      </div>
    );
  }
}

export default QR