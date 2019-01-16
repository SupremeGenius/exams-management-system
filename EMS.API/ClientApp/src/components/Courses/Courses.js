import React      from 'react';

import CourseTile from './CourseTile'

import '../../styles/css/Courses.css'

class Courses extends React.Component {
  render() {
    return (
      <div className='courses-page'>
        {this.props.courses.map((course, i)=> <CourseTile key={i} course={course} />)}
      </div>
    )
  }
}

Courses.defaultProps = {
  courses: [
    {
      id:             "1021b38e-f2ef-4bf3-a051-fdbee34e0b9c",
      title:          "Introducere in Programare",
      universityYear: '2018-2019',
      studentYear:    '1',
      semester:       '1',
    },
    {
      id:             "1021b38e-f2ef-4ff3-a051-fdbee34e0b9c",
      title:          '.Net',
      universityYear: '2018-2019',
      studentYear:    '3',
      semester:       '1',
    },
    {
      id:             "1022b38e-f2ef-4bf3-a051-fdbee34e0b9c",
      title:          'Ingineria Programarii',
      universityYear: '2017-2018',
      studentYear:    '2',
      semester:       '2',
    },
    {
      id:             "1021238e-f2ef-4bf3-a051-fdbee34e0b9c",
      title:          'Ingineria Programarii',
      universityYear: '2018-2019',
      studentYear:    '2',
      semester:       '2',
    },
    {
      id:             "1021b18e-f2ef-4bf3-a051-fdbee34e0b9c",
      title:          'Dezvoltarea Aplicatiilor Web la Nivel de Client',
      universityYear: '2018-2019',
      studentYear:    '3',
      semester:       '1',
    },
  ]
}

export default Courses;
