import React, {useState, useEffect} from 'react';
// import CharNavbar from './CharNavbar';
import axios from 'axios';
import {Link}  from '@reach/router';

const Display = (props) => {
  
    const [allBookings, setBookings] = useState([])
    useEffect(() => {
   
     
        getBookings();
    },[ ]);
 
 
    

 


const getBookings  = () => {
 
    console.log("handle fetching data")
    axios.get(`https://localhost:44360/api/AllBooking/${props.pk}`)
      .then((res) => {
        console.log(res.data)
        setBookings(res.data)
      })
      .catch((error) => {
        console.error(error)
      })   
}


const deleteBooking  = (tourId) => {
    console.log("handle delete")
    axios.delete(`https://localhost:44360/api/Bookings/${tourId}/`)
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
        <th>Booking</th>
        <th>Actions</th>
        </tr>
        {allBookings.map((b,i)=>{
  return(    
<tr >
<td>{b.firstName}  {b.lastName}   {b.total}</td>
<td>
<button className="btn btn-outline-danger btn-sm"  onClick={()=>deleteBooking(b.tourId)} >Cancel </button>
&nbsp;

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
       
           
  
    
 


export default Display