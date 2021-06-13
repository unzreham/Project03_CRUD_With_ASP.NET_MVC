import React, { useState,useEffect } from 'react';
import { Router, Link, navigate } from '@reach/router';
import axios from 'axios';

const Book = (props) => {



    
    const [adult, setAdult]              = useState()  //      
    const [child, setChild]              = useState()  //     
    const [firstName, setFirstName]      = useState()  //    
    const [lastName, setLastName]      = useState()  //    
    const [tourId, setTourId]                    = useState(props.pk)  
    const [msg, setMessageSubmit]                = useState () //
    const [TourData, setTourData] = useState([])
    const [included, setincluded] = useState({})


    const handleSubmit = (e) => {
        e.preventDefault();
        console.log("handle submit")
        // setjwtStr(Storage.get("token"))
        // const config = {
        //     headers: { Authorization: `Bearer ${jwtStr}` }
        // };
        const addBook=
        {

"adult": adult,
  "child": child,
  "firstName": firstName,
  "lastName": lastName,
  "tourId": tourId
          
            
          }
     
         
        
      
        axios
          .post('https://localhost:44360/api/Bookings/?format=json',addBook )
          .then((res) => {
          setMessageSubmit("Your booking has been submitted") } )
            .catch((err) =>  setMessageSubmit("Not Submitted")
            );
    }



    useEffect(() => {
        getTour();
    
      },[ ]);
      
      const getTour=()=>{
        axios
        .get(`https://localhost:44360/api/Tours/${props.pk}/?format=json`)
        .then((res) => {
            setTourData(res.data)
            setincluded(res.data.included)
            console.log(res.data)
          })
        .catch((err) => console.error(err));
      }




    return (
        <div>
    <nav class="navbar yellow navbar-expand-md  ">
  
  <div class="navbar-collapse collapse" id="navbar4">
      <ul class="navbar-nav">
       
          <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/">Home </Link></li> 
   
          {/* <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/aboutus">About us </Link></li> */}
          {/* <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/test">test </Link></li> */}

      </ul>
  </div>
</nav>




<div className="container-md ">

<div class="card col-md-12 p-3">
        <div class="row ">

        <div class="col-md-8">
                <div class="card-block">
                    <h6 class="card-title text-right">{TourData.place}</h6>
                    <p class="card-text text-justify">{TourData.description}.</p>
                </div>

                <div>
                    <h5>included</h5>

         {included.food === true && <p> Food yes  </p>}
         {included.transport === true && <p> Transport  </p>}
         {included.entiranceFees === true && <p> Entirance Fees   </p>}
         {included.pickUpAndDrop === true && <p> pickUp and Drop yes </p>}

                  {/* <p>{CityInfo.name}</p>
                  <p>{CityInfo.description}</p>
                  <p>{CityInfo.Population}</p> */}

                  <p></p>

                </div>
            </div>


            <div class="col-md-4">
                <img class="" src={TourData.image} style={{width: "300px", height:"300px" }} />
            </div>



         </div>




 </div>
 </div>



<form>
  <div class="form-group">
    <label for="formGroupExampleInput">FirstName</label>
    <input type="text" class="form-control" id="formGroupExampleInput"  onChange = {(e)=>setFirstName(e.target.value)} />
  </div>
  <div class="form-group">
    <label for="formGroupExampleInput2">LastName</label>
    <input type="text" class="form-control" id="formGroupExampleInput2" onChange = {(e)=>setLastName(e.target.value)}  />
  </div>

  <div class="form-group">
    <label for="formGroupExampleInput2">Adult</label>
    <input type="number" class="form-control" id="formGroupExampleInput2" onChange = {(e)=>setAdult(e.target.value)}  />
  </div>

  <div class="form-group">
    <label for="formGroupExampleInput2">Child</label>
    <input type="number" class="form-control" id="formGroupExampleInput2" onChange = {(e)=>setChild(e.target.value)}  />
  </div>

  <button className="btn mb-4" id = "Charbtn" type='submit' onClick = {handleSubmit}>Book</button>
 <p>{msg}</p>
</form>




            
        </div>
    );
};

export default Book;