import axios from "axios"
import setAuthToken from "../utils/setAuthToken";

export const loginUser = (userData, history) => dispatch => {
    userData.role = "professor"
   
    axios
        .post("/api/login", userData)
        .then(result => {
            dispatch({
                type: 'SET_CURRENT_USER',
                user: {},
                isAuthenticated: true
            })
        })
        .catch(error =>
            dispatch({
                type: 'GET_ERRORS',
                payload: error.response.data
            })
        );
         /*
    dispatch({
        type: 'SET_CURRENT_USER',
        user: {},
        isAuthenticated: true
    })
       */
};

// Log out user
export const logoutUser = () => dispatch => {
    // Remove token from local storage
    localStorage.removeItem('jwtToken');
    // Remove auth header for future requests
    setAuthToken(false);
    // Set current user to {} which will set isAuthenticated to false
    return {
        type: 'SET_CURRENT_USER',
        user: {},
        isAuthenticated: false
    }
}