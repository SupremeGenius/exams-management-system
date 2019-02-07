const initialState = {
    user: []
}

export default function (state = initialState, action) {
    switch (action.type) {
        case 'GET_USER':
            return {
                ...state,
                user: action.user
            }
        case 'GET_ERRORS_USER':
            return {
                ...state,
                errors: action.payload
            }
        default:
            return state;
    }
}