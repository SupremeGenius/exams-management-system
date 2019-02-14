import axios from "axios"

export const getExams = () => dispatch => {
    axios
      .get("/api/v1/students/263AA508-4C70-4920-BC49-94837057D264/exams")
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