import React, { Component } from 'react';
import { Route, Switch }    from 'react-router';

import Layout               from './components/Layout';
import Home                 from './components/Home';
import SignUp               from './components/SignUp';
import SignIn               from './components/SignIn';
//import SignOut               from './components/SignOut';

import ROUTES               from './constants/routes'

class App extends Component {
    render() {
        return (
            <Switch>
                <Route exact path={ROUTES.SIGN_IN} component={SignIn} />
                <Route exact path={ROUTES.SIGN_UP} component={SignUp} />
                <Route exact path={ROUTES.SIGN_OUT} component={SignIn} />
                <Layout>
                    <Route exact path='/' component={Home} />
                </Layout>
            </Switch>
        )
    }
}

export default App;
