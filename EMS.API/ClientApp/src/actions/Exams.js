import axios from "axios"

export const getExams = () => dispatch => {
    axios
        .get("/api/v1/exams")
      .then(result => {
            dispatch({
                type: 'GET_EXAMS',
                exams: result.data
            })
        })
        .catch(error => {
            dispatch({
                type: 'GET_ERRORS_EXAMS',
                payload: error.response.data
            })
        });

};