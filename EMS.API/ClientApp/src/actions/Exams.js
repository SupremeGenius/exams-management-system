import axios from 'axios'

export const actionCreators = {
    requestWeatherForecasts: startDateIndex => async (dispatch, getState) => {
        if (startDateIndex === getState().weather.startDateIndex) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
      }
      axios
        .get("/api/v1/exams")
        .then(result => {
          console.log(result)
          dispatch({
            type: 'GET_EXAMS',
            exams: result,
          })
        })
        .catch(error => {
          console.log(error)
        });
        
    }
};