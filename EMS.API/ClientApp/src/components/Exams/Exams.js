import React      from 'react';

import ExamPanel from './ExamPanel'

import '../../styles/css/Exams.css'

class Exams extends React.Component {
  render() {
    return (
      <div className='exams-page'>
        {this.props.exams.map((exam, i)=>
          <ExamPanel key={i} course={this.props.courses[exam.courseId]} exam={exam} />)}
      </div>
    )
  }
}

Exams.defaultProps = {
  exams: [
    {
      id:       "86820fac-38ff-4f07-b6cb-53665634282b",
      courseId: "1021b38e-f2ef-4bf3-a051-fdbee34e0b9c",
      type:     "Examen",
      date:     'Wed Jan 22 2019 12:00',
      room:     "C309",
    },
    {
      id:       "86820fbc-38ff-4f07-b6cb-53665634282b",
      courseId: "1021b38e-f2ef-4bf3-a051-fdbee34e0b9c",
      type:     'Partial',
      date:     'Wed Jan 16 2019 10:00',
      room:     "C112",
    },
    {
      id:       "86820fac-38sf-4f07-b6cb-53665634282b",
      courseId: "1021b38e-f2ef-4ff3-a051-fdbee34e0b9c",
      type:     'Restanta',
      date:     'Wed Jan 21 2019 15:00',
      room:     "C2",
    },
    {
      id:       "86820fc-38ff-4f07-b6cb-53665634282b",
      courseId: "1021b18e-f2ef-4bf3-a051-fdbee34e0b9c",
      type:     'Examen',
      date:     'Wed Jan 16 2019 18:00',
      room:     "C309",
    },
  ],
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

export default Exams;
