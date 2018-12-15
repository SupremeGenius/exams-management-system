import React    from 'react';

import Dropdown from './Dropdown';

import '../../styles/css/core/InputDropdown.css'

class InputDropdown extends React.Component {
  openDropdown() {
    const state = !this.dropdown.state.isOpen
    // needs a slight delay to prevent the click event from closing it
    return setTimeout(() => {
      this.dropdown.setState({isOpen: state});
    } , 50);
  }

  render() {
    return <div
        style     = {this.props.style}
        className = {`\
          form-input-dropdown \
          ${(this.props.className && this.props.className) || ''} \
          ${((this.props.value || this.props.placeholder) && ' label-up') || ''} \
          ${((this.props.hasError || this.props.errors) && ' has-error') || ''} \
          ${(this.props.title && ' has-title') || ''} \
          ${(this.props.isSmall && ' size-s') || '' } \
          ${(this.props.placeholder && !this.props.value && ' is-placeholder') || '' } \
          ${(this.props.isWhite && !this.props.hasError && ' white') || '' } \
          ${(this.props.disabled && ' disabled') || '' }\
        `}>

        <label className='pointer' onClick={ e => this.openDropdown() }>{this.props.title}</label>

        <Dropdown
          controlClassName = 'dropdown pointer form-control'
          placeholder      = '&nbsp;'
          arrowClassName   = { this.props.arrowClassName || 'fa fa-chevron-down' }
          refDropdown      = { ref => { if (ref) { return this.dropdown = ref; } } }
          {...this.props}
        />

        {
          this.props.errors ?
            <div className='errors-wrapper'>
            {
              this.props.errors.slice(0, 2).map(function(error, i) {
                return <div key={i} title={error} className='error-text'>{error}</div>;
              })
            }
            </div> : undefined
        }
      </div>
  }
}

export default InputDropdown
