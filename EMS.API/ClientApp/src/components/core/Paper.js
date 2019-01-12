import React     from 'react';
import classnames from 'classnames'
import '../../styles/css/core/Paper.css'

class Paper extends React.Component {

  render() {
    const { style, className } = this.props

    return (
      <div className={classnames('paper', className)} style={style}>
        {this.props.children}
      </div>
    );
  }
}

export default Paper;
