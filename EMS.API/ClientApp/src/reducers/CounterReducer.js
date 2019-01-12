/*
 * All reducers get two parameters passed in, state and action that occurred
 *       > state isn't entire apps state, only the part of state that this reducer is responsible for
 * */

const initialState = { count: 0 };

export const reducer = (state, action) => {
    state = state || initialState;
    switch (action.type) {
        case 'INCREMENT_COUNT':
            return { ...state, count: state.count + 1 };
        case 'DECREMENT_COUNT':
            return { ...state, count: state.count - 1 };    
        default:
            
    }
    return state;
}