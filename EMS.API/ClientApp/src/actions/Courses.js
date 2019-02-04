import axios from "axios"

export const getCourses = () => dispatch => {
    axios
        .get("/api/v1/courses")
      .then(result => {
            dispatch({
                type: 'GET_COURSES',
                courses: result.data
            })
        })
        .catch(error => {
            dispatch({
                type: 'GET_ERRORS_COURSES',
                payload: error.response.data
            })
        });

};