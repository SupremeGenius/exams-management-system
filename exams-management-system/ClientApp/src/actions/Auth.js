import axios from "axios"
import setAuthToken from "../utils/setAuthToken";

export const loginUser = (userData, history) => dispatch => {

    axios
        .post("/api/oauth2/token", userData)
        .then(result => {
            localStorage.setItem('jwtToken', result.data.token_type + " " + result.data.access_token);
            setAuthToken(result.data.access_token, result.data.token_type);
            history.push("/");
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