package com.Project.BookWorm.Controller;

import com.Project.BookWorm.Models.CartDetails;
import com.Project.BookWorm.Models.CartMaster;
import com.Project.BookWorm.Service.CartDetailsService;
import com.Project.BookWorm.Service.CartMasterService;
import com.Project.BookWorm.dto.CartDetailsRequestDTO;
import com.Project.BookWorm.Repository.CartMasterRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.repository.query.Param;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.Date;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/cart-details")
@CrossOrigin("*")
public class CartDetailsController {

    private static final Logger logger = LoggerFactory.getLogger(CartDetailsController.class);

    @Autowired
    private CartDetailsService cartDetailsService;

    @Autowired
    private CartMasterRepository cartMasterRepository;

    @Autowired
    private CartMasterService cartMasterService;

    // Add product to a customer's cart
    @PostMapping("/add")
    public ResponseEntity<CartDetails> addProductToCart(@RequestBody CartDetailsRequestDTO cartDetailsRequest) {

        // Add product to the cart if cart_master exists
        CartDetails cartDetails = cartDetailsService.addProductToCart(
            cartDetailsRequest.getCustomerId(),
            cartDetailsRequest.getProductId(),
            cartDetailsRequest.getQuantity(),
            cartDetailsRequest.getTransType(),
            cartDetailsRequest.getProduct()
        );
        logger.info("Product added to cart: " + cartDetails);

        // Update the cart cost
        cartMasterService.updateCartCost(cartMasterRepository.findByCustomerIdAndIsActive(cartDetailsRequest.getCustomerId()).get());

        return new ResponseEntity<>(cartDetails, HttpStatus.CREATED);
    }

    // Get all cart details
    @GetMapping
    public List<CartDetails> getAllCartDetails() {
        return cartDetailsService.getAllCartDetails();
    }

    // Get cart details by ID
    @GetMapping("/{id}")
    public ResponseEntity<CartDetails> getCartDetailsById(@PathVariable int id) {
        Optional<CartDetails> cartDetails = cartDetailsService.getCartDetailsById(id);
        return cartDetails.map(value -> new ResponseEntity<>(value, HttpStatus.OK))
                .orElseGet(() -> new ResponseEntity<>(HttpStatus.NOT_FOUND));
    }

    // Get cart details by customer ID
    @GetMapping("/customer/{customerId}")
    public ResponseEntity<List<CartDetails>> getCartDetailsByCustomerId(@PathVariable int customerId) {
        Optional<CartMaster> cartMasterOptional = cartMasterRepository.findByCustomerIdAndIsActive(customerId);
        if (!cartMasterOptional.isPresent()) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        List<CartDetails> cartDetails = cartDetailsService.getCartDetailsByCartId(cartMasterOptional.get().getCartId());
        return new ResponseEntity<>(cartDetails, HttpStatus.OK);
    }

    // Check if product is in cart
    @GetMapping("/customer/{customerId}/product/{productId}")
    public ResponseEntity<Void> isProductInCart(@PathVariable Integer customerId, @PathVariable int productId) {
        Optional<CartMaster> cartMasterOptional = cartMasterRepository.findByCustomerIdAndIsActive(customerId);
        if (!cartMasterOptional.isPresent()) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        List<CartDetails> cartDetails = cartDetailsService.getCartDetailsByCartId(cartMasterOptional.get().getCartId());
        boolean productInCart = cartDetails.stream().anyMatch(cd -> cd.getProductId().getProductId() == productId);
        return productInCart ? new ResponseEntity<>(HttpStatus.OK) : new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

    // Update cart details
    @PatchMapping("/{id}")
    public ResponseEntity<CartDetails> updateCartDetails(@RequestBody CartDetails updatedCartDetailsRequest) {
        Optional<CartDetails> existingCartDetails = cartDetailsService.getCartDetailsById(updatedCartDetailsRequest.getCartDetailsId());
        if (!existingCartDetails.isPresent()) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        CartDetails cartDetails = existingCartDetails.get();
        cartDetails.setIsRented(updatedCartDetailsRequest.getIsRented());
        cartDetails.setRentNoOfDays(updatedCartDetailsRequest.getRentNoOfDays());
        cartDetails.setOfferCost(updatedCartDetailsRequest.getOfferCost());
        cartDetailsService.saveCartDetails(cartDetails);
        return new ResponseEntity<>(cartDetails, HttpStatus.OK);
    }

    // Delete cart details by ID
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteCartDetails(@PathVariable int id) {
        Optional<CartDetails> existingCartDetails = cartDetailsService.getCartDetailsById(id);
        if (!existingCartDetails.isPresent()) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        cartDetailsService.deleteCartDetails(id);
        logger.info("Deleted cart details for ID: {}", id);
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }

    @PostMapping("/checkout")
    public ResponseEntity<Void> checkoutCart(@RequestBody Long customerId) {
        cartMasterService.checkoutCart(customerId);
        return new ResponseEntity<>(HttpStatus.OK);
    }
}
