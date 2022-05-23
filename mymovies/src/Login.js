import React, { useEffect } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';

import "./App.css";
import App from './App';
import { useState } from "react";
import {variables} from './Variables.js';
import Register from './Register';

import cards from "./Table.module.css";


function Login() {
  
    const onSubmit = (username) => {
      
        document.getElementById('root').innerHTML = "";
        const root = ReactDOM.createRoot(document.getElementById('root'));
        localStorage.setItem("user" ,username);
        root.render(<App username ={username} />);
        
      }

  const [username, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [message, setMessage] = useState("");

  let handleSubmit = async (e) => {
    e.preventDefault();
    try {
      let res = await fetch(variables.LOGIN_URL, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            UserName: username,
            Password: password
        }),
      });
      let resJson = await res.json();
      if (resJson) {
        setUserName("");
        setPassword("");
        // setMessage("ana sayfaya yönlendir");
       
        onSubmit(username);
      } else {
       
        setMessage("kullanıcı adı yada şifre yanlış");
      }
    } catch (err) {
      console.log(err);
    }
  };

  const RegisterPage = () => {
         
    document.getElementById('root').innerHTML = "";
    const root = ReactDOM.createRoot(document.getElementById('root'));
    root.render(<Register/>);
    
  }

  return (

    <div className='Login'>
   
      <div className={`row ${cards.loginBackgroundImg} ${cards.letter}`}>
        <div className={`col-12 col-sm-6 col-md-4 col-lg-4  `}>
          
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="exampleInputEmail1">Kullanıcı Adı</label>
            <input  className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"  type="text"
                  value={username}
                  placeholder="UserName"
                  onChange={(e) => setUserName(e.target.value)}/>
            
          </div>
          <div className="form-group">
            <label htmlFor="exampleInputPassword1">Şifre</label>
            <input  className="form-control" id="exampleInputPassword1"   type="password"
                  value={password}
                  placeholder="Password"
                  onChange={(e) => setPassword(e.target.value)}/>
                  <small className="form-text text-muted message">{message ? <p>{message}</p> : null}</small>
          </div>
          <br></br>
          <button className={`col-12 btn btn-primary`} type="submit">Giriş Yap</button>
          <br></br>
          <div className={`col-12 btn btn-disable`} onClick={RegisterPage}>Kayıt Ol</div>

        </form>
        </div>
        
      </div>
      
    </div>

  );
}

export default Login;