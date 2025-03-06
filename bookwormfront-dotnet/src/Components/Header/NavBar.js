import * as React from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { Navbar, Nav, Container } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { Button, Drawer } from '@mui/material';
import LoginComponent from '../Login/LoginComponent';
import RegistrationComponent from '../Registration/RegistrationComponent';
import './NavBar.css'; // Import CSS file
import { nav } from 'motion/react-client';

function NavBar({ onSearch }) {
  const location = useLocation();
  const navigate = useNavigate();
  const isLoggedIn = sessionStorage.getItem('isLoggedIn') === 'true';
  const [loginOpen, setLoginOpen] = React.useState(false);
  const [signupOpen, setSignupOpen] = React.useState(false);
  const [searchQuery, setSearchQuery] = React.useState('');

  const handleLogout = async () => {
    try {
      const customerEmail = sessionStorage.getItem('customerEmail');
      
      const response = await fetch('http://localhost:5160/api/Login/logout', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(customerEmail) // Wrap in an object
      });
  
      if (!response.ok) {
        throw new Error(`Logout failed: ${response.statusText}`);
      }
      // Clear session storage only after successful logout
      sessionStorage.removeItem('customerEmail');
      sessionStorage.removeItem('token');
      sessionStorage.removeItem('isLoggedIn'); // Remove instead of setting 'false'
      navigate('/');
  
    } catch (error) {
      console.error('Logout Error:', error);
    }
  };
  

  const handleLoginOpen = () => {
    setLoginOpen(true);
    document.body.classList.add('drawer-open');
  };

  const handleLoginClose = () => {
    setLoginOpen(false);
    document.body.classList.remove('drawer-open');
  };

  const handleSignupOpen = () => {
    setSignupOpen(true);
    handleLoginClose();
  };

  const handleSignupClose = () => {
    setSignupOpen(false);
    document.body.classList.remove('drawer-open');
  };

  const handleLoginFromSignup = () => {
    setSignupOpen(false);
    setLoginOpen(true);
  };

  const handleLoginSuccess = () => {
    setLoginOpen(false);
    navigate("/products");
  };

  const handleSignupSuccess = () => {
    setSignupOpen(false);
    navigate("/"); // Redirect if needed
  };

  const handleCartOpen = () => {
    navigate("/cart");
  };

  const handleShelfOpen = () => {
    navigate("/shelf");
  };

  const handleBrandClick = () => {
    if (isLoggedIn) {
      navigate("/products");
    } else {
      navigate("/");
    }
  };

  const handleSearchChange = (e) => {
    setSearchQuery(e.target.value);
    if (onSearch) {
      onSearch(e.target.value);
    }
  };

  const scrollToSection = (sectionId) => {
    const section = document.getElementById(sectionId);
    if (section) {
      section.scrollIntoView({ behavior: 'smooth' });
    }
  };

  return (
    <>
      <Navbar expand="lg" className="navbar-container sticky-top" style={{ zIndex: 1200 }}>
        <Container>
          {/* Brand Name */}
          <Navbar.Brand onClick={handleBrandClick} className="navbar-brand" style={{ color: '#7d6df8', cursor: 'pointer' }}>
            BookWorm
          </Navbar.Brand>

          {/* Toggle Button for Small Screens */}
          <Navbar.Toggle aria-controls="basic-navbar-nav" />

          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link onClick={() => scrollToSection('aboutus')}>About Us</Nav.Link>
              <Nav.Link onClick={() => scrollToSection('contactus')}>Contact Us</Nav.Link>
              {/* Add other Nav links here */}
            </Nav>
            {/* <div className="search-container mx-auto">
              <input
                type="text"
                placeholder="Search..."
                className="search-input"
                value={searchQuery}
                onChange={handleSearchChange}
              />
              <button type="button" className="search-button">Search</button>
            </div> */}

            {/* Conditional Buttons */}
            <Nav className="ms-auto">
              {isLoggedIn ? (
                <>
                  <Button variant="contained" className="drawer-button" sx={{ bgcolor: '#7d6df8', marginRight: '10px' }} onClick={handleCartOpen}>
                    Cart
                  </Button>
                  <Button variant="contained" className="drawer-button" sx={{ bgcolor: '#7d6df8', marginRight: '10px' }} onClick={handleShelfOpen}>
                    Shelf
                  </Button>
                  <Button variant="contained" className="drawer-button" sx={{ bgcolor: '#7d6df8',marginRight: '10px' }} onClick={handleLogout}>
                    Log Out
                  </Button>
                </>
              ) : (
                <Button variant="contained" className="drawer-button" sx={{ bgcolor: '#7d6df8' }} onClick={handleLoginOpen}>
                  Sign In
                </Button>
              )}
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>

      {/* Login Component Drawer */}
      <Drawer
        anchor="right"
        open={loginOpen}
        onClose={handleLoginClose}
        PaperProps={{ sx: { width: 500, zIndex: 1100 } }} // Set the width and z-index of the drawer
      >
        <LoginComponent onClose={handleLoginClose} onSignupOpen={handleSignupOpen} onLoginSuccess={handleLoginSuccess} />
      </Drawer>

      {/* Signup Component Drawer */}
      <Drawer
        anchor="right"
        open={signupOpen}
        onClose={handleSignupClose}
        PaperProps={{ sx: { width: 600, zIndex: 1100 } }} // Set the width and z-index of the drawer
      >
        <RegistrationComponent 
          onClose={handleSignupClose} 
          onLoginOpen={handleLoginFromSignup} 
          onSignupSuccess={handleSignupSuccess} 
        />      
      </Drawer>
    </>
  );
}

export default NavBar;