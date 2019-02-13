import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
  <div className='exam-panel panel panel-sm'>
    <h1>Hello, Lume!</h1>
    <p>Autori:</p>
    <ul>
      <li><strong>Dani</strong></li>
      <li><strong>Gabi</strong></li>
      <li><strong>Elisei</strong></li>
      <li><strong>Vlad x2</strong></li>
    </ul>
  </div>
);

export default connect()(Home);
