import React      from 'react';

import Button     from "@material-ui/core/Button";

import '../../styles/css/Course.css'

class Course extends React.Component {
  render() {
    console.log(this.props)
    const courseId = this.props.match.params.courseId;
    console.log({courseId});
    const course     = this.props.location.state;

    return (
      <div className='course panel'>
        <div className="course__title">{course.title}</div>

        <div className="course__meta">
          <div className="course__meta--universityYear">
            <span className="course__meta--bold">An</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            {course.universityYear}
          </div>
          <div className="course__meta--studentYear">
            <span className="course__meta--bold">Anul</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            {course.studentYear}
          </div>
          <div className="course__meta--semester">
            <span className="course__meta--bold">Semestrul</span>&nbsp;&nbsp;&nbsp;
            {course.semester}
          </div>
        </div>

        <Button
          className = "course__submit"
          variant   = "contained"
          color     = "primary"
          size      = "large"
          style     = {{ marginTop: "30px", backgroundColor: '#0075ff'}}> Ma inscriu
        </Button>
      </div>
    )
  }
}

export default Course;
