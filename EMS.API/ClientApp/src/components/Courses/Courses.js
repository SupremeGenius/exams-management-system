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
      title:          "Introducere in Programare",
      universityYear: '2018-2019',
      studentYear:    '1',
      semester:       '1',
    },
    {
      title:          '.Net',
      universityYear: '2018-2019',
      studentYear:    '3',
      semester:       '1',
    },
    {
      title:          'Ingineria Programarii',
      universityYear: '2017-2018',
      studentYear:    '2',
      semester:       '2',
    },
    {
      title:          'Ingineria Programarii',
      universityYear: '2018-2019',
      studentYear:    '2',
      semester:       '2',
    },
    {
      title:          'Dezvoltarea Aplicatiilor Web la Nivel de Client',
      universityYear: '2018-2019',
      studentYear:    '3',
      semester:       '1',
    },
  ]
}

export default Courses;
