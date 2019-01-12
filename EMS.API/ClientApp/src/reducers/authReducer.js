const initialState = {
    isAuthenticated: false,
    user: {}
}

export default function (state = initialState, action) {
    switch (action.type) {
        case 'SET_CURRENT_USER':
            return {
                ...state,
                isAuthenticated: action.isAuthenticated,
                user: action.user
            }
        case 'GET_ERRORS':
            return {
                ...state,
                isAuthenticated: action.isAuthenticated,
                errors: action.payload
            }
        default:
            return state;
    }
}