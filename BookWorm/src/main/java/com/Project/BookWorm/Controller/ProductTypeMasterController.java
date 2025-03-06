package com.Project.BookWorm.Controller;

import com.Project.BookWorm.Models.ProductTypeMaster;
import com.Project.BookWorm.Service.ProductTypeMasterService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/productType")
public class ProductTypeMasterController {

    @Autowired
    private ProductTypeMasterService productTypeMasterService;

    // Create or Update
    @PostMapping
    public ResponseEntity<ProductTypeMaster> createOrUpdateProductType(@RequestBody ProductTypeMaster productTypeMaster) {
        ProductTypeMaster savedProductType = productTypeMasterService.saveProductType(productTypeMaster);
        return new ResponseEntity<>(savedProductType, HttpStatus.CREATED);
    }

    // Get All
    @GetMapping
    public ResponseEntity<List<ProductTypeMaster>> getAllProductTypes() {
        List<ProductTypeMaster> productTypes = productTypeMasterService.getAllProductTypes();
        return new ResponseEntity<>(productTypes, HttpStatus.OK);
    }

    // Get by ID
    @GetMapping("/{id}")
    public ResponseEntity<ProductTypeMaster> getProductTypeById(@PathVariable int id) {
        Optional<ProductTypeMaster> productType = productTypeMasterService.getProductTypeById(id);
        return productType.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.status(HttpStatus.NOT_FOUND).build());
    }

    // Delete by ID
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteProductType(@PathVariable int id) {
        productTypeMasterService.deleteProductTypeById(id);
        return ResponseEntity.noContent().build();
    }
}
