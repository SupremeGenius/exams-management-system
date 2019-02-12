import React from 'react';

import ExamPanel from './ExamPanel'

import { connect } from "react-redux";

import { getExams } from '../../actions/Exams'

import '../../styles/css/ExamPanel.css'


class Exams extends React.Component {
  componentWillMount() {
    // This method runs when the component is first added to the page
    this.props.getExams();
  }

  render() {
    console.log(this.props.exams)
    if (this.props.exams) {
      return (
        <div className='exams-page'>
          {this.props.exams.map((exam, i) =>
            <ExamPanel key={i} exam={exam} />)}
        </div>
      )
    }
  }
}

const mapStateToProps = state => ({
  exams: state.exams.exams
});

export default connect(mapStateToProps, { getExams })(Exams);