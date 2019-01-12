import { combineReducers } from 'redux'
import * as CounterReducer from './CounterReducer';
import * as ExamReducer from './ExamReducer';
import { routerReducer } from 'react-router-redux';
import authReducer from './authReducer';
import errorReducer from "./errorReducer";


/*
 * We combine all reducers into a single object before updated data is dispatched (sent) to store
 * Your entire applications state (store) is just whatever gets returned from all your reducers
 * */

const reducers = combineReducers({
    counter: CounterReducer.reducer,
    weather: ExamReducer.reducer,
    routing: routerReducer,
    auth: authReducer,
    errors: errorReducer
})
    
export default reducers