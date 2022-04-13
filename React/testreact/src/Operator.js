import React from 'react';
import './Operator.css';
// import {setState} from 'react';
import {useState} from 'react';

// class Operator extends React.Component {
//   constructor(props) {
//     super(props);
//     this.state = {
//       Email: "",
//       Password: "",
//       Text: ""
//     };
//   }
//   render() {
//     return(
//       <div className="Operator-login">
//         <label for="email"><b>Username</b></label>
//         <input type="text" placeholder="Enter Email" name="email" required onChange={(e) => this.setState({Email: e.target.value})}></input>

//         <label for="psw"><b>Password</b></label>
//         <input type="password" placeholder="Enter Password" name="psw" required onChange={(e) => this.setState({Password: e.target.value})}></input>
          
//         <button className="button-login" onClick={Login}>Login</button>
//         <button className="button-write" title={this.state.Text}></button>
//       </div>
//     );
//     function Login() {
//       setState({Text: this.state.Email + this.state.Password});
//     }
//   }
// }
// export default Operator;

function FunOperator() {
  const [user, setUser] = useState({Email:"", Password:""});
  const [text, setText] = useState("");
  function Login() {
    setText("Email: #email \n Password: #password" + user.Email + user.Password);
  }
    return(
      <div className="Operator-login">
        <label for="email"><b>Username</b></label>
        <input type="text" placeholder="Enter Email" name="email" required onChange={(e) => setUser({Email: e.target.value})}></input>

        <label for="psw"><b>Password</b></label>
        <input type="password" placeholder="Enter Password" name="psw" required onChange={(e) => setUser({Password: e.target.value})}></input>
          
        <button className="button-login" onClick={Login}>Login</button>
        <button className="button-write" title={text}></button>
      </div>
    );
}
export default FunOperator();

// function Login() {
//   window.open('https://www.google.com', '_blank')
// }
