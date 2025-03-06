import React, { useEffect, useState, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import { Card, CardContent, CardActions, Button, TextField, Typography, Container, MenuItem, Select, FormControl, InputLabel, Box, Collapse } from '@mui/material';
import { FaTrashAlt } from 'react-icons/fa';
import { styled } from '@mui/system';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const StyledCard = styled(Card)(({ theme }) => ({
    transition: 'transform 0.3s ease, box-shadow 0.3s ease, height 0.3s ease',
    height: 'fit-content', // Initial height to display name and description
    width: 'fit-content', // Ensure cards take full width in their container
    maxWidth: '300px', // Set a max width for the cards
    margin: '10px', // Add margin between cards
    '&:hover': {
        transform: 'translateY(-5px)',
        boxShadow: '0px 6px 12px rgba(0, 0, 0, 0.2)',
    },
}));

const CartPage = () => {
    const [cartDetails, setCartDetails] = useState([]);
    const [products, setProducts] = useState([]);
    const [expandedCard, setExpandedCard] = useState(null);
    const [error, setError] = useState(null);
    const containerRef = useRef(null);
    const navigate = useNavigate();
    const [a, seta] = useState(1);

    useEffect(() => {
        const token = sessionStorage.getItem('token');
        if (!token) {
            toast.warning('Please login to access this page');
            navigate('/');
        } else {
            fetchCartDetails();
        }
    }, []);

    const fetchCartDetails = async () => {
        try {
            const email = sessionStorage.getItem('customerEmail');
            const token = sessionStorage.getItem('token');
    
            const response = await fetch(`http://localhost:5160/api/cart-details/customer/${email}`, {
                headers: { 'Authorization': `Bearer ${token}` }
            });
    
            if (!response.ok) {
                return;
            }
    
            const data = await response.json();
    
            // Merge cart and product data into a single structure
            const mergedCartDetails = data.cart.map(cartItem => ({
                ...cartItem,
                product: data.product.find(product => product.productId === cartItem.productId) || null
            }));
    
            setCartDetails(mergedCartDetails);
        } catch (error) {
            setError(error);
            toast.error('Failed to fetch cart details');
        }
    };
    
    

    const handleUpdate = (id, field, value) => {
        setCartDetails(cartDetails.map(item => item.cartDetailsId === id ? { ...item, [field]: value } : item));
    };

    const handleSave = async (id) => {
        const updatedItem = { ...cartDetails.find(item => item.cartDetailsId === id) };
    
        updatedItem.transType === 'purchase' ? updatedItem.rentNoOfDays = 0 : updatedItem.rentNoOfDays = updatedItem.rentNoOfDays;
        updatedItem.isRented = updatedItem.transType === 'rent';
        updatedItem.offerCost = updatedItem.transType === 'rent' 
            ? updatedItem.rentNoOfDays * updatedItem.product.rentPerDay 
            : updatedItem.product.productOfferPrice;
    
        // Remove the 'product' field before sending the request
        delete updatedItem.product;
    
        const token = sessionStorage.getItem('token');
        
        await fetch(`http://localhost:5160/api/cart-details/${id}`, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(updatedItem),
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .catch(error => {
            toast.error('Failed to update item');
        });
    };
    

    const handleDelete = (id) => {
        const token = sessionStorage.getItem('token');
        fetch(`http://localhost:5160/api/cart-details/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            setCartDetails(prevCartDetails => prevCartDetails.filter(item => item.cartDetailsId !== id));
            fetchCartDetails();
            toast.success('Deleted successfully');
        })
        .catch(error => {
            toast.error('Failed to delete item');
        });
    };

    const handleExpandClick = (id) => {
        setExpandedCard(expandedCard === id ? null : id);
    };

    const handleClickOutside = (event) => {
        if (containerRef.current && !containerRef.current.contains(event.target)) {
            setExpandedCard(null);
        }
    };

    useEffect(() => {
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, []);

    const handleAdd = async (item, myShelfId, token) => {
        try {
            const expiryDate = item.transType === 'purchase' ? null : new Date();
            if (expiryDate) expiryDate.setDate(expiryDate.getDate() + item.rentNoOfDays);
    
            const myShelfRequest = {
                shelfId: myShelfId,
                productId: item.product.productId,
                expiryDate: expiryDate,
                tranType: item.transType
            };
    
            const response = await fetch(`http://localhost:5160/api/myshelf/add`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify(myShelfRequest),
            });
    
            if (!response.ok) {
                throw new Error('Failed to add product to shelf');
            }
    
            toast.success(`Product ${item.product.productName} added to shelf successfully`);
        } catch (error) {
            toast.error('Failed to add product to shelf');
        }
    };
    
    const handleTransact = async () => {
        const token = sessionStorage.getItem('token');
        const email = sessionStorage.getItem('customerEmail');
    
        try {
            const shelfResponse = await fetch(`http://localhost:5160/api/myshelf/customer/${email}`, {
                headers: { 'Authorization': `Bearer ${token}` }
            });
    
            if (!shelfResponse.ok) throw new Error('Network response was not ok');
    
            const shelfData = await shelfResponse.json();
            const myShelfId = shelfData.shelfId;
            const currentCartId = cartDetails[0].cartId;
            
            for (const item of cartDetails) {
                if (!item.transType) {
                    toast.warn('Please select a transaction type for all items.');
                    return;
                }
    
                const expiryDate = item.transType === 'purchase' ? null : new Date();
                if (expiryDate) expiryDate.setDate(expiryDate.getDate() + item.rentNoOfDays);
    
                // Check if the product is already in the shelf
                const isProductInShelfResponse = await fetch(`http://localhost:5160/api/myshelf/${myShelfId}/product/${item.productId}`, {
                    headers: { 'Authorization': `Bearer ${token}` }
                });
    
                if (isProductInShelfResponse.status === 200) {  // If product is in shelf
                    toast.error(`Product ${item.product.productName} is already present in the shelf`);
                } else if (isProductInShelfResponse.status === 404) {  // If product is NOT in shelf
                    handleSave(item.cartDetailsId);
                    await handleAdd(item, myShelfId, token);
                } else { // Unexpected response
                    throw new Error('Unexpected response from the server');
                }
            }

            // Call the checkout function
            await checkout(email, token, currentCartId);
            setTimeout(() => {
                navigate('/shelf');
            }, 2000); // Re-fetch cart details to re-render the page
        } catch (error) {
            toast.error('There was a problem with the fetch operation');
        }
    };

    const checkout = async (email, token, cartId) => {
        try {
            // Checkout request
            await fetch(`http://localhost:5160/api/cart-details/checkout`, {
                method: 'POST',
                headers: { 
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(email)
            });

            // Create invoice request
            await fetch(`http://localhost:5160/api/invoices`, {
                method: 'POST',
                headers: { 
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ email, cartId })
            });
             // Re-fetch cart details to re-render the page
            
        } catch (error) {
            console.error('There was a problem with the fetch operation:', error);
            toast.error('Failed to checkout');
        }
    };

    if (error) return <div>Error: {error.message}</div>;
    console.log(cartDetails);
    return (
        <Container ref={containerRef}>
            <ToastContainer />
            <Typography variant="h4" gutterBottom align="center">
                Your Cart
            </Typography>
            <Box display="flex" justifyContent="center" marginBottom="20px" >
                {cartDetails.length > 0 ? (
                    <Button variant="contained" color="primary" onClick={handleTransact}>
                        Check Out
                    </Button>
                ) : (
                    <Typography variant="h6" gutterBottom align="center">
                        Your cart is empty
                    </Typography>
                )}
            </Box>
            <Box display="flex" flexWrap="wrap" justifyContent="center">
                {cartDetails.map(item => (
                    console.log(item),
                    <StyledCard key={item.cartDetailsId} onClick={() => handleExpandClick(item.cartDetailsId)} style={{ height: expandedCard === item.cartDetailsId ? 'auto' : '280px' }}>
                        <CardContent>
                            <Box display="flex" justifyContent="center">
                            <img 
                                src={(item.product)?.imgSrc || 'default-image.jpg'} 
                                alt={(item.product )?.productName || 'Product Image'} 
                                style={{ maxWidth: '100%', height: 'auto' }} 
                            />
                            </Box>
                            <Typography variant="h6" gutterBottom align="center" fontWeight="bold">
                                {(item.product)?.productName || 'Loading...'}
                            </Typography>

                            <Typography variant="body2" gutterBottom align="center">
                                {item.product.productDescriptionShort || 'Loading...'}
                            </Typography>
                            <Collapse in={expandedCard === item.cartDetailsId} timeout="auto" unmountOnExit>
                                <FormControl fullWidth margin="dense">
                                    <InputLabel>Transaction Type</InputLabel>
                                    <Select
                                        value={item.transType}
                                        onChange={(e) => {
                                            e.stopPropagation(); // Prevent collapse on select change
                                            handleUpdate(item.cartDetailsId, 'transType', e.target.value);
                                        }}
                                    >
                                        <MenuItem value="rent">Rent</MenuItem>
                                        <MenuItem value="purchase">Purchase</MenuItem>
                                    </Select>
                                </FormControl>
                                {item.transType === 'rent' && (
                                    <>
                                        <TextField
                                            label="Rent No Of Days"
                                            type="number"
                                            value={item.rentNoOfDays}
                                            onChange={(e) => handleUpdate(item.cartDetailsId, 'rentNoOfDays', Math.max(e.target.value, item.product.minRentDays))} // Ensure it can't go less than minRentDays
                                            fullWidth
                                            margin="dense"
                                            onClick={(e) => e.stopPropagation()} // Prevent collapse on input change
                                            htmlInput={{ min: item.product.minRentDays, max: 365 }} // Add range
                                        />
                                        <TextField
                                            label="Rent Per Day"
                                            type="number"
                                            value={item.product.rentPerDay}
                                            fullWidth
                                            margin="dense"
                                            InputProps={{
                                                readOnly: true,
                                            }}
                                            onClick={(e) => e.stopPropagation()} // Prevent collapse on input change
                                        />
                                    </>
                                )}
                                <TextField
                                    label="Total Price"
                                    type="number"
                                    value={
                                        item.transType === 'rent'
                                            ? (item.rentNoOfDays || item.product?.minRentDays) * (item.product?.rentPerDay || 0)
                                            : item.transType === 'purchase' ? item.product?.productOfferPrice || 0 : 0
                                    }
                                    fullWidth
                                    margin="dense"
                                    InputProps={{
                                        readOnly: true,
                                    }}
                                    onClick={(e) => e.stopPropagation()} // Prevent collapse on input change
                                />
                                <CardActions style={{ justifyContent: 'center' }}>
                                    <Button variant="contained" color="secondary" onClick={() => handleDelete(item.cartDetailsId)}>
                                        <FaTrashAlt /> Delete
                                    </Button>
                                </CardActions>
                            </Collapse>
                        </CardContent>
                    </StyledCard>
                ))}
            </Box>
        </Container>
    );
};

export default CartPage;
