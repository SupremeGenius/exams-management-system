import React      from 'react';
import moment from 'moment';

import Button from "@material-ui/core/Button";
import { Link } from 'react-router-dom'

import '../../styles/css/ExamPanel.css'

class ExamPanel extends React.Component {

  scanQR = function () {
    alert('SCAN')
  }

  render() {
    return (
      <a className='exam-panel panel panel-sm'>
        <div>
          <div className="exam-panel__type">{this.props.exam.type}</div>
          <div className="exam-panel__course-title">{this.props.exam.courseName}</div> 
        </div>

        <div className="exam-panel__meta">
          <div className="exam-panel__meta--room">
            <span className="exam-panel__meta--mute">Sala</span>&nbsp;&nbsp;
            {this.props.exam.room}</div>
          <div className="exam-panel__meta--hour">
            <span className="exam-panel__meta--mute">Ora</span>&nbsp;&nbsp;&nbsp;
            {moment(this.props.exam.date).format("HH:mm")}</div>
          <div className="exam-panel__meta--date">
            <span className="exam-panel__meta--mute">Data</span>&nbsp;
            {moment(this.props.exam.date).format("DD.MM.YYYY")}</div>
        </div>
        <Link to={{
          pathname: `/scan`
        }}> Scan </Link>
      </a>
    )
  }
}

export default ExamPanel;
