import React, { Component } from 'react';
import { connect } from 'react-redux';

class Home extends Component {
  render() {
    return <div>
      <h1>Welcome to Better Learning!</h1>
      <p>Please use the navigation bar on the left to browse the website.</p>
    </div>
  }
}


export default connect()(Home);
