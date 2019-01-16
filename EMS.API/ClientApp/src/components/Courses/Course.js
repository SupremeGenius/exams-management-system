import React      from 'react';

import Button     from "@material-ui/core/Button";

import '../../styles/css/Course.css'

class Course extends React.Component {
  render() {
    const courseId = this.props.match.params.courseId;
    console.log({courseId});
    const course     = this.props.courses[courseId];

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
          style     = {{ marginTop: "30px", backgroundColor: '#0075ff'}}> Ma incriu
        </Button>
      </div>
    )
  }
}

Course.defaultProps = {
  courses: {
    "1021b38e-f2ef-4bf3-a051-fdbee34e0b9c":
      {
        id:             "1021b38e-f2ef-4bf3-a051-fdbee34e0b9c",
        title:          "Introducere in Programare",
        universityYear: '2018-2019',
        studentYear:    '1',
        semester:       '1',
      },
    "1021b38e-f2ef-4ff3-a051-fdbee34e0b9c":
      {
        id:             "1021b38e-f2ef-4ff3-a051-fdbee34e0b9c",
        title:          '.Net',
        universityYear: '2018-2019',
        studentYear:    '3',
        semester:       '1',
      },
    "1022b38e-f2ef-4bf3-a051-fdbee34e0b9c":
      {
        id:             "1022b38e-f2ef-4bf3-a051-fdbee34e0b9c",
        title:          'Ingineria Programarii',
        universityYear: '2017-2018',
        studentYear:    '2',
        semester:       '2',
      },
    "1021238e-f2ef-4bf3-a051-fdbee34e0b9c":
      {
        id:             "1021238e-f2ef-4bf3-a051-fdbee34e0b9c",
        title:          'Ingineria Programarii',
        universityYear: '2018-2019',
        studentYear:    '2',
        semester:       '2',
      },
    "1021b18e-f2ef-4bf3-a051-fdbee34e0b9c":
      {
        id:             "1021b18e-f2ef-4bf3-a051-fdbee34e0b9c",
        title:          'Dezvoltarea Aplicatiilor Web la Nivel de Client',
        universityYear: '2018-2019',
        studentYear:    '3',
        semester:       '1',
      },
  }
}
export default Course;
