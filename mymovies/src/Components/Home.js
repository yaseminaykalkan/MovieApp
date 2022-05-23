import React,{Component} from "react";  
import {variables} from '../Variables';



import styles from "../TableFooter.module.css";
import cards from "../Table.module.css";

export class Home extends Component{

    constructor(props){
      
        super(props);
        
          this.state={
            movies:[],
            page:1,
            setPage:1,
            slice: [], 
            range : []
        }
        
    }

    refreshList(){
      if(this.props.searchMovie == null){
        
        fetch(variables.MOVIES).then(response => response.json())
        .then(data => {
            this.setState({movies:data.results});

            this.getSliceData(data.results);
        });

      }else
        {
          this.setState({movies:this.props.searchMovie}); 
          this.getSliceData(this.props.searchMovie);
        }
      
    }

    setPage(page){
      this.state.page = page;
      
      this.getSliceData(this.state.movies);
    }
     
    getSliceData(data){
      const range = [];
            const num = Math.ceil(data.length / 6);
            let i = 1;
            for (let i = 1; i <= num; i++) {
              range.push(i);
            }
            this.setState({range:range});
              const slice = data.slice((this.state.page - 1) * 6, this.state.page * 6);
              this.setState({slice:slice});
    }

    componentDidMount(){
     
        this.refreshList();
    }

 
    addFavorites(e,movieId,movieName,year,imagePath){
      e.preventDefault();

       fetch(variables.ADDFAVORITE, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            
            Name:movieName,
            UserName:this.props.username ,
            MovieId:movieId,
            IsActive:true,
            Year:year,
            ImagePath:imagePath

        }),
      }).then(response => response.json())
      .then(data => {
        
        if (data) {
          
          //icon rengi değiştir
        
        } else {
         
          //icon rengi değiştir
        }
      });
    }

   
    render(){
        const{
            movies,page,setPage,range,slice
        }=this.state;

        
        return(
        
           
          <div className="container" id="liste">
                 <div className="row">
                   <div className={`col-12 ${cards.textAlignCenter}`}>
                   <h1>Trendler</h1>
                   <hr></hr>
                   </div>
                 </div>
          
                <div className="row">
                               
                      {slice.map(m => 
                  
                  //
                        <div key={m.id} className={`col-12 col-sm-6 col-md-4 col-lg-2  ${cards.movieCard}`}>
                            <div className="row">

                              <div className="row">
                                <div className="col-12">
                                <img src={"https://image.tmdb.org/t/p/w500" +m.poster_path} className={cards.img}/>
                                </div>
                              </div>
                              
                              
                              <div className="row">
                                  <div className="col-12 col-sm-10 col-md-10 col-lg-10">
                                    <div className={`${cards.textAlign } ${cards.letter} `}>{m.original_title}</div>
                                    <div className={cards.textAlign}>{m.release_date.split("-")[0]}</div>

                                  </div>
                                  
                                  <div className="col-12 col-sm-2 col-md-2 col-lg-2">
                                  
                                    <div  onClick={(e) =>  this.addFavorites(e,m.id,m.original_title,m.release_date.split("-")[0],"https://image.tmdb.org/t/p/w500" +m.poster_path)}><i className="fa-regular fa-heart"></i></div>
                                  </div>
                                  
                                    
                              
                              </div>

                            </div>
                          </div>
                    
                        
                          )}
                      
                      
                </div>
                  
                      
                  <div className="row">
                      <div className={`${styles.tableFooter}`}>
                      {range.map((el, index) => (
                        <button
                          key={index}
                          className={`${styles.button} ${
                            page === el ? styles.activeButton : styles.inactiveButton
                          }`}
                          onClick={() => this.setPage(el)}
                        >
                          {el}
                        </button>
                      ))}
                    </div>
                  </div>
            
           
          </div>


        )
       
      
}
}