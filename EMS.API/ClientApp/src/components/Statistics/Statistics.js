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
    };

    this.gaussGrades = () => {
      const students = _.cloneDeep(this.props.students);
      const studentsNo = students.length
      const As = Math.floor(studentsNo * gaussCurve.A)
      const Bs = Math.floor(studentsNo * gaussCurve.B)
      const Cs = Math.floor(studentsNo * gaussCurve.C)
      const Ds = Math.floor(studentsNo * gaussCurve.D)
      const Es = Math.floor(studentsNo * gaussCurve.E)

      const BIndex = As
      const CIndex = BIndex + Bs
      const DIndex = CIndex + Cs
      const EIndex = DIndex + Ds
      const FIndex = EIndex + Es

      students.forEach((student, i) => {
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

      return students
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
              options     = {['.Net', 'Introducere']}
              placeholder = 'Alege un Examen'
              style       = {{backgroundColor: 'white'}}
              />
          </div>

          {(() => {
            switch(this.state.chart) {
              case 'real':
                return <Chart currentStudent={this.props.students[15]} data={this.props.students}/>;
              case 'gauss':
                return <Chart currentStudent={this.props.students[15]} data={this.gaussGrades()}/>;
              default:
                return null;
            }
          })()}
          <div className='statistics__legend'>
            <div className='statistics__legend-row'>
              <div className="statistics__legend-simbol statistics__legend-simbol--best-grade"></div>
              <div className="statistics__legend-text">Nota cea mai mare</div>
            </div>
            <div className='statistics__legend-row'>
              <div className="statistics__legend-simbol statistics__legend-simbol--my-grade"></div>
              <div className="statistics__legend-text">Nota Mea</div>
            </div>
            <div className='statistics__legend-row'>
              <div className="statistics__legend-simbol statistics__legend-simbol--worst-grade"></div>
              <div className="statistics__legend-text">Nota cea mai mica</div>
            </div>
          </div>
        </Paper>
      )
    } else return null
  }
}

const gaussCurve = {
  A: 0.10,
  B: 0.15,
  C: 0.15,
  D: 0.30,
  E: 0.20,
  F: 0.10,
}

const mapStateToProps = state => {
  console.log({state});
  return ({
    students: [
      {grade: 10, userId: 'iasiodj'},
      {grade: 9.5, userId: '12312dasd'},
      {grade: 8.3, userId: '12kjeadksd'},
      {grade: 5, userId: '12j31ksds2'},
      {grade: 5.3, userId: '12j31k2'},
      {grade: 5.5, userId: '12j1231k2'},
      {grade: 5.5, userId: '12jasd31k2'},
      {grade: 5, userId: '12js31k2'},
      {grade: 6, userId: 'bhfjs'},
      {grade: 7, userId: 'b12hsfjs'},
      {grade: 7, userId: 'b12hfjs'},
      {grade: 7.8, userId: 'b12h654fjs'},
      {grade: 7.7, userId: 'b12a21hfjs'},
      {grade: 6, userId: 'poikj'},
      {grade: 5, userId: 'dji2qwsd'},
      {grade: 4, userId: 'a213erfr'},
      {grade: 4, userId: '123erfd'},
      {grade: 4, userId: 'ajsfajk23'},
      {grade: 8, userId: '1-20oeifdj'},
      {grade: 8, userId: '123erfdjken'},
      {grade: 1, userId: '123er1fdjken'},
      {grade: 2, userId: '12a3er1fdjken'}
    ]
  });
}

export default connect(mapStateToProps, { getExamGrades })(Statistics);
