import React, { Component } from 'react';
import { Route, Switch }    from 'react-router';

import Layout  from './components/Layout';
import Home    from './components/Home';
import SignUp  from './components/SignUp';
import SignIn  from './components/SignIn';
import Courses from './components/Courses';
import Exams   from './components/Exams';

import ROUTES  from './constants/routes'

class App extends Component {
    render() {
        return (
            <Switch>
                <Route exact path={ROUTES.SIGN_IN} component={SignIn} />
                <Route exact path={ROUTES.SIGN_UP} component={SignUp} />
                <Route exact path={ROUTES.SIGN_OUT} component={SignIn} />
                <Layout>
                    <Route exact path='/' component={Home} />
                    <Route exact path={ROUTES.COURSES} component={Courses} />
                    <Route exact path={ROUTES.EXAMS} component={Exams} />
                </Layout>
            </Switch>
        )
    }
}

export default App;
