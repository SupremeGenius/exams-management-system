import axios from "axios"

export const loginUser = (userData, history) => dispatch => {
    axios
        .post("/api/login", userData)
        .then(result => {
            dispatch({
                type: 'SET_CURRENT_USER',
                user: { id: result.id },
                isAuthenticated: true
            })
        })
        .catch(error => {
            dispatch({
                type: 'GET_ERRORS_LOGIN',
                payload: error.response.data
            })
        });

};

// Log out user
export const logoutUser = () => dispatch => {

    dispatch({
        type: 'SET_CURRENT_USER',
        user: {},
        isAuthenticated: false
    })
}