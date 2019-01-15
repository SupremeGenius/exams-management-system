import React      from 'react';

import '../../styles/css/CourseTile.css'

class CourseTile extends React.Component {
  render() {
    return (
      <div className='course-tile'>
        <div className="course-tile__title">{this.props.course.title}</div>

        <div className="course-tile__meta">
          <div className="course-tile__meta--universityYear">An Universitar: {this.props.course.universityYear}</div>
          <div className="course-tile__meta--studentYear">Anul {this.props.course.studentYear}</div>
          <div className="course-tile__meta--semester">Semestrul {this.props.course.semester}</div>
        </div>
      </div>
    )
  }
}

export default CourseTile;
