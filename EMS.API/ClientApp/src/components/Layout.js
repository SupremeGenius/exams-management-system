import React from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import NavMenu from './NavMenu';

import '../styles/css/Layout.css'

export default props => (
  <div className='ceva'>
    <Grid fluid>
      <Row>
        <NavMenu />
      </Row>
      <Row>
        <Col className='layout__body' sm={12}>
          {props.children}
        </Col>
      </Row>
    </Grid>
  </div>
);
