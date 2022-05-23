// import React from 'react'
import React,{Component} from "react"; 

import '../App.css';
import ReactDOM from 'react-dom/client';
import {Home} from './Home';
import {Favorite} from './Favorite';
import Login from "../Login";
import {BrowserRouter, Routes,Route,Navigate ,NavLink} from 'react-router-dom';
import cards from "../Table.module.css";
import {Search} from './Search';
import App from '../App';

export class Navbar extends Component{
    constructor(props){
      
        super(props);
        
          this.state={
            isLogin:true
        }
        
    }
   
    logOut(e){
        e.preventDefault();
        
        this.setState({isLogin:false}); 
        localStorage.removeItem('user');
       
      }


    render(){

        const{
            isLogin
        }=this.state;
       
      if (this.state.isLogin){
        return (

        
            <BrowserRouter>
    
            <header>
            
           
            <nav className={`navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white  box-shadow m-2 mb-3 ${cards.backColor} ${cards.textAlignCenter}`}>
                <div className="container-fluid">
                    <a className="navbar-brand"><NavLink  className="nav-link text-white" to="/home" >Ana Sayfa</NavLink></a>
                    <a className="navbar-brand"><NavLink className="nav-link text-white" to="/favorite" >Favorilerim</NavLink></a>
                    <a className="navbar-brand"> <Search username ={this.props.username}/></a>
                    <a className="navbar-brand"><a className="nav-link text-white">{this.props.username}</a></a>
                    <a className="navbar-brand"><a className="nav-link text-white" onClick={(e) =>  this.logOut(e)}><i className="fa-solid fa-arrow-right-from-bracket"></i></a></a>
                    
                  
                </div>
            </nav>
            
            
            </header>
            
            <Routes>
         
            <Route exact path="/" render={() => (
                this.state.isLogin== true ? (
                    <Navigate  to="/app" element={<App username ={this.props.username} />}/>
                    
                ) : (
                  <Login/>
                )
              )}/>
    
            <Route exact path="/favorite" element={<Favorite username ={this.props.username}/>}></Route>
          
            <Route exact path="/home" element={<Home username ={this.props.username} />}></Route>
          
            </Routes>
    
            </BrowserRouter>
        )
      }else{
            return(
                <Login/>
            )
      }
    
        
    }

   
    
}

