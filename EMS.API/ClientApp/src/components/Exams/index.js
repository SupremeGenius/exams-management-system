import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../../actions/Exams';

class Exams extends Component {
  componentWillMount() {
        // This method runs when the component is first added to the page
        const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    //componentWillReceiveProps(nextProps) {
    //    // This method runs when incoming props (e.g., route params) change
    //    const startDateIndex = parseInt(nextProps.match.params.startDateIndex, 10) || 0;
    //    this.props.requestWeatherForecasts(startDateIndex);
    //}

    render() {
        return (
            <div>
                <h1>Exams</h1>
                {ExamsTable(this.props)}
                {renderPagination(this.props)}
            </div>
        );
    }
}

function ExamsTable(props) {
    return (
        <table className='table'>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
        </table>
    );
}

function renderPagination(props) {
    const prevStartDateIndex = (props.startDateIndex || 0) - 5;
    const nextStartDateIndex = (props.startDateIndex || 0) + 5;

    return <p className='clearfix text-center'>
        <Link className='btn btn-default pull-left' to={`/fetchdata/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/fetchdata/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.weather,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Exams);