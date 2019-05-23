import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Glyphicon } from 'react-bootstrap';

import './PrivacyPolicy.css'

class PrivacyPolicy extends Component {
    render() {
        return <div class="privacy-policy">
            <Glyphicon glyph="info-sign" />
        <a href="https://www.iubenda.com/privacy-policy/25931141" target="popup" title="Privacy Policy " >
        Privacy Policy
        </a>
      </div>
    }
}

export default connect() (PrivacyPolicy);