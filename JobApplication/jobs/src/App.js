import './App.css';
import Login from './pages/Login/Login';
import React from 'react';
import Signup from './pages/Signup/Signup';
import Homepage from './pages/Homepage/Homepage';
import Advert from './pages/Advert/Advert';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/signup" element={<Signup />} />
          <Route path="/homepage" element={<Homepage />} />
          <Route path="/advert" element={<Advert />} />
        </Routes>
      </BrowserRouter>


    </div>
  );
}

export default App;
