package com.Project.BookWorm.Controller;

import com.Project.BookWorm.Models.MyShelf;
import com.Project.BookWorm.Models.MyShelfDetails;
import com.Project.BookWorm.Service.MyShelfService;
import com.Project.BookWorm.dto.MyShelfRequestDTO;
import com.Project.BookWorm.Service.MyShelfDetailsService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Date;
import java.util.List;

@RestController
@RequestMapping("/api/myshelf")
@CrossOrigin("*")
public class MyShelfController {

    @Autowired
    private MyShelfService myShelfService;

    @Autowired
    private MyShelfDetailsService myShelfDetailsService;

    // Get MyShelf by customer ID (JWT token required)
    @GetMapping("/customer/{customerId}")
    public ResponseEntity<MyShelf> getMyShelfByCustomerId(@PathVariable int customerId) {
        MyShelf myShelf = myShelfService.getMyShelfByCustomer(customerId);
        return myShelf != null ? new ResponseEntity<>(myShelf, HttpStatus.OK)
                               : new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }
    
    @GetMapping("/{shelfId}/product/{productId}")
    public ResponseEntity<?> checkProductInShelf(@PathVariable Integer shelfId, @PathVariable Integer productId) {
        boolean exists = myShelfDetailsService.isProductInShelf(shelfId, productId);
        return exists ? new ResponseEntity<>(HttpStatus.OK)
                      : new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

    // Create a new MyShelf (automatically created when customer registers)
    @PostMapping
    public ResponseEntity<MyShelf> createMyShelf(@RequestBody MyShelf myShelf) {
        MyShelf createdShelf = myShelfService.createMyShelf(myShelf);
        return new ResponseEntity<>(createdShelf, HttpStatus.CREATED);
    }

    // Update MyShelf (no need for now unless you want to change shelf capacity, etc.)
    @PutMapping("/{shelfId}")
    public ResponseEntity<MyShelf> updateMyShelf(@PathVariable Integer shelfId, @RequestBody MyShelf myShelf) {
        MyShelf updatedShelf = myShelfService.updateMyShelf(shelfId, myShelf);
        return updatedShelf != null ? new ResponseEntity<>(updatedShelf, HttpStatus.OK)
                                   : new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

    // Delete MyShelf (optional based on your business logic)
    @DeleteMapping("/{shelfId}")
    public ResponseEntity<Void> deleteMyShelf(@PathVariable Integer shelfId) {
        myShelfService.deleteMyShelf(shelfId);
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }

    // Add product to shelf (create a MyShelfDetails record)
    @PostMapping("/add")
    public ResponseEntity<MyShelfDetails> addProductToShelf(@RequestBody MyShelfRequestDTO myShelfRequest) {
        MyShelfDetails myShelfDetails = myShelfDetailsService.addProductToShelf(
            myShelfRequest.getShelfId(),
            myShelfRequest.getProductId(),
            myShelfRequest.getExpiryDate(),
            myShelfRequest.getTranType()
        );
        return new ResponseEntity<>(myShelfDetails, HttpStatus.CREATED);
    }

    // Get all products in a specific shelf
    @GetMapping("/{shelfId}/details")
    public ResponseEntity<List<MyShelfDetails>> getShelfDetails(@PathVariable Integer shelfId) {
        List<MyShelfDetails> shelfDetails = myShelfDetailsService.getShelfDetails(shelfId);
        return shelfDetails != null && !shelfDetails.isEmpty() ? new ResponseEntity<>(shelfDetails, HttpStatus.OK)
                                                             : new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

    // Remove a product from a shelf (delete MyShelfDetails)
    @DeleteMapping("/{shelfId}/details/{shelfDetailId}")
    public ResponseEntity<Void> removeProductFromShelf(@PathVariable Integer shelfId, @PathVariable Integer shelfDetailId) {
        myShelfDetailsService.deleteMyShelfDetails(shelfDetailId);
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }
}
