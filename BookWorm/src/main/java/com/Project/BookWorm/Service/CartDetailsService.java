package com.Project.BookWorm.Service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.Project.BookWorm.Models.CartDetails;
import com.Project.BookWorm.Models.CartMaster;
import com.Project.BookWorm.Models.ProductMaster;
import com.Project.BookWorm.Models.TransactionType;
import com.Project.BookWorm.Models.CustomerMaster;
import com.Project.BookWorm.Repository.CartDetailsRepository;
import com.Project.BookWorm.Repository.CartMasterRepository;
import com.Project.BookWorm.Repository.ProductMasterRepository;
import com.Project.BookWorm.Repository.CustomerMasterRepository;

import java.util.List;
import java.util.Optional;

@Service
public class CartDetailsService {

    @Autowired
    private CartDetailsRepository cartDetailsRepository;

    @Autowired
    private CartMasterRepository cartMasterRepository;

    @Autowired
    private ProductMasterRepository productRepository;

    @Autowired
    private CustomerMasterRepository customerRepository;

   
    // Method to get all cart details
    public List<CartDetails> getAllCartDetails() {
        return cartDetailsRepository.findAll();
    }

    // Method to get cart details by ID
    public Optional<CartDetails> getCartDetailsById(int id) {
        return cartDetailsRepository.findById(id);
    }

    // Method to get cart details by cart ID
    public List<CartDetails> getCartDetailsByCartId(int cartId) {
        return cartDetailsRepository.findByCartId(cartId);
    }

    public CartDetails addProductToCart(int customerId, int productId, int rentNoOfDays, String transType, ProductMaster product) {
        // Logic to add product to cart
        // Fetch the active CartMaster by customerId
        Optional<CartMaster> cartMasterOptional = cartMasterRepository.findByCustomerIdAndIsActive(customerId);
        if (!cartMasterOptional.isPresent()) {
            throw new RuntimeException("No active cart found for the customer");
        }

        CartMaster cartMaster = cartMasterOptional.get();

        // Create a new CartDetails object
        CartDetails cartDetails = new CartDetails();
        cartDetails.setCartId(cartMaster);
        cartDetails.setProductId(product);
        cartDetails.setIsRented(transType.equalsIgnoreCase("rent"));
        cartDetails.setRentNoOfDays(Math.max(rentNoOfDays, 7)); // Ensure it can't go less than 7
        cartDetails.setOfferCost(cartDetails.getIsRented() ? product.getRentPerDay() * rentNoOfDays : product.getProductBasePrice());

        // Save the CartDetails object
        return cartDetailsRepository.save(cartDetails);
    }

    // Method to save cart details
    public CartDetails saveCartDetails(CartDetails cartDetails) {
        return cartDetailsRepository.save(cartDetails);
    }

    // Method to delete cart details by ID
    public void deleteCartDetails(int id) {
        cartDetailsRepository.deleteById(id);
    }

}
