import React, { useState } from "react";

import "./contactus.css";


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
    <div className="contact-container" id="contactus">
      <h2>Contact Us</h2>
      <p>We'd love to hear from you! Reach out with any questions, feedback, or support requests.</p>

      <form onSubmit={handleSubmit} className="contact-form">
        <label>Name:</label>
        <input type="text" name="name" value={formData.name} onChange={handleChange} required />

        <label>Email:</label>
        <input type="email" name="email" value={formData.email} onChange={handleChange} required />

        <label>Message:</label>
        <textarea name="message" value={formData.message} onChange={handleChange} required />

        <button type="submit" className="submit-btn">Send Message</button>

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
        height="100%" 
        style={{ border: 0, borderRadius: "12px" }} 

        allowFullScreen="" 
        loading="lazy" 
        referrerPolicy="no-referrer-when-downgrade" 
        title="Our Location">
      </iframe>
    </div>
  );
};

const ContactUsPage = () => {
  return (
    <div className="contactus-page">
      <div className="contact-content">
        <Map />
        <ContactUs />
      </div>

    </div>
  );
};

export default ContactUsPage;

