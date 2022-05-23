import './App.css';
import {Navbar} from './Components/Navbar';
import  { useState, useEffect } from 'react';
import Login from './Login';

function App(props) {
  const [loggedIn, setLoggedIn] = useState(null);

  useEffect(() => {
    const loggedUser = localStorage.getItem('user');
    setLoggedIn(Boolean(loggedUser));
   
  }, []);
  

   if(loggedIn){
     return(<Navbar username ={props.username} />)
      
   }else{
      return(<Login/>)
    }
 
}

export default App;
