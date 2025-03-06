import React, { useEffect, useState } from 'react';
import { FaFilter } from "react-icons/fa"; // Import filter icon
import { BsCartPlus } from "react-icons/bs"; // Import cart icon
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const ProductDisplay = ({ searchQuery }) => {
    const [products, setProducts] = useState([]);
    const [filteredProducts, setFilteredProducts] = useState([]);
    const [error, setError] = useState(null);
    const [languageDesc, setLanguageDesc] = useState('');
    const [productType, setproductType] = useState('');
    const [genreDesc, setGenreDesc] = useState('');

    const fetchAllProducts = () => {
        const token = sessionStorage.getItem('token');
        fetch('http://localhost:8080/api/products', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then(response => response.ok ? response.json() : Promise.reject('Network error'))
            .then(data => {
                setProducts(data);
                setFilteredProducts(data);
            })
            .catch(error => {
                setError(error);
                toast.error('Failed to fetch products');
            });
    };

    useEffect(() => {
        fetchAllProducts();
    }, []);

    useEffect(() => {
        const token = sessionStorage.getItem('token');
        if (languageDesc || productType || genreDesc) {
            const query = new URLSearchParams({
                ...(languageDesc && { languageDesc }),
                ...(productType && { productType }),
                ...(genreDesc && { genreDesc }),
            }).toString();

            fetch(`http://localhost:8080/api/products/filter?${query}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
                .then(response => response.ok ? response.json() : Promise.reject('Network error'))
                .then(data => setFilteredProducts(data))
                .catch(error => {
                    setError(error);
                    toast.error('Failed to filter products');
                });
        } else {
            setFilteredProducts(products);
        }
    }, [languageDesc, productType, genreDesc, products]);

    useEffect(() => {
        if (searchQuery) {
            const filtered = products.filter(product =>
                product.productName.toLowerCase().includes(searchQuery.toLowerCase())
            );
            setFilteredProducts(filtered);
        } else {
            setFilteredProducts(products);
        }
    }, [searchQuery, products]);

    if (error) return <div>Error: {error.message}</div>;

    const fetchCustomerIdByEmail = async () => {
        try {
            const email = sessionStorage.getItem('customerEmail');
            const token = sessionStorage.getItem('token');
            const response = await fetch(`http://localhost:8080/api/customers/email/${email}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const data = await response.json();
            return data.customerid;
        } catch (error) {
            console.error('There was a problem with the fetch operation:', error);
            toast.error('Failed to fetch customer ID');
            return null;
        }
    };

    const addToCart = async (product) => {
        const customerId = await fetchCustomerIdByEmail();
        if (!customerId) {
            console.error('Failed to fetch customer ID');
            return;
        }
        const token = sessionStorage.getItem('token');

        // Check if the product is already in the cart
        const isProductInCartResponse = await fetch(`http://localhost:8080/api/cart-details/customer/${customerId}/product/${product.productId}`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        if (isProductInCartResponse.status === 200) {  // If product is in cart
            toast.error(`Product ${product.productName} is already present in the cart`);
            return;
        }

        const quantity = 1; // Replace with the desired quantity
        const rentNoOfDays = 0; // Replace with the desired rent number of days
        const transType = ""; // Replace with the desired transaction type

        fetch(`http://localhost:8080/api/cart-details/add`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify({
                customerId,
                productId: product.id, // Use the product ID of the clicked product
                quantity,
                rentNoOfDays,
                transType,
                product // Send the product data
            }),
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            toast.success(`Product added to cart`);
            return response.json();
            
        })
        .then(data => {
            console.log(`Added ${product.productName} to cart`, data);
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
            toast.error('Failed to add product to cart');
        });
    };

    return (
        <div className="product-page">
            <ToastContainer />
            <div className="filter-section">
                {/* <h3><FaFilter /> Filters</h3> */}
                <select onChange={(e) => setLanguageDesc(e.target.value)}>
                    <option value="">Language</option>
                    <option value="English">English</option>
                    <option value="Hindi">Hindi</option>
                    <option value="French">French</option>
                    <option value="Marathi">Marathi</option>
                </select>
                <select onChange={(e) => setproductType(e.target.value)}>
                    <option value="">Type</option>
                    <option value="eBook">E-Books</option>
                    <option value="eComic">E-Comics</option>
                    <option value="AudioBook">Audio Books</option>
                    <option value="Videos">Videos</option>
                </select>
                <select onChange={(e) => setGenreDesc(e.target.value)}>
                    <option value="">Genre</option>
                    <option value="action">Action</option>
                    <option value="Horror">Horror</option>
                    <option value="Comedy">Comedy</option>
                    <option value="Fantasy">Fantasy</option>
                </select>
            </div>

            <div className="grid-container">
                {filteredProducts.map(product => (
                    <div key={product.id} className="product-card">
                        <img src={product.imgSrc} alt={product.productName} onError={(e) => e.target.src='default-image.jpg'} />
                        <h2>{product.productName}</h2>
                        <p className="description">{product.productDescriptionShort}</p>
                        <p className="author">By {product.productAuthor}</p>
                        <p className="price">Price: ${product.productBasePrice}</p>
                        <button className="cart-button" onClick={() => addToCart(product)}>
                            <BsCartPlus /> Add to Cart
                        </button>
                    </div>
                ))}
            </div>

            <style jsx>{`
                .product-page {
                    display: flex;
                    flex-direction: column;
                    align-items: center;
                    padding: 20px;
                    background-color: #f5f5f5;
                }
                
                .filter-section {
                    display: flex;
                    gap: 15px;
                    padding: 10px 20px;
                    background: white;
                    border-radius: 10px;
                    box-shadow: 0px 4px 6px rgba(0,0,0,0.1);
                    position: sticky;
                    top: 0;
                    z-index: 10;
                    width: 80%;
                    justify-content: center;
                    margin-bottom: 20px;
                }
                
                .filter-section select {
                    padding: 8px;
                    border-radius: 5px;
                    border: 1px solid #ddd;
                    cursor: pointer;
                }
                
                .grid-container {
                    display: grid;
                    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
                    gap: 20px;
                    width: 100%;
                    max-width: 1200px;
                }
                
                .product-card {
                    background: white;
                    padding: 15px;
                    border-radius: 10px;
                    box-shadow: 0px 4px 8px rgba(0,0,0,0.1);
                    transition: transform 0.3s ease, box-shadow 0.3s ease;
                    text-align: center;
                }
                
                .product-card:hover {
                    transform: translateY(-5px);
                    box-shadow: 0px 6px 12px rgba(0,0,0,0.2);
                }
                
                .product-card img {
                    width: 100%;
                    height: auto;
                    border-radius: 10px;
                }
                
                .product-card h2 {
                    font-size: 1.2rem;
                    color: #333;
                    margin: 10px 0;
                }
                
                .description {
                    font-size: 0.9rem;
                    color: #666;
                    margin-bottom: 10px;
                }
                
                .author {
                    font-size: 0.9rem;
                    font-weight: bold;
                    color: #444;
                }
                
                .price {
                    font-size: 1.1rem;
                    font-weight: bold;
                    color: #28a745;
                    margin: 5px 0;
                }
                
                .cart-button {
                    background: #007bff;
                    color: white;
                    border: none;
                    padding: 8px 12px;
                    border-radius: 5px;
                    cursor: pointer;
                    display: flex;
                    align-items: center;
                    justify-content: center;
                    gap: 5px;
                    font-size: 1rem;
                    transition: background 0.3s ease;
                }
                
                .cart-button:hover {
                    background: #0056b3;
                }

                @media (max-width: 768px) {
                    .filter-section {
                        flex-direction: column;
                        width: 100%;
                        align-items: center;
                    }
                    .grid-container {
                        grid-template-columns: repeat(auto-fit, minmax(180px, 1fr));
                    }
                }
            `}</style>
        </div>
    );
};

export default ProductDisplay;
