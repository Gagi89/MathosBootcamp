import React from 'react';
import './Operator.css';

class Operator extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Email: "",
      Password: "",
      Text1: "",
      Text2: "",
      List: []
    };
    // this.Login = this.Login.bind(this)
  }
  Login =()=> {
    this.setState({Text1: "Email: " + this.state.Email, Text2: "Password: " + this.state.Password});
    this.setState({List: [{email: this.state.Email, password: this.state.Password}]});
  };
  render() {
    return(
      <div className="Operator-login">
        <label for="email"><b>Username</b></label>
        <input type="text" placeholder="Enter Email" name="email" required onChange={(e) => this.setState({Email: e.target.value})}></input>

        <label for="psw"><b>Password</b></label>
        <input type="password" placeholder="Enter Password" name="psw" required onChange={(e) => this.setState({Password: e.target.value})}></input>
          
        <button className="button-login" onClick={this.Login}>Login</button>
        <button className="button-write">{this.state.Text1}<br />{this.state.Text2}</button>
        {this.state.List.map(item =>(
            <div>Email: {item.email}, Password: {item.password}</div>
          ))}
      </div>
    );
  }
}
export default Operator;

// function Login() {
//   window.open('https://www.google.com', '_blank')
// }
