const initialState = { forecasts: [], isLoading: false };

export const reducer = (state, action) => {
    state = state || initialState;
    switch (action.type) {
        case 'REQUEST_WEATHER_FORECASTS':
            return {
                ...state,
                startDateIndex: action.startDateIndex,
                isLoading: true
            };
        case 'RECEIVE_WEATHER_FORECASTS':
            console.log('-----')
            console.log(action)
            return {
                ...state,
                startDateIndex: action.startDateIndex,
                forecasts: action.forecasts,
                isLoading: false
            };
        default:
            return state;
    }
};