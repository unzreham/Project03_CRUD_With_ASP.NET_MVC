
import './App.css';
import { Router, Link, navigate } from '@reach/router';
import 'bootstrap/dist/css/bootstrap.min.css';

import Login from './components/Login';
import Dashboard from './components/Dashboard';
import AddTour from './components/AddTour'; 
import Update from './components/Update'; 
import Home from './components/Home'; 
import Book from './components/Book'; 
import Display from './components/Display'; 


function App() {
  return (
    <div className="">
     	<Router>
				 <Login path="/login"  />
         {/* <Dashboard path="/dashboard"  /> */}

         <Dashboard path="/Dashboard"  />
         <Update path="/update/:pk"  />
         <Display path="/display/:pk"  />

         <AddTour path="/addTour"  />
         <Home path="/"  />
         <Book path="/book/:pk"  />



			</Router>
    </div>
  );
}

export default App;
