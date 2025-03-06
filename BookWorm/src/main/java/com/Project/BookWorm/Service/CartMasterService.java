package com.Project.BookWorm.Service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.Project.BookWorm.Models.CartMaster;
import com.Project.BookWorm.Models.CustomerMaster;
import com.Project.BookWorm.Models.CartDetails;
import com.Project.BookWorm.Repository.CartMasterRepository;
import com.Project.BookWorm.Repository.CustomerMasterRepository;
import com.Project.BookWorm.Repository.CartDetailsRepository;

import java.util.List;
import java.util.Optional;

@Service
public class CartMasterService {
    
    @Autowired
    private CartMasterRepository cartMasterRepository;

    @Autowired
    private CartDetailsRepository cartDetailsRepository;

    @Autowired
    private CustomerMasterRepository customerRepository;

    // Get all carts
    public List<CartMaster> getAllCarts() {
        return cartMasterRepository.findAll();
    }

    // Get cart by ID
    public Optional<CartMaster> getCartById(int id) {
        return cartMasterRepository.findById(id);
    }

    // Create or update cart
    public CartMaster saveCart(CartMaster cartMaster) {
        updateCartCost(cartMaster);
        return cartMasterRepository.save(cartMaster);
    }

    // Delete cart by ID
    public void deleteCart(int id) {
        cartMasterRepository.deleteById(id);
    }

    // Update the cost of the cart by summing all offer_costs of CartDetails
    public void updateCartCost(CartMaster cartMaster) {
        int cartId = cartMaster.getCartId();
        List<CartDetails> cartDetailsList = cartDetailsRepository.findByCartId(cartId);
        double totalCost = cartDetailsList.stream().mapToDouble(CartDetails::getOfferCost).sum();
        cartMaster.setCost(totalCost);
        cartMasterRepository.save(cartMaster); // Save the updated cost to the database
    }

    public void checkoutCart(long customerId) {
        // Fetch the active CartMaster object by customerId
        CartMaster cartMaster = cartMasterRepository.findByCustomerIdAndIsActive(customerId)
                .orElseThrow(() -> new RuntimeException("Active cart not found for customer"));

        // Set the cart as inactive
        cartMaster.setIsActive(false);
        cartMasterRepository.save(cartMaster);

        // Create a new active cart for the customer
        CartMaster newCartMaster = new CartMaster();
        newCartMaster.setIsActive(true);
        newCartMaster.setCost(0.0);
        Optional<CustomerMaster> customertemp=customerRepository.findById(customerId);  
        if(customertemp.isPresent())
        	newCartMaster.setCustomer(customertemp.get());
        cartMasterRepository.save(newCartMaster);
    }

}
