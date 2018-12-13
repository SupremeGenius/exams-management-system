import React    from 'react';
import { Link } from 'react-router-dom';

import ROUTES               from '../../constants/routes';

const SignUpLink = () => (
    <p>
        Already have an account? <Link to={ROUTES.SIGN_IN}>Sign In</Link>
  </p>
);

export default SignUpLink;
