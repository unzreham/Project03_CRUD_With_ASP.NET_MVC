import React, { useState,useEffect } from 'react';
import { Router, Link, navigate } from '@reach/router';
import axios from 'axios';

function Home(props) {

const [allTours, setAllTours] = useState([]);

  useEffect(() => {
   // setjwtStr(Storage.get("token"))
   // console.log(Storage.get("token"))
    getAll();
},[ ]);


const getAll = () => {
     
  console.log("handle submit")

  axios.get('https://localhost:44360/api/Tours/')
    .then((res) => {
      console.log(res.data)
      setAllTours(res.data)
    })
    .catch((error) => {
      console.error(error)
    })
   
}





    return (
        <div>



  <nav class="navbar yellow navbar-expand-md navbar-dark ">
  
    <div class="navbar-collapse collapse" id="navbar4">
        <ul class="navbar-nav">
         
            <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/">Home </Link></li> 
     
            {/* <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/aboutus">About us </Link></li> */}
            {/* <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/test">test </Link></li> */}

        </ul>
    </div>
</nav>



    <div class="header-img"></div>
    <div class="container">
    {allTours.map((m,i)=>{
    return(
<div class="card cardOne">
 <div class="card-header">{m.place}</div>
  <img src= {m.image}  alt="capture" style={{width: "290px", height:"300px" }} /> 
  <div class="card-body">
    <p> cuisine : {m.description}</p>

  </div>
  <Link to={`/book/${m.tourId}`}      className="btn btn-warning"   >Book   </Link> 
</div> 
    )
})
}





     </div>
        </div>



    );
}

export default Home;