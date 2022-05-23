import React,{Component} from "react";  

import {variables} from '../Variables';
import cards from "../Table.module.css";

export class Favorite extends Component{
   
    constructor(props){
      
        super(props);
        
          this.state={
            myFavorites:[]
        }
        
    }

    refreshList(){
      
        fetch(variables.GETMYFAVORITELIST  + this.props.username).then(response => response.json())
        .then(data => {
            this.setState({myFavorites:data});
        });
      
       
    }

    componentDidMount(){
        this.refreshList();
    }

 
    removeFavorites(e,movieId){
      e.preventDefault();

      fetch(variables.REMOVEFROMFAVORITE  + movieId).then(response => response.json())
      .then(data => {
        this.refreshList();
        //listeyi güncelle
      });
    }

    render(){
        const{
            myFavorites,userName
        }=this.state;

       
        return(
        

            <div className="container">
                  <div className="row">
                   <div className={`col-12 ${cards.textAlignCenter}`}>
                   <h1>Favorilerim</h1>
                   <hr></hr>
                   </div>
                  
                 </div>
                  <div className="row">
                                
                               
                                {myFavorites.map(m => 
                                    <div key={m.Id} className={`col-12 col-sm-6 col-md-4 col-lg-2 ${cards.movieCard}`}>
                                        <div className="row">
                                            <div className="row">
                                              <div className="col-12">
                                                <img src={m.ImagePath} className={cards.img}/>
                                              </div>
                                            </div>
                                          
                                            <div className="row">
                                              <div className="col-12 col-sm-10 col-md-10 col-lg-10">
                                                <div className={`${cards.textAlign }  ${cards.letter}`}>{m.Name}</div>
                                                <div className={cards.textAlign}>{m.Year}</div>

                                              </div>
                                              
                                              <div className="col-12 col-sm-2 col-md-2 col-lg-2">
                                                <div onClick={(e) =>  this.removeFavorites(e,m.Id)}><i className="fa-regular fa-heart"></i></div>
                                              </div>
                                          
                                            </div>
                                        </div>
                                    </div>
                                    )}
                                
                                
                          </div>

            </div>
        )
       
      
}
    
}