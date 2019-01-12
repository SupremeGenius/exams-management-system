import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
  <div>
    <h1>Hello, persoana academica!</h1>
  </div>
);

export default connect()(Home);
