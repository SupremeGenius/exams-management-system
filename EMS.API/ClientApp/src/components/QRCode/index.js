import React, { Component } from "react";
import QrReader from "react-qr-reader";

import { Redirect } from 'react-router-dom'

class QR extends Component {
  constructor(props) {
    super(props);
    this.state = {
      delay: 100,
      result: null
    };
    this.handleScan = this.handleScan.bind(this);
  }
  handleScan(data) {
    console.log(data)
    if (data) {
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
      return <Redirect to='/exams' />
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