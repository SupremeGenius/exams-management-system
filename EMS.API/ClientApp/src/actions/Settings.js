import axios from "axios"

export const getUserInfo = () => dispatch => {
  axios
    .get("/api/v1/users/CFEA50D1-DE8E-4A07-5B0B-08D67B8AA36B")
    .then(result => {
      console.log(result)
      dispatch({
        type: 'GET_USER',
        user: result.data
      })
    })
    .catch(error => {
      dispatch({
        type: 'GET_ERRORS_USER',
        payload: error.response.data
      })
    });

};