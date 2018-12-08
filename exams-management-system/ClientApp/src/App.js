import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Login from './components/LoginPage/Login';
import setAuthTokenApp from "./utils/setAuthToken";


// Check for auth token
if (localStorage.jwtToken) {
    // Set auth token header auth
    setAuthTokenApp(localStorage.jwtToken);
}

class App extends Component {
    render() {
        return (
            <Switch>
                <Route exact path='/login' component={Login} />
                <Route exact path='/register' component={Login} />
                <Layout>
                    <Route exact path='/' component={Home} />
                    <Route path='/counter' component={Counter} />
                    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
                </Layout>
            </Switch>
        )
    }
}

export default App;
