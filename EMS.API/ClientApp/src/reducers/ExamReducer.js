const initialState = { forecasts: [], isLoading: false };

export const reducer = (state, action) => {
    state = state || initialState;
    switch (action.type) {
        case 'GET_EXAMS':
            return {
                ...state,
                //startDateIndex: action.startDateIndex,
                exams: action.exams,
                isLoading: false
            };
        default:
            return state;
    }
};