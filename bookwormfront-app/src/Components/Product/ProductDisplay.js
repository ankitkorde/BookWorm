import React from 'react';
import { Card, CardContent, CardActions, Button, Typography, Box } from '@mui/material';
import { styled } from '@mui/system';

const StyledCard = styled(Card)(({ theme }) => ({
    margin: '20px',
    width: '300px',
    justifyContent: 'center',
    transition: 'transform 0.3s ease, box-shadow 0.3s ease',
    '&:hover': {
        transform: 'translateY(-5px)',
        boxShadow: '0px 6px 12px rgba(0, 0, 0, 0.2)',
        
    },
}));

const ProductDisplay = ({ product, onAddToCart }) => {
    return (
        <StyledCard>
            <CardContent>
                <Box display="flex" justifyContent="center">
                    <img src={product.imageUrl} alt={product.productName} style={{ maxWidth: '100%', height: 'auto' }} />
                </Box>
                <Typography variant="h6" gutterBottom align="center">
                    {product.productName}
                </Typography>
                <Typography variant="body2" color="textSecondary" align="center">
                    {product.productDescriptionShort}
                </Typography>
                <Typography variant="h6" color="primary" align="center">
                    ${product.productBasePrice}
                </Typography>
            </CardContent>
            <CardActions style={{ justifyContent: 'center' }}>
                <Button variant="contained" color="primary" onClick={() => onAddToCart(product)}>
                    Add to Cart
                </Button>
            </CardActions>
        </StyledCard>
    );
};

export default ProductDisplay;
