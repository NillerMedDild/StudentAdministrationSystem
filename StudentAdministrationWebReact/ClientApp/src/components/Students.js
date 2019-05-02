import React, { Component } from 'react';
import { connect } from 'react-redux';

class Students extends Component {
  state = {
    "students": []
};
  async componentDidMount() {
    const result = await fetch('https://localhost:44304/api/students');
    const students = await result.json();
    this.setState({ students:students });
    console.log(students);
}

  render() {
    return (
      <div>
        <h1>Students</h1>
        {renderStudentsTable(this.state)}
        <div>>
        <button onClick={() => getStudents()}>Reload Students</button>
      </div>
      </div>
    );
  }
}

function renderStudentsTable(props) {
  return (
    <table className='table'>
      <thead>
        <tr>
          <th>Id</th>
          <th>Name</th>
        </tr>
      </thead>
      <tbody>
        {props.students.map(student =>
        <tr key={student.id}>
            <td>{student.name}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

async function getStudents() {
  const result = await fetch('https://localhost:44304/api/students');
  const students = await result.json();
  this.setState({ students });
}

export default connect()(Students);
