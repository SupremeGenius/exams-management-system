import React, { Component } from 'react';
import { Route, Switch }    from 'react-router';

import Layout  from './components/Layout';
import Home    from './components/Home';
import Settings    from './components/Settings';
import SignUp  from './components/SignUp';
import SignIn  from './components/SignIn';
import SignOut  from './components/SignOut';
import Courses from './components/Courses';
import {Course} from './components/Courses';
import Exams from './components/Exams';
import QRCode from './components/QRCode';


import ROUTES from './constants/routes'

if (localStorage.jwtToken) {
  // Set auth token header auth
  //setAuthTokenApp(localStorage.jwtToken);
  //store.dispatch(setCurrentUser(jwt_decode(localStorage.jwtToken)));
}

class App extends Component {
    render() {
        return (
            <Switch>
                <Route exact path={ROUTES.SIGN_IN} component={SignIn} />
                <Route exact path={ROUTES.SIGN_UP} component={SignUp} />
                <Route exact path={ROUTES.SIGN_OUT} component={SignOut} />
                <Layout>
                    <Route exact path={ROUTES.SCAN} component={QRCode} />
                    <Route exact path='/' component={Home} />
                    <Route exact path={ROUTES.COURSES} component={Courses} />
                    <Route exact path={ROUTES.ACCOUNT} component={Settings} />
                    <Route exact path={ROUTES.COURSE} component={Course} />
                    <Route exact path={ROUTES.EXAMS} component={Exams} />
                </Layout>
            </Switch>
        )
    }
}

export default App;
