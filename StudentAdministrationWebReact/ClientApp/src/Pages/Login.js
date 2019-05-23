import React, { Component } from 'react';
import { connect } from 'react-redux';
import SignInScreen from '../Components/SignInScreen'

class Home extends Component {
  render() {
    return <div>
      <SignInScreen/>
    </div>
  }
}


export default connect()(Home);
