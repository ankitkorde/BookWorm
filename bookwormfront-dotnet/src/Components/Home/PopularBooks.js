import React, { useState, useEffect } from "react";
import { motion } from "framer-motion";
import styled from "styled-components";

const CarouselContainer = styled.div`
  width: fit-content;
  overflow: hidden;
  position: relative;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 20px 0;
`;

const CarouselWrapper = styled.div`
  display: flex;
  width: fit-content; // Adjust width to fit the content
  max-width: fit-content;
  height: auto; // Adjust height to match the image size
`;

const CarouselTrack = styled(motion.div)`
  display: flex;
  gap: 20px;
  transition: transform 0.5s ease-in-out;

  @media (max-width: 480px) {
    flex-direction: column; /* Stack items vertically on mobile */
    align-items: center;
    gap: 15px;
  }
`;

const Card = styled.div`
  background: #fff;
  border-radius: 10px;
  padding: 20px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  text-align: center;
  width: 200px; // Fixed width
  height: 300px; // Fixed height
  display: flex;
  flex-direction: column;
  justify-content: space-between;

  @media (max-width: 480px) {
    flex: 1 1 auto;
    width: 90%;
    max-width: fit-content;
  }
`;

const Title = styled.h2`
  font-size: 1.5rem;
  font-weight: bold;
  margin-bottom: 10px;
  color: #333;
`;

const Description = styled.p`
  font-size: 1rem;
  color: #555;
  line-height: 1.4;
`;

const Image = styled.img`
  width: 100%;
  height: auto;
  max-height: 150px; // Ensure the image fits within the card
  object-fit: cover;
`;

const Carousel = () => {
  const [products, setProducts] = useState([]);
  const [index, setIndex] = useState(0);

  useEffect(() => {
      fetch('http://localhost:5160/api/Product/all', {
          headers: {
              'Content-Type': 'application/json',
              'Accept': 'application/json'
          }
      })
          .then(response => response.ok ? response.json() : Promise.reject('Network error'))
          .then(data => {
              setProducts(data);
          })
          .catch(error => {
              console.error('Fetch error:', error);
              alert(error);
          });
  }, []);

  useEffect(() => {
    if (products.length > 2) {
      const interval = setInterval(() => {
        setIndex((prevIndex) => (prevIndex + 1) % products.length);
      }, 2000);
      return () => clearInterval(interval);
    }
  }, [products.length]);

  return (
    <CarouselContainer>
      <CarouselWrapper>
        <CarouselTrack
          animate={{ x: `-${index * 100 / products.length}%` }} // Adjust the width percentage
          transition={{ duration: 0.5, ease: "easeInOut" }}
        >
          {products.map((product, index) => (
            <Card key={product.productId || index}>  {/* Fallback to index if id is missing */}
              <Image src={product.imgSrc} alt={product.productName} />
              <Title>{product.productName}</Title>
              <Description>{product.productDescriptionShort}</Description>
            </Card>
          ))}
        </CarouselTrack>
      </CarouselWrapper>
    </CarouselContainer>
  );
};

export default Carousel;