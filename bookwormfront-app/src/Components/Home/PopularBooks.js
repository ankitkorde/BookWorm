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
  padding: fit-content;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  text-align: center;
  height: auto; // Adjust height to match the image size

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

const Carousel = () => {
  const [products, setProducts] = useState([]);
  const [index, setIndex] = useState(0);

  useEffect(() => {
      fetch('http://localhost:8080/api/products', {
          headers: {
          }
      })
          .then(response => response.ok ? response.json() : Promise.reject('Network error'))
          .then(data => {
              setProducts(data);
          })
          .catch(error => alert(error));
  }, []);

  useEffect(() => {
    if (products.length > 2) {
      const interval = setInterval(() => {
        setIndex((prevIndex) => (prevIndex + 1) % products.length);
      }, 3000);
      return () => clearInterval(interval);
    }
  }, [products.length]);

  return (
    <CarouselContainer>
      <CarouselWrapper>
        <CarouselTrack
          animate={{ x: `-${index * 100 / products.length}%` }} // Adjust the width percentage
          transition={{ duration: 1, ease: "easeInOut" }}
        >
          {products.map((product, index) => (
            <Card key={product.productId || index}>  {/* Fallback to index if id is missing */}
              <img src="https://imgs.search.brave.com/fQFeRg-OtzjHLG6UXvP2pkejFD634-A3HiMYb94D9iQ/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvNjA4/MDc1NTE4L3Bob3Rv/L2hhbnVtYW4tcmFt/YXlhbmEuanBnP3M9/NjEyeDYxMiZ3PTAm/az0yMCZjPUNVb3BE/UUY5aWJ1MkNCX1hK/ZDY2bTNwTWJfMk9n/Q2xlYy1fLXdGSU0t/LUk9" alt={product.productName} />
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