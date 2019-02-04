import React      from 'react';

import CourseTile from './CourseTile'

import { connect } from "react-redux";

import { getCourses } from '../../actions/Courses'

import '../../styles/css/Courses.css'

class Courses extends React.Component {
  componentWillMount() {
    // This method runs when the component is first added to the page
    this.props.getCourses();
  }

  render() {
    if (!this.props.courses) { 
      return null; 
    }
      return (
        <div className='courses-page'>
          {this.props.courses.map((course, i) => <CourseTile key={i} course={course} />)}
        </div>
      )
  }
}

const mapStateToProps = state => ({
  courses: state.courses.courses
});

export default connect(mapStateToProps, { getCourses })(Courses);