import React, {useState, useEffect} from 'react';
// import CharNavbar from './CharNavbar';
import axios from 'axios';
import {Link}  from '@reach/router';

const Dashboard = () => {
  
    const [allTours, setallTours] = useState([])
    // const [jwtStr, setjwtStr]            = useState('');

    useEffect(() => {
        // setjwtStr(Storage.get("token"))
        // console.log(Storage.get("token"))
     
        getTours();
    },[ ]);
    // const getToken = () =>{
    //     return Storage.get("token")
    // };
 
    

 


const getTours  = () => {
 
    console.log("handle fetching data")
    axios.get('https://localhost:44360/api/Tours/')
      .then((res) => {
        console.log(res.data)
        setallTours(res.data)
      })
      .catch((error) => {
        console.error(error)
      })   
}


const deleteTour  = (tourId) => {
    console.log("handle delete")
    axios.delete(`https://localhost:44360/api/Tours/${tourId}/`)
      .then((res) => {
        window.location.reload( );
    
      })
      .catch((error) => {
        console.error(error)
      })   
}
    return (
     <>

<nav class="navbar blue navbar-expand-md  ">
  
  <div class="navbar-collapse collapse" id="navbar4">
      <ul class="navbar-nav">
       
          <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/">Home </Link></li> 
   
          <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/addTour">Add a new tour </Link></li>
          {/* <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/test">test </Link></li> */}
          <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/Dashboard">Dashboard </Link></li>

      </ul>
  </div>
</nav>




      <div className="container">
      {/* <CharNavbar />  */}

        <table className="table table-striped" >
      <tbody>
        <tr className="bg-dark text-light">
        <th>Tour</th>
        <th>Actions</th>
        </tr>
        {allTours.map((tour,i)=>{
  return(    
<tr >
<td>{tour.place}</td>
<td>
<button className="btn btn-outline-danger btn-sm"  onClick={()=>deleteTour(tour.tourId)} >Cancel </button>
&nbsp;
{/* <Link to={"/" } className="btn btn-sm btn-outline-success">Disply</Link> */}
<Link to={`/update/${tour.tourId}`}      className="btn btn-outline-success btn-sm"   >  Update  </Link>
<Link to={`/display/${tour.tourId}`}     className="btn btn-outline-warning btn-sm"    >  Display  </Link>

&nbsp;

</td> 
</tr>
  )
})
}    
      </tbody>
    </table>

      </div>


         </>
     
      );
  };
       
           
  
    
 


export default Dashboard