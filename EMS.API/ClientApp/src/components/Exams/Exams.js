import React from 'react';

import ExamPanel from './ExamPanel'

import { connect } from "react-redux";

import { getExams } from '../../actions/Exams'
import { locale } from 'moment';

// import '../../styles/css/ExamPanel.css'


class Exams extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      examPanelKey: Math.random()
    };
  }
  componentWillMount() {
    // This method runs when the component is first added to the page
    this.props.getExams();
  }

  componentDidUpdate() {
    console.log(this.props.exams)
    console.log(this.props.location.state)
    if (this.props.location.state) {
      for (let i = 0; i < this.props.exams.length; i++) {
        if (this.props.exams[i].id === this.props.location.state.examId) {
          this.props.exams[i].checked = 'yes'
          if (!this.state.checked) {
            this.setState({ examPanelKey: Math.random(), checked: true })
          }
        }
      }
    }
  }

  render() {
    console.log(this.props.exams)
    if (this.props.exams) {
      return (
        <div className='exams-page'>
          {this.props.exams.map((exam, i) =>
            exam.courseName ? <ExamPanel key={`${i}-${this.state.examPanelKey}`} exam={exam} /> : '')}
        </div>
      )
    }
  }
}

const mapStateToProps = state => ({
  exams: state.exams.exams
});

export default connect(mapStateToProps, { getExams })(Exams);
