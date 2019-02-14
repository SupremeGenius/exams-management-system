import React from 'react';
import _ from 'lodash';

import { connect } from "react-redux";
import { getExamGrades } from '../../actions/Statistics'
import Paper            from "../core/Paper";
import InputDropdown from '../core/InputDropdown'

import Chart from '../Chart'

import '../../styles/css/Statistics.css'

class Statistics extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      chart: 'real',
      exam: Exams[0]
    };

    this.grades = () => {
      const gaussGrades   = _.cloneDeep(this.props.students);
      const studentsNo    = gaussGrades.length;
      const gaussGradesNo = {}
      gaussGradesNo[10]   = Math.floor(studentsNo * gaussCurve.A)
      gaussGradesNo[9]    = Math.floor(studentsNo * gaussCurve.B)
      gaussGradesNo[8]    = Math.floor(studentsNo * gaussCurve.C)
      gaussGradesNo[7]    = Math.floor(studentsNo * gaussCurve.D)
      gaussGradesNo[6]    = Math.floor(studentsNo * gaussCurve.E)

      const BIndex = gaussGradesNo[10]
      const CIndex = BIndex + gaussGradesNo[9]
      const DIndex = CIndex + gaussGradesNo[8]
      const EIndex = DIndex + gaussGradesNo[7]
      const FIndex = EIndex + gaussGradesNo[6]
      gaussGradesNo[5] = studentsNo - FIndex

      gaussGrades.forEach((student, i) => {
        var grade = -1
        switch (true) {
          case (i < BIndex): grade = 10; break;
          case (i < CIndex): grade = 9; break;
          case (i < DIndex): grade = 8; break;
          case (i < EIndex): grade = 7; break;
          case (i < FIndex): grade = 6; break;
          default: grade = 5; break;
        }

        student.grade = grade

      });

      const gradesNo = _.countBy(this.props.students, (s) => s.grade)

      return {gaussGrades, gaussGradesNo, gradesNo}
    }
  }

  componentWillMount() {
    // This method runs when the component is first added to the page
    this.props.getExamGrades();
  }

  onTabClick = (chart) => {
    this.setState({
      chart
    })
  }

  onChange = (value, field) => {
    this.state[field] = value

    this.setState(this.state)
  }

  render() {
    if (this.props.students) {
      const {gaussGradesNo, gaussGrades, gradesNo} = this.grades()
      return (
        <Paper className='statistics'>
          <div className='statistics__header-wrapper'>
            <div className='ems__header statistics__header'>
              <div
                onClick   = {() => this.onTabClick('real')}
                className = {`ems__header-tab ${this.state.chart === 'real' ? 'ems__header-tab--active' : ''}`}
              >Note Reale</div>
              <div
                onClick   = {() => this.onTabClick('gauss')}
                className = {`ems__header-tab ${this.state.chart === 'gauss' ? 'ems__header-tab--active' : ''}`}
              >Gauss</div>

            </div>
            <InputDropdown
              className   = 'statistics__dropdown'
              title       = "Rol"
              value       = {this.state.exam}
              onChange    = {(v) => this.onChange(v, 'exam')}
              options     = {Exams}
              placeholder = 'Alege un Examen'
              />
          </div>

          {(() => {
            switch(this.state.chart) {
              case 'real':
                return <Chart gradesNo={gradesNo} currentStudent={this.props.students[15]} data={this.props.students}/>;
              case 'gauss':
                return <Chart gaussGradesNo={gaussGradesNo} currentStudent={this.props.students[15]} data={gaussGrades}/>;
              default:
                return null;
            }
          })()}
          <div className='statistics__legend'>
            <div className='statistics__legend-row'>
              <div className="statistics__legend-simbol statistics__legend-simbol--my-grade"></div>
              <div className="statistics__legend-text">Nota Mea</div>
            </div>
          </div>
        </Paper>
      )
    } else return null
  }
}

const gaussCurve = {
  A: 0.10,
  B: 0.17,
  C: 0.28,
  D: 0.25,
  E: 0.18,
}

const Exams = ['.Net', 'Introducere in Programare', 'Ingineria Programarii']
const mapStateToProps = state => {
  return ({
    students: [
      {grade: 9, userId: 'iasiodj'},
      {grade: 9.5, userId: '12312dasd'},
      {grade: 9.5, userId: '112312dasd'},
      {grade: 9.5, userId: '212312dasd'},
      {grade: 9.5, userId: '312312dasd'},
      {grade: 9.5, userId: '412312dasd'},
      {grade: 8.3, userId: '12kjeadksd'},
      {grade: 8.3, userId: '112kjeadksd'},
      {grade: 8.3, userId: '212kjeadksd'},
      {grade: 8.3, userId: '312kjeadksd'},
      {grade: 8.3, userId: '412kjeadksd'},
      {grade: 8.3, userId: '612kjeadksd'},
      {grade: 8.3, userId: '712kjeadksd'},
      {grade: 8.3, userId: '812kjeadksd'},
      {grade: 8.3, userId: '912kjeadksd'},
      {grade: 8.3, userId: '012kjeadksd'},
      {grade: 8.3, userId: '1112kjeadksd'},
      {grade: 8.3, userId: '1212kjeadksd'},
      {grade: 8.3, userId: '1312kjeadksd'},
      {grade: 5, userId: '12j31ksds2'},
      {grade: 5.3, userId: '12j31k2'},
      {grade: 5.3, userId: '112j31k2'},
      {grade: 5.3, userId: '212j31k2'},
      {grade: 5.3, userId: '312j31k2'},
      {grade: 5.3, userId: '412j31k2'},
      {grade: 5.5, userId: '12j1231k2'},
      {grade: 9, userId: '12jasd31k2'},
      {grade: 5, userId: '12js31k2'},
      {grade: 5, userId: '112js31k2'},
      {grade: 5, userId: '212js31k2'},
      {grade: 5, userId: '312js31k2'},
      {grade: 5, userId: '412js31k2'},
      {grade: 6, userId: 'bhfjs'},
      {grade: 7.3, userId: '322b12hfjs'},
      {grade: 7.3, userId: '23b12hfjs'},
      {grade: 7.3, userId: '332b12hfjs'},
      {grade: 7.4, userId: '24b12hfjs'},
      {grade: 7.4, userId: '14b12hfjs'},
      {grade: 7.4, userId: '44b12hfjs'},
      {grade: 7.4, userId: '54b12hfjs'},
      {grade: 7.4, userId: '64b12hfjs'},
      {grade: 7.4, userId: '47b12hfjs'},
      {grade: 7.6, userId: '26b12hfjs'},
      {grade: 7.6, userId: '7b12hfjs'},
      {grade: 7, userId: '1b12hfjs'},
      {grade: 7, userId: '2b12hfjs'},
      {grade: 7, userId: '3b12hfjs'},
      {grade: 7, userId: '4b12hfjs'},
      {grade: 7, userId: '5b12hfjs'},
      {grade: 7, userId: '6b12hfjs'},
      {grade: 6, userId: '3poikj'},
      {grade: 6, userId: '4poikj'},
      {grade: 6, userId: '5poikj'},
      {grade: 6, userId: '6poikj'},
      {grade: 6, userId: '7poikj'},
      {grade: 6, userId: '8poikj'},
      {grade: 6, userId: '9poikj'},
      {grade: 6, userId: '0poikj'},
      {grade: 5, userId: '1dji2qwsd'},
      {grade: 5, userId: '2dji2qwsd'},
      {grade: 5, userId: '3dji2qwsd'},
      {grade: 5, userId: '4dji2qwsd'},
      {grade: 5, userId: '5dji2qwsd'},
      {grade: 5, userId: '6dji2qwsd'},
      {grade: 5, userId: '7dji2qwsd'},
      {grade: 5, userId: '8dji2qwsd'},
      {grade: 5, userId: '9dji2qwsd'},
      {grade: 4, userId: 'a213erfr'},
      {grade: 4, userId: '123erfd'},
      {grade: 4, userId: 'ajsfajk23'},
      {grade: 8, userId: '1-20oeifdj'},
      {grade: 8, userId: '21-20oeifdj'},
      {grade: 8, userId: '31-20oeifdj'},
      {grade: 8, userId: '41-20oeifdj'},
      {grade: 8, userId: '5123erfdjken'},
      {grade: 1, userId: '123er1fdjken'},
      {grade: 1, userId: '3123er1fdjken'},
      {grade: 1, userId: '2123er1fdjken'},
      {grade: 2, userId: '12a3er1fdjken'}
    ]
  });
}

export default connect(mapStateToProps, { getExamGrades })(Statistics);
