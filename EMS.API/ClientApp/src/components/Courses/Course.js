import React      from 'react';

import '../../styles/css/Course.css'

class Course extends React.Component {
  render() {
    const courseId = this.props.match.params.courseId;
    console.log({courseId});
    const course     = this.props.courses[courseId];

    return (
      <div className='course'>
        <div className="course__title">{course.title}</div>

        <div className="course__meta">
          <div className="course__meta--universityYear">An Universitar: {course.universityYear}</div>
          <div className="course__meta--studentYear">Anul {course.studentYear}</div>
          <div className="course__meta--semester">Semestrul {course.semester}</div>
        </div>
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
