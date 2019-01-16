import React      from 'react';
import moment from 'moment';

import '../../styles/css/ExamPanel.css'

class ExamPanel extends React.Component {
  render() {
    return (
      <div className='exam-panel'>
        <div>
          <div className="exam-panel__type">{this.props.exam.type}</div>
          <div className="exam-panel__course-title">{this.props.course.title}</div>
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
      </div>
    )
  }
}

export default ExamPanel;
