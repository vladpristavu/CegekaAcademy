import React from 'react';
import logo from './logo.svg';
import './App.css';
import { NavigationBar } from './components/NavigationBar';
import { BrowserRouter, Outlet, Route, Routes } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import CarOffers from './components/CarOffers';
import Customers from './components/Customers';
import NewCar from './components/NewCar';

function MainLayout() {
  return (
    <div className="App">
      <NavigationBar />
      <div className='main-content'>
        <Outlet />
      </div>
    </div>)
}

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<MainLayout />} >
          <Route path="/caroffers" element={<CarOffers />}>
          </Route>
          <Route path="/customers" element={<Customers />}>
          </Route>
          <Route path="/newcar" element={<NewCar />}>
          </Route>
          <Route path="/" element={<div>Home</div>}>
          </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
