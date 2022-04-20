import React from 'react';
import './Operator.css';
import {useState} from 'react';

function FunOperator() {
  const [user, setUser] = useState({Email:"", Password:""});
  const [text, setText] = useState({Text1:"", Text2:""});
  const [listUser, setListUser] = useState([]);

    function Login() {
        setText({Text1: "Email: " + user.Email, Text2: "Password: " + user.Password});
        setListUser([...listUser, {email: user.Email, password: user.Password}]);
    }

    // function LoginAfter() {
    //     if (user.Email !== "") {
    //     return (
    //         <div>
    //         {listUser.map((item)=>(
    //         <div>Email: {item.email}, Password: {item.password}</div>
    //         ))}
    //         </div>
    //     );
    //     }
    //     else return <div></div>
    // }

  return(
    <div className="Operator-login">
      <label for="email"><b>Username</b></label>
      <input type="text" placeholder="Enter Email" name="email" required onChange={(e) => setUser({Email: e.target.value, Password:user.Password})}></input>

      <label for="psw"><b>Password</b></label>
      <input type="password" placeholder="Enter Password" name="psw" required onChange={(e) => setUser({Password: e.target.value, Email:user.Email})}></input>
        
      <button className="button-login" onClick={Login}>Login</button>
      <button className="button-write">{text.Text1}<br />{text.Text2}<br /></button>
      {listUser.map(item =>(
          <div>Email: {item.email}, Password: {item.password}</div>
        ))}
    </div>
  );
}
export default FunOperator;
