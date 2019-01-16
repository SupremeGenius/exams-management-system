import React from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import '../styles/css/NavMenu.css'

import ROUTES from '../constants/routes'

export default props => (
    <Navbar staticTop collapseOnSelect>
        <Navbar.Header>
            <Navbar.Brand>
                <Link to={'/'}>StudNet</Link>
            </Navbar.Brand>
            <Navbar.Toggle />
        </Navbar.Header>
        <Nav className='nav-menu'>
          <Nav className='pull-left'>
            <LinkContainer to={ROUTES.COURSES}>
              <NavItem>
                <Glyphicon glyph='book' /> Courses
              </NavItem>
            </LinkContainer>
            <LinkContainer to={ROUTES.EXAMS}>
              <NavItem>
                <Glyphicon glyph='book' /> Exams
              </NavItem>
            </LinkContainer>
          </Nav>
          <Nav className='pull-right'>
            <LinkContainer to={ROUTES.SIGN_IN}>
              <NavItem>
                <Glyphicon glyph='log-in' /> Sign In
              </NavItem>
            </LinkContainer>
            <LinkContainer to={ROUTES.SIGN_UP}>
              <NavItem>
                <Glyphicon glyph='new-window' /> Sign Up
              </NavItem>
            </LinkContainer>
            <LinkContainer to={ROUTES.SIGN_OUT}>
              <NavItem>
                <Glyphicon glyph='log-out' /> Sign Out
              </NavItem>
            </LinkContainer>
          </Nav>
        </Nav>
    </Navbar>
);
