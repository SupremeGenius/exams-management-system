import React from 'react';

import Input from '../core/Input'
import Button from "@material-ui/core/Button";
import Variables from '../../constants/variables';

import { getUserInfo } from '../../actions/Settings'

import { connect } from "react-redux";


const INITIAL_STATE = {
  fullName: 'Gigel Stroe',
  email: 'gigel.stroethis.gmail.com',
  group: 'I3A4',
  registrationNumber: '1278312873612SL',
  professorTitle: 'Conf. Dr.',
  error: null,
  // role: 'Professor',
  role: 'Student',
};

class SettingsDetails extends React.Component {

  componentWillMount() {
    this.props.getUserInfo();
  }
  constructor(props) {
    super(props);

    this.state = {
      ...INITIAL_STATE,
    };
  }

  onChange = (value, key) => {
    this.setState({
      [key]: value,
    });
    this.props.user[key] = value
  };


  onSubmit = (e) => {
    e.preventDefault()
    console.log(e);
  }

  render() {
    return (
      <div className="settings-details">
        <form onSubmit={this.onSubmit}>
          <Input
            title='Nume Complet'
            value={this.props.user.fullName}
            name='fullName'
            onChange={(v) => this.onChange(v, 'fullName')}
          />

          <Input
            title='Email'
            value={this.props.user.email}
            name='email'
            readOnly={this.props.user.role === Variables.studentRole}
          />

          {(() => {
            switch (this.props.user.role) {
              case Variables.studentRole:
                return (
                  <React.Fragment>
                    <Input
                      title='Numar Matricol'
                      value={this.props.user.registrationNumber}
                      name='registrationNumber'
                      readOnly={true}
                    />

                    <Input
                      title='Grupa'
                      value={this.props.user.group}
                      name='group'
                      readOnly={true}
                    />
                  </React.Fragment>
                );
              case Variables.professorRole:
                return <Input
                  title='Titlu'
                  value={this.props.user.professorTitle}
                  name='professorTitle'
                />;
              default: return null;

            }
          })()}

          <Button
            className="settings-details__submit pull-right"
            variant="contained"
            color="primary"
            size="large"
            type='submit'
            style={{ marginTop: "30px", backgroundColor: '#0075ff' }}> Salveaza Modificarile
        </Button>
        </form>
      </div>
    )
  }
}

const mapStateToProps = state => ({
  user: state.user.user
});

export default connect(mapStateToProps, { getUserInfo })(SettingsDetails);
