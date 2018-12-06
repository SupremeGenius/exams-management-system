import { combineReducers } from 'redux'
import * as CounterReducer from './CounterReducer';
import * as WeatherReducer from './WeatherForecastsReducer';
import { routerReducer } from 'react-router-redux';


/*
 * We combine all reducers into a single object before updated data is dispatched (sent) to store
 * Your entire applications state (store) is just whatever gets returned from all your reducers
 * */

const reducers = combineReducers({
    counter: CounterReducer.reducer,
    weather: WeatherReducer.reducer,
    routing: routerReducer
})
    
export default reducers