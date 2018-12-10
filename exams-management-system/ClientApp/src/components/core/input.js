import React     from 'react';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';

const styles = theme => ({
  container: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  textField: {
    marginLeft: theme.spacing.unit,
    marginRight: theme.spacing.unit,
    width: 300,
    fontSize: 30,
  },
  dense: {
    marginTop: 19,
  },
  menu: {
    width: 200,
  },
  resize:{
    fontSize:50
  },
});

class Input extends React.Component {

  render() {
    const { classes, value, label, type } = this.props;

    return (
      <TextField
        value = {value}
        label = {label}
        type = {type}
        className={classes.textField}
        margin="normal"
      />
    );
  }
}

Input.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Input);
