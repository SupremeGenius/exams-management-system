const initialState = {
    exams: []
}

export default function (state = initialState, action) {
    switch (action.type) {
        case 'GET_EXAMS':
            return {
                ...state,
                exams: action.exams
            }
         case 'GET_ERRORS_EXAMS':
            return {
                ...state,
                errors: action.payload
            }
        default:
            return state;
    }
}