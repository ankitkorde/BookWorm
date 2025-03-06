import React, { useMemo } from 'react';
import { Carousel } from 'antd';
import image1 from './images/image1.jpg';
import image2 from './images/image2.jpg';
import image3 from './images/image3.jpg';
import image4 from './images/image4.jpg';
import './ResponsiveCarousel.css'; // Add a CSS file for styles

const ResponsiveCarousel = () => {
  const images = useMemo(() => [image1, image2, image3, image4], []);

  return (
    <div className="carousel-container">
      <Carousel autoplay autoplaySpeed={2000}>
        {images.map((image, index) => (
          <div key={index} className="carousel-item">
            <img
              src={image}
              alt={`carousel-${index}`}
              loading="lazy"
              className="carousel-image"
              
            />
          </div>
        ))}
      </Carousel>
    </div>
  );
};

export default ResponsiveCarousel;
