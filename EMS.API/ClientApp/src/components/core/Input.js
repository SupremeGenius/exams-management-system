import React     from 'react';

import '../../styles/css/core/Input.css'

class Input extends React.Component {
  constructor() {
    super()
    this.state = {}
    //   labelUp: this.labelShouldBeUp(),
    //   id: this.props.id || ('_' + Math.random().toString(36).substring(6))
    // }
    this.labelShouldBeUp = this.labelShouldBeUp.bind(this);

  }

  static getDerivedStateFromProps(props, state) {
    return {
      labelUp: !!(props.value || props.placeholder) || (state != null ? state.isFocused : undefined)
    }
  }

  componentDidUpdate(prevProps, prevState) {
    if ((prevProps.value !== this.props.value) || (prevProps.placeholder !== this.props.placeholder)) {
      return this.setState({labelUp: this.labelShouldBeUp()});
    }
    return this.setLabels();
  }

  componentDidMount() {
    if (this.props.autoFocus && !this.props.readOnly) { return this.inputRef.focus(); }
  }

  setLabels() {
    const labelUp = this.labelShouldBeUp();
    if (this.state.labelUp !== labelUp) { return this.setState({labelUp}); }
  }

  onKeyDown(e) {
    // handle enter
    if (e.keyCode === 13) {
      // act as single input unless multiline specified
      if (!this.props.multiline && (this.props.maxRows !== 1)) { e.preventDefault(); }

      if (this.props.preventSubmitOnEnter) {
        e.preventDefault();
        return false;
      }

      // allow for enter handling by the parent
      return (typeof this.props.onEnterPress === 'function' ? this.props.onEnterPress(e) : undefined);
    }
  }

  labelShouldBeUp = () => {
    return !!(this.props.value || this.props.placeholder) || (this.state != null ? this.state.isFocused : undefined);
  }

  render() {
    return <div
      style     = {this.props.style}
      className = {`\
        form-input-text \
        ${ this.props.className || '' } \
        ${ (this.state.labelUp   && ' label-up')  || '' } \
        ${ (this.props.title     && ' has-title') || '' } \
        ${ ((this.props.hasError || this.props.errors) && ' has-error') || '' } \
        ${ (this.props.readOnly  && ' read-only') || '' }`}
        >
          {
            this.props.title ?
              <label htmlFor={`${this.state.id}`}>{(this.state.labelUp && this.props.titleUp) || this.props.title}</label> : undefined
          }
          <input
            id           = { this.state.id }
            value        = { this.props.value || '' }
            onFocus      = { e => { if (typeof this.props.onFocus === 'function') {
              this.props.onFocus(e);
            } return this.setState({isFocused: true}); } }
            onBlur       = { e => { if (typeof this.props.onBlur === 'function') {
              this.props.onBlur(e);
            } return this.setState({isFocused: false}); } }
            placeholder  = { this.props.placeholder }
            onChange     = { e => (typeof this.props.onChange === 'function' ? this.props.onChange(e.target.value, e) : undefined) }
            className    = "common-input form-control"
            style        = { this.props.inputStyle }
            onKeyDown    = { e => this.onKeyDown(e) }
            type         = { this.props.type || "text"}
            readOnly     = { this.props.readOnly }
            maxLength    = { (this.props.hardLimit && this.props.maxLength) || null }
            autoComplete = {this.props.autoComplete}
          />
        </div>;
      }
    }


export default Input
