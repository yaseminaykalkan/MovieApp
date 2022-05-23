import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';

import "./App.css";
import Login from './Login';
import { useState } from "react";
import {variables} from './Variables.js';

import cards from "./Table.module.css";


function Register() {
    
    const onSubmit = () => {
         
        document.getElementById('root').innerHTML = "";
        const root = ReactDOM.createRoot(document.getElementById('root'));
        root.render(<Login />);
        
      }

  const [username, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [mail, setMail] = useState("");
  const [message, setMessage] = useState("");

  let handleSubmit = async (e) => {
    debugger;
    e.preventDefault();
    try {
      let res = await fetch(variables.REGISTER_URL, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            UserName: username,
            Mail:mail,
            Password: password
        }),
      });
      let resJson = await res.json();
      if (resJson.succ) {
        setUserName("");
        setPassword("");
        setMail("");
        setMessage("ana sayfaya yönlendir");
        onSubmit();
      } else {
        
        resJson.result.forEach(element => {
          setMessage(element.Description);
        });
        
      }
    } catch (err) {
      console.log(err);
    }
  };

  return (

    <div className="Register">
      
   <div className={`row ${cards.loginBackgroundImg} ${cards.letter}`}>
     <div className={`col-12 col-sm-6 col-md-4 col-lg-4  `}>
       
     <form onSubmit={handleSubmit}>
       <div className="form-group">
         <label htmlFor="exampleInputEmail3">Kullanıcı Adı</label>
         <input  className="form-control" id="exampleInputEmail3" aria-describedby="emailHelp"  type="text"
               value={username}
               placeholder="UserName"
               onChange={(e) => setUserName(e.target.value)}/>
         
       </div>
       <div className="form-group">
         <label htmlFor="exampleInputEmail2">e-Mail</label>
         <input  className="form-control" id="exampleInputEmail2"   type="text"
               value={mail}
               placeholder="Mail"
               onChange={(e) => setMail(e.target.value)}/>
         
       </div>
       <div className="form-group">
         <label htmlFor="exampleInputPassword2">Şifre</label>
         <input  className="form-control" id="exampleInputPassword2"   type="password"
               value={password}
               placeholder="Password"
               onChange={(e) => setPassword(e.target.value)}/>
               <small className="form-text text-muted message">{message ? <p>{message}</p> : null}</small>
       </div>
       <br></br>
       <button className={`col-12 btn btn-primary`} id="a" type="submit">Kayıt Ol</button>
      

     </form>
     </div>
     
   </div>
   
 

    </div>

  );
}

export default Register;