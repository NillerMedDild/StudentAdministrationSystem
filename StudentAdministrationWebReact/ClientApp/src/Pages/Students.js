import React, { Component } from 'react';
import { connect } from 'react-redux';

class Students extends Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
  }
};

async componentDidMount() {
  await fetch('https://localhost:44304/api/Students')
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
      <h1>Students</h1>
      Loading...</div>;
  } else {
    return <div>
      <h1>Students</h1>
      {renderStudentsTable(this.state)}
    </div>
    } 
  }
}

function renderStudentsTable(props) {
  return (
    <table className='table'>
      <thead>
        <tr>
          <th>Name</th>
          <th>Address</th>
        </tr>
      </thead>
      <tbody>
        {props.items.map(student =>
        <tr key={student.id}>
            <td>{student.name}</td>
            <td>{student.address}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

export default connect()(Students);
