import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import NavBar from './Components/Header/NavBar';
import ProductsPage from './Components/Products/ProductDisplay';
import RegistrationForm from './Components/Registration/RegistrationComponent';
import SignInPage from './Components/Login/LoginComponent';
import HomePage from './Components/Home/HomePage';
import CartPage from './Components/Cart/CartPage';
import AboutUs from './Components/About/Aboutus';
import ContactUs from './Components/ContactUs/ContactUs';
import ShelfPage from './Components/Shelf/ShelfPage';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const PrivateRoute = ({ element: Component, ...rest }) => {
  const isLoggedIn = sessionStorage.getItem('isLoggedIn') === 'true';
  if (!isLoggedIn) {
    toast.error('Please login to access this page.');
  }
  return isLoggedIn ? <Component {...rest} /> : <Navigate to="/" />;
};

function App() {
  return (
    <Router>
      <NavBar />
      <ToastContainer />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<SignInPage />} />
        <Route path="/signup" element={<RegistrationForm />} />
        <Route path="/products" element={<PrivateRoute element={ProductsPage} />} />
        <Route path="/cart" element={<PrivateRoute element={CartPage} />} />
        <Route path="/aboutus" element={<AboutUs />} />
        <Route path="/contactus" element={<ContactUs />} />
        <Route path="/shelf" element={<PrivateRoute element={ShelfPage} />} />
      </Routes>
    </Router>
  );
}

export default App;
