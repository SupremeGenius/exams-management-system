import React from 'react'

import Dropdown             from './Dropdown'

class FormInputDropdown extends React.Component {
  openDropdown = () =>
    state = !this.dropdown?.state?.isOpen

    # needs a slight delay to prevent the click event from closing it
    setTimeout =>
      this.dropdown?.setState?({isOpen: state})
    , 50

  render() {
    <div
      style     = {this.props.style}
      className = {`\
        form-input-dropdown \
        ${(this.props.value || this.props.placeholder) && ' label-up' || ''} \
        ${(this.props.hasError || this.props.errors) && ' has-error' || ''} \
        ${this.props.title && ' has-title' || ''} \
        ${this.props.placeholder && !this.props.value && ' is-placeholder' || '' } \
        ${this.props.disabled && ' disabled' || '' } \
    `}>

      <label className='pointer' onClick={ (e) => this.openDropdown(); }>{this.props.title}</label>
      <Dropdown
        controlClassName = 'dropdown pointer sonar-form-control'
        placeholder      = '&nbsp;'
        arrowClassName   = { this.props.arrowClassName || 'fa fa-chevron-down' }
        refDropdown      = { (ref) => this.dropdown = ref if ref }
        {...this.props}
      />

      {
        this.props.errors ?
          <div className='errors-wrapper'>
          {
            this.props.errors[0..1].map (error, i) ->
              <div key={i} title={error} className='error-text'>{error}</div>
          }
          </div>
      }
    </div>
  }

export default FormInputDropdown
