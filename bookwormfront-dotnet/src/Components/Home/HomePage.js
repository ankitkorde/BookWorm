import React, { useEffect } from "react";
import "./Home.css";
import { Box, Typography } from "@mui/material";
import HomeImage from "./Pictures/Home.png";
import AboutUs from "../About/Aboutus";
import Carousel from "../Home/PopularBooks";
import ContactUsPage from "../ContactUs/ContactUs";

const HomePage = () => {
  useEffect(() => {
    const heroImage = document.querySelector(".hero-image");
    const heroText = document.querySelectorAll(".hero-text");

    heroImage.classList.add("fade-down");
    heroText.forEach((text, index) => {
      setTimeout(() => {
        text.classList.add("fade-up");
      }, 500 * (index + 1));
    });
  }, []);

  return (
    <div className="homepage">
      {/* Hero Section */}
      <Box className="hero-section" sx={{ textAlign: "center", p: 4, background: "#774dd3", color: "white" }}>
        <img src={HomeImage} alt="Hero" className="hero-image" />
        <Typography variant="h3" fontWeight="bold" className="hero-text">Welcome to BookWorm</Typography>
        <Typography variant="h6" sx={{ mt: 1, mb: 2 }} className="hero-text">
          Discover a world of books at your fingertips.
        </Typography>
      </Box>

      {/* Popular Books Carousel */}
      <Box className="carousel">
        <Carousel />
      </Box>

      {/* About Us Section */}
      <Box id="about-us-section" className="about-us-section">
        <AboutUs />
      </Box>

      {/* Contact Us Section */}
      <Box id="contact-us-section" className="contact-us-section">
        <ContactUsPage />
      </Box>
    </div>
  );
};

export default HomePage;
