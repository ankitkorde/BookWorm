package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.ProductBeneficiary;
import com.Project.BookWorm.Repository.ProductBeneficiaryRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ProductBeneficiaryService {

    @Autowired
    private ProductBeneficiaryRepository productBeneficiaryRepository;

    // Get all product beneficiaries
    public List<ProductBeneficiary> getAllProductBeneficiaries() {
        return productBeneficiaryRepository.findAll();
    }

    // Get product beneficiary by ID
    public Optional<ProductBeneficiary> getProductBeneficiaryById(int id) {
        return productBeneficiaryRepository.findById(id);
    }

    // Get product beneficiary by product ID
    public List<ProductBeneficiary> getProductBeneficiaryByProductId(int productId) {
        return productBeneficiaryRepository.findByProductId(productId);
    }

    // Create or update product beneficiary
    public ProductBeneficiary saveProductBeneficiary(ProductBeneficiary productBeneficiary) {
        return productBeneficiaryRepository.save(productBeneficiary);
    }

    // Delete product beneficiary by ID
    public void deleteProductBeneficiary(int id) {
        productBeneficiaryRepository.deleteById(id);
    }
}
