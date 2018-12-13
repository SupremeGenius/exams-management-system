import React     from 'react';

class Button extends React.Component {

    render() {
    return (
      <button className='button'>
        {this.props.children}
      </button>
    );
  }
}

export default Button;
