import React, { Component } from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Login from './components/LoginPage/Login';

class App extends Component {
    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route exact path='/login' component={Login} />
                <Route path='/counter' component={Counter} />
                <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
            </Layout>
        )
    }
}

export default App;
