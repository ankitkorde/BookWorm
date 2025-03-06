import React, { useEffect, useState, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import { Card, CardContent, Typography, Container, Box } from '@mui/material';
import { styled } from '@mui/system';
import { FaShoppingCart, FaRegCalendarAlt } from 'react-icons/fa';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const StyledCard = styled(Card)(({ theme }) => ({
    position: 'relative',
    transition: 'transform 0.3s ease, box-shadow 0.3s ease',
    height: 'auto', // Ensure cards are always open
    width: '100%', // Ensure cards take full width in their container
    maxWidth: '300px', // Set a max width for the cards
    margin: '10px', // Add margin between cards
    '&:hover': {
        transform: 'translateY(-5px)',
        boxShadow: '0px 6px 12px rgba(0, 0, 0, 0.2)',
    },
}));

const IconWrapper = styled('div')(({ theme }) => ({
    position: 'absolute',
    top: '10px',
    left: '10px',
    fontSize: '36px', // Increase the size of the icon
    color: '#7d6df8', // Change the color of the icon
    backgroundColor: 'rgba(255, 255, 255, 0.8)', // Add a background to make it more visible
    borderRadius: '50%', // Make the background circular
    padding: '10px', // Add padding around the icon
    width: '50px', // Set width to make it circular
    height: '50px', // Set height to make it circular
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
}));

const ExpiryText = styled(Typography)(({ theme }) => ({
    color: '#7d6df8', // Match the color of the icons
    fontWeight: 'bold', // Make the text bold
}));

const ShelfPage = () => {
    const [shelfDetails, setShelfDetails] = useState([]);
    const [books, setBooks] = useState({});
    const [error, setError] = useState(null);
    const containerRef = useRef(null);
    const navigate = useNavigate();

    useEffect(() => {
        const token = sessionStorage.getItem('token');
        if (!token) {
            toast.warning('Please login to access this page');
            navigate('/');
        } else {
            fetchShelfDetails();
        }
    }, []);

    const fetchShelfDetails = async () => {
        try {
            const email = sessionStorage.getItem('customerEmail');
            const token = sessionStorage.getItem('token');
            const customerResponse = await fetch(`http://localhost:8080/api/customers/email/${email}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            if (!customerResponse.ok) {
                throw new Error('Network response was not ok');
            }
            const customerData = await customerResponse.json();
            const customerId = customerData.customerid;

            const shelfResponse = await fetch(`http://localhost:8080/api/myshelf/customer/${customerId}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            if (!shelfResponse.ok) {
                throw new Error('Network response was not ok');
            }
            const shelfData = await shelfResponse.json();
            const shelfId = shelfData.shelfId;
            const shelfDetailsResponse = await fetch(`http://localhost:8080/api/myshelf/${shelfId}/details`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            if (!shelfDetailsResponse.ok) {
                throw new Error('Network response was not ok');
            }
            const shelfDetailsData = await shelfDetailsResponse.json();
            setShelfDetails(shelfDetailsData);

            // Fetch book data for each unique book in shelf details
            const bookData = {};
            const uniqueBookIds = [...new Set(shelfDetailsData.map(item => item.productId.productId))];
            for (const bookId of uniqueBookIds) {
                const bookResponse = await fetch(`http://localhost:8080/api/products/${bookId}`, {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                });
                if (!bookResponse.ok) {
                    throw new Error('Network response was not ok');
                }
                const book = await bookResponse.json();
                bookData[bookId] = book;
            }
            setBooks(bookData);
        } catch (error) {
            setError(error);
        }
    };

    useEffect(() => {
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, []);

    const handleClickOutside = (event) => {
        if (containerRef.current && !containerRef.current.contains(event.target)) {
            // Handle click outside
        }
    };

    if (error) return <div>Error: {error.message}</div>;

    return (
        <Container ref={containerRef}>
            <ToastContainer />
            <Typography variant="h4" gutterBottom>
                Your Shelf
            </Typography>
            <Box display="flex" justifyContent="center" marginBottom="20px" >
                {shelfDetails.length > 0 ? (
                    <Box display="flex" flexWrap="wrap" justifyContent="center">
                        {shelfDetails.map(item => (
                            <StyledCard key={item.shelfDetailsId}>
                                <IconWrapper>
                                    {item.tranType === 'rent' ? <FaRegCalendarAlt /> : <FaShoppingCart />}
                                </IconWrapper>
                                <CardContent>
                                    <Box display="flex" justifyContent="center">
                                    <img 
                                        src={books[item.productId.productId]?.imgSrc || 'default-image.jpg'} 
                                        alt={books[item.productId.productId]?.productName || 'Product Image'} 
                                        onError={(e) => e.target.src = 'default-image.jpg'} 
                                        style={{ maxWidth: '100%', height: 'auto' }} 
                                    />
                                    </Box>
                                    <Typography variant="h6" gutterBottom align="center" fontWeight="bold">
                                        {item.productId.productName || 'Loading...'}
                                    </Typography>
                                    <Typography variant="body2" gutterBottom align="center">
                                        {item.productId.productDescriptionLong || 'Loading...'}
                                    </Typography>
                                    <ExpiryText variant="body2" align="center">
                                        {item.tranType === 'rent' ? `Expiry Date: ${new Date(item.expiryDate).toLocaleDateString()}` : 'Expiry Date: Lifetime'}
                                    </ExpiryText>
                                </CardContent>
                            </StyledCard>
                        ))}
                    </Box>
                ) : (
                    <Typography variant="h6" gutterBottom align="center">
                        Your shelf is empty
                    </Typography>
                )}
            </Box>
        </Container>
    );
};

export default ShelfPage;
