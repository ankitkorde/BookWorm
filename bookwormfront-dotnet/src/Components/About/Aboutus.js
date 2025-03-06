import React, { useEffect, useState } from 'react';
import './Aboutus.css';
import TeamMember1 from './images/prashant.jpg';
import TeamMember2 from './images/sanket.jpg';
import TeamMember3 from './images/sumit.jpg';
import TeamMember4 from './images/ankit.jpg';
import TeamMember5 from './images/swapnali.jpg';
import TeamMember6 from './images/abhishek.jpg';
import TeamMember7 from './images/asim.jpg';
import TeamMember8 from './images/vishal.jpg';
import TeamMember9 from './images/aryan.jpg';
import 'react-responsive-carousel/lib/styles/carousel.min.css';
import AboutusLogo from './images/logo.jpg';
const AboutUs = () => {
 
  useEffect(() => {
    if (window.sliderTeam) {
      window.sliderTeam.init();
    }
  }, []);

  return (
    <div className="about-us">
      <h1>About Us</h1>
      <div className="about-us-content">
        
      <img src={AboutusLogo} alt="Books" className="pic" />
        <div className="text">
          <h2>Welcome to BookWorm</h2>
          <h5>Your Go-To Destination for <span>eBooks & More</span></h5>
          <p>
            Welcome to BookWorm, the largest online library for book lovers! 📚 Immerse yourself in a world of endless stories and adventures. 
            Whether you're into thrillers, romance, fantasy, or non-fiction, we've got it all. Our mission is to make reading accessible and enjoyable for everyone.
          </p>
        </div>
      
<br></br>
        <b><i>Thank you for choosing BookWorm. Happy reading!</i></b>
      </div>

      <h2>Meet Our Team</h2>

      <div className="team-members">
        
        <div className="team-member">
          <img src={TeamMember1} alt="Team Member 1" className="team-member-image" />
          <h3>Prashant Gour</h3>
        </div>
        <div className="team-member">
          <img src={TeamMember2} alt="Team Member 2" className="team-member-image" />
          <h3>Sanket Paithankar</h3>
        </div>
        <div className="team-member">
          <img src={TeamMember3} alt="Team Member 2" className="team-member-image" />
          <h3>Sumit Mathankar</h3>
          
        </div>
        <div className="team-member">
          <img src={TeamMember4} alt="Team Member 2" className="team-member-image" />
          <h3>Ankit Korde</h3>
         
        </div>
        <div className="team-member">
          <img src={TeamMember5} alt="Team Member 2" className="team-member-image" />
          <h3>Swapnali Morbale</h3>
        
        </div>
        <div className="team-member">
          <img src={TeamMember6} alt="Team Member 2" className="team-member-image" />
          <h3>Abhishek Mishra</h3>
    
        </div>
        <div className="team-member">
          <img src={TeamMember7} alt="Team Member 2" className="team-member-image" />
          <h3>Aasim </h3>
         
        </div>
        <div className="team-member">
          <img src={TeamMember8} alt="Team Member 2" className="team-member-image" />
          <h3>Vishalsingh Chandel</h3>
         
        </div>
        <div className="team-member">
          <img src={TeamMember9} alt="Team Member 2" className="team-member-image" />
          <h3>Aryan Bisht </h3>
         
        </div>

      </div>

    </div>
  );
};

const ContactUs = () => {
  const [formData, setFormData] = useState({ name: "", email: "", message: "" });

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    alert("Form submitted successfully!");
    setFormData({ name: "", email: "", message: "" });
  };

  return (
    <div className="contact-container">
      <h2>Contact Us</h2>
      <form onSubmit={handleSubmit} className="contact-form">
        <label>Name:</label>
        <input type="text" name="name" value={formData.name} onChange={handleChange} required />

        <label>Email:</label>
        <input type="email" name="email" value={formData.email} onChange={handleChange} required />

        <label>Message:</label>
        <textarea name="message" value={formData.message} onChange={handleChange} required />

        <button type="submit">Submit</button>
      </form>
    </div>
  );
};

const Map = () => {
  return (
    <div className="map-container">
      <h2>Our Location</h2>
      <iframe 
        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3769.906140409916!2d72.83258289999999!3d19.1117731!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3be7c9c3a5e26d7b%3A0x89a89f343cff9c29!2sSM%20VITA!5e0!3m2!1sen!2sin!4v1738913736137!5m2!1sen!2sin" 
        width="100%" 
        height="300" 
        style={{ border: 0 }} 
        allowFullScreen="" 
        loading="lazy" 
        title="Our Location">
      </iframe>
    </div>
  );
};

const ContactUsPage = () => {
  return (
    <div className="contactus-page">
      <AboutUs />
      {/* <Map />
      <ContactUs /> */}
    </div>
  );
};

export default ContactUsPage;
