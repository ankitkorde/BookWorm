import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Button } from '@mui/material';

const Product = () => {
    const [products, setProducts] = useState([]);
    const [pagination, setPagination] = useState({
        page: 0,
        size: 10,
        totalPages: 1
    });

    const API_BASE_URL = "http://localhost:8080/api/products";

    // Fetch products on component mount and when pagination changes
    useEffect(() => {
        fetchProducts();
    }, [pagination.page]);

    const fetchProducts = () => {
        const { page, size } = pagination;
        axios.get(`${API_BASE_URL}/getallproducts`, {
            params: {
                page,
                size
            }
        })
        .then(response => {
            setProducts(response.data.content);
            setPagination(prev => ({ ...prev, totalPages: response.data.totalPages }));
        })
        .catch(error => console.error("Error fetching products:", error));
    };

    return (
        <div>
            <h2>Products</h2>

            {/* Product Table */}
            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Product Name</TableCell>
                            <TableCell>Description</TableCell>
                            <TableCell>Price</TableCell>
                            <TableCell>Author</TableCell>
                            <TableCell>Genre</TableCell>
                            <TableCell>Language</TableCell>
                            <TableCell>Type</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {products.length > 0 ? (
                            products.map(product => (
                                <TableRow key={product.productId}>
                                    <TableCell>{product.productName}</TableCell>
                                    <TableCell>{product.productDescriptionShort}</TableCell>
                                    <TableCell>₹{product.productBasePrice}</TableCell>
                                    <TableCell>{product.author}</TableCell>
                                    <TableCell>{product.genre}</TableCell>
                                    <TableCell>{product.language}</TableCell>
                                    <TableCell>{product.type}</TableCell>
                                </TableRow>
                            ))
                        ) : (
                            <TableRow>
                                <TableCell colSpan="7">No products found.</TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </TableContainer>

            {/* Pagination */}
            <div>
                <Button 
                    disabled={pagination.page === 0} 
                    onClick={() => setPagination(prev => ({ ...prev, page: prev.page - 1 }))}>
                    Prev
                </Button>
                
                <span> Page {pagination.page + 1} of {pagination.totalPages} </span>

                <Button 
                    disabled={pagination.page === pagination.totalPages - 1} 
                    onClick={() => setPagination(prev => ({ ...prev, page: prev.page + 1 }))}>
                    Next
                </Button>
            </div>
        </div>
    );
};

export default Product;
