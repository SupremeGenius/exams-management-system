const initialState = {}

export default function (state = initialState, action) {
    switch (action.type) {
        case "GET_ERRORS_LOGIN":
            console.log(action.payload)
            return {
                ...state,
                errors: action.payload ? action.payload : "Invalid email or password!"
            }
            break;
        default:
            return state;
    }
}