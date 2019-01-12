import React from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';
import ROUTES from '../constants/routes'

export default props => (
    <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
            <Navbar.Brand>
                <Link to={'/'}>exams_management_system</Link>
            </Navbar.Brand>
            <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
            <Nav>
                <LinkContainer to={ROUTES.EXAMS}>
                    <NavItem>
                        <Glyphicon glyph='th-list' /> Exams
          </NavItem>
        </LinkContainer>
        <LinkContainer to={ROUTES.SIGN_OUT}>
                    <NavItem>
                        <Glyphicon glyph='th-list' /> Sign Out
          </NavItem>
                </LinkContainer>
            </Nav>
        </Navbar.Collapse>
    </Navbar>
);
