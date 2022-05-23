import React,{Component} from "react";  
import {variables} from '../Variables';
import ReactDOM from 'react-dom/client';
import { Home } from "./Home";

import cards from "../Table.module.css";


export class Search extends Component{

    constructor() {
        
        super();
        this.state = {
            searchText: '',
            searchResults: []
        }
    }


    onChange(e) {
        this.setState({searchText: e.target.value});
    }

   
  
    handleSubmit (e,searchText,searchResults) {
        e.preventDefault();
        debugger;
        
        fetch(variables.SEARCHMOVIE + searchText).then(response => response.json())
        .then(data => {
            this.setState({searchResults:data.results});
            
            const root = ReactDOM.createRoot(document.getElementById('liste'));
            root.render(<Home searchMovie ={data.results} username ={this.props.username} />);
            
        });
      };

    render(){
        
        const{
            searchText,searchResults
        }=this.state;
        

        
            return(

                <div className="Search">
    
                    <form onSubmit={(e) => this.handleSubmit(e,searchText,searchResults)}>
                        <div className="input-group mb-3">
                            <input type="text"   aria-label="Recipient's username" aria-describedby="basic-addon2" value={searchText}
                            placeholder="Ara.."
                            onChange={(e) => this.onChange(e)}
                            className= {`form-control ${cards.searchBox}`}/>
                            <button  className={`input-group-append ${cards.btnNone}`} type="submit">
                                <span className="input-group-text" id="basic-addon2"><i className="fa-solid fa-magnifying-glass"></i></span>
                            </button>
                        </div>
                    </form>
                </div>

            )
        
        
       
    }
}

