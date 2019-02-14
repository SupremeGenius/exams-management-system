import axios from "axios"

export const getExamGrades = () => dispatch => {
    axios
    .get("/api/v1/exams/examId/grades")
    .then(result => {
      dispatch({
        type: 'GET_EXAM_GRADES',
        examGrades: result.data
      })
    })
    .catch(error => {
      dispatch({
        type: 'GET_ERRORS_EXAMS_GRADES',
        payload: error.response.data
      })
    });
};
