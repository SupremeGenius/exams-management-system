import React     from 'react';

import '../../styles/css/core/Logo.css'

class Logo extends React.Component {

  render() {
    return (
      <span className='logo'>
        <span className='logo__acronym'>E</span>
        <span className='logo__acronym--text'>xams</span>
        <span className='logo__acronym'>M</span>
        <span className='logo__acronym--text'>anagment</span>
        <span className='logo__acronym'>S</span>
        <span className='logo__acronym--text'>ystem</span>
      </span>
    );
  }
}

export default Logo;
