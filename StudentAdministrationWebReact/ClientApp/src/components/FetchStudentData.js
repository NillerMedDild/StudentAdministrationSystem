import React, { Component } from 'react';
import { connect } from 'react-redux';

//TODO: This needs to get data from the webapi, see https://jonhilton.net/connecting-react-to-asp-net-core-web-api/

class FetchStudentData extends Component {
  componentWillMount() {
    // This method runs when the component is first added to the page
  }

  render() {
    return (
      <div>
        <h1>Students</h1>
        {renderStudentsTable(this.props)}
      </div>
    );
  }
}

function renderStudentsTable(props) {
  return (
    <table className='table'>
      <thead>
        <tr>
          <th>Name</th>
          <th>Address(C)</th>
          <th>Email(F)</th>
          <th>Phonenumber</th>
        </tr>
      </thead>
      <tbody>
        {props.students.map(student =>
        <tr key={student.name}>
            <td>{student.name}</td>
            <td>{student.address}</td>
            <td>{student.email}</td>
            <td>{student.phonenumber}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

export default connect()(FetchStudentData);
