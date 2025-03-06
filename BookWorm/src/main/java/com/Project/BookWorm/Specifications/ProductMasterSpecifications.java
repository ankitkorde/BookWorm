package com.Project.BookWorm.Specifications;

import com.Project.BookWorm.Models.ProductMaster;
import org.springframework.data.jpa.domain.Specification;

public class ProductMasterSpecifications {

    // Specification for filtering by product name
    public static Specification<ProductMaster> hasProductName(String productName) {
        return (root, query, criteriaBuilder) -> 
            criteriaBuilder.like(root.get("productName"), "%" + productName + "%");
    }

    // Specification for filtering by product author
    public static Specification<ProductMaster> hasAuthor(String author) {
        return (root, query, criteriaBuilder) -> 
            criteriaBuilder.like(root.get("productAuthor"), "%" + author + "%");
    }

    // Specification for filtering by product genre
    public static Specification<ProductMaster> hasGenre(String genre) {
        return (root, query, criteriaBuilder) -> 
            criteriaBuilder.like(root.get("productGenre").get("genreDesc"), "%" + genre + "%");
    }

    // Specification for filtering by product type
    public static Specification<ProductMaster> hasType(String type) {
        return (root, query, criteriaBuilder) -> 
            criteriaBuilder.like(root.get("productType").get("typeDesc"), "%" + type + "%");
    }

    // Specification for filtering by product language
    public static Specification<ProductMaster> hasLanguage(String language) {
        return (root, query, criteriaBuilder) -> 
            criteriaBuilder.like(root.get("productLang").get("languageDesc"), "%" + language + "%");
    }
}
