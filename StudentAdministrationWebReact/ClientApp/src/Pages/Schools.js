import React, { Component } from 'react';
import { connect } from 'react-redux';

// Currently not functional, it appears that the state.items array isn't being set to anything.
class Students extends Component {
    state = {
      error: null,
      isLoaded: false,
      items: []
    };
  
  async componentDidMount() {
    await fetch('https://localhost:44304/api/Schools')
    .then(res => res.json())
    .then(
      (result) => {
        this.setState({
          isLoaded: true,
          items: result
        });
      },
      //TODO: Error handling for Fetch
      // Note: it's important to handle errors here
      // instead of a catch() block so that we don't swallow
      // exceptions from actual bugs in components.
      (error) => {
        this.setState({
          isLoaded: true,
          error
        });
      }
    )
}

render() {const { error, isLoaded, items } = this.state;
  if (error || items == null) {
    return <div>Error: {error.message}</div>;
  } else if (!isLoaded) {
    return <div>
      <h1>Schools</h1>
      Loading...</div>;
  } else {
    return <div>
      <h1>Schools</h1>
      {renderSchoolsTable(this.state)}
    </div>
    } 
  }
}

function renderSchoolsTable(props) {
  return (
    <table className='table'>
      <thead>
        <tr>
          <th>Name</th>
          <th>Address</th>
        </tr>
      </thead>
      <tbody>
        {props.items.map(school =>
        <tr key={school.id}>
            <td>{school.name}</td>
            <td>{school.address}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

export default connect()(Students);
