package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.ProductTypeMaster;
import com.Project.BookWorm.Repository.ProductTypeMasterRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ProductTypeMasterService {

    @Autowired
    private ProductTypeMasterRepository productTypeMasterRepository;

    // Create or Update
    public ProductTypeMaster saveProductType(ProductTypeMaster productTypeMaster) {
        return productTypeMasterRepository.save(productTypeMaster);
    }

    // Get All
    public List<ProductTypeMaster> getAllProductTypes() {
        return productTypeMasterRepository.findAll();
    }

    // Get By ID
    public Optional<ProductTypeMaster> getProductTypeById(int id) {
        return productTypeMasterRepository.findById(id);
    }

    // Delete by ID
    public void deleteProductTypeById(int id) {
        productTypeMasterRepository.deleteById(id);
    }
}
