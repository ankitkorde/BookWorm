package com.Project.BookWorm.Controller;

import com.Project.BookWorm.Models.ProductMaster;
import com.Project.BookWorm.Service.ProductMasterService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import java.util.List;
import com.Project.BookWorm.dto.ProductDTO;


import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping("/api/products")
@CrossOrigin("*")
public class ProductMasterController {

    @Autowired
    private ProductMasterService productMasterService;

    // Endpoint to fetch a single product by ID
    @GetMapping("/{id}")
    public ResponseEntity<ProductMaster> getProductById(@PathVariable("id") int productId) {
        Optional<ProductMaster> productMaster = productMasterService.getProductById(productId);
        if (productMaster.isPresent()) {
            return new ResponseEntity<>(productMaster.get(), HttpStatus.OK);
        } else {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
    }
    
    @GetMapping
    public List<ProductMaster> getAllProducts()
    {
    	return productMasterService.getAllProducts();
    }

    // Endpoint to create a new product
    @PostMapping
    public ResponseEntity<ProductMaster> createProduct(@RequestBody ProductMaster productMaster) {
        ProductMaster createdProduct = productMasterService.createProduct(productMaster);
        return new ResponseEntity<>(createdProduct, HttpStatus.CREATED);
    }
    
    @PostMapping("/bulk")
    public ResponseEntity<List<ProductMaster>> createMultipleProducts(@RequestBody List<ProductMaster> products) {
        List<ProductMaster> createdProducts = productMasterService.createMultipleProducts(products);
        return new ResponseEntity<>(createdProducts, HttpStatus.CREATED);
    }

    // Endpoint to update an existing product
    @PutMapping("/{id}")
    public ResponseEntity<ProductMaster> updateProduct(@PathVariable("id") int productId, @RequestBody ProductMaster productMaster) {
        try {
            ProductMaster updatedProduct = productMasterService.updateProduct(productId, productMaster);
            return new ResponseEntity<>(updatedProduct, HttpStatus.OK);
        } catch (RuntimeException e) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
    }
   

    // Endpoint to delete a product
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteProduct(@PathVariable("id") int productId) {
        try {
            productMasterService.deleteProduct(productId);
            return new ResponseEntity<>(HttpStatus.NO_CONTENT);
        } catch (RuntimeException e) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
    }

    @GetMapping("/filter")
    public List<ProductDTO> filterProducts(
            @RequestParam(required = false) String genreDesc,
            @RequestParam(required = false) String languageDesc,
            @RequestParam(required = false) String productType) {
        return productMasterService.getFilteredProducts(genreDesc, languageDesc, productType);
    }
    
}
