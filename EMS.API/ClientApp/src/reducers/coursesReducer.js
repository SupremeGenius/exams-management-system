const initialState = {
    exams: []
}

export default function (state = initialState, action) {
    switch (action.type) {
      case 'GET_COURSES':
            return {
                ...state,
                courses: action.courses
            }
       case 'GET_ERRORS_COURSES':
            return {
                ...state,
                errors: action.payload
            }
        default:
            return state;
    }
}