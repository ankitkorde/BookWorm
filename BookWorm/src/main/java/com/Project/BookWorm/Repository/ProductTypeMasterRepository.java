package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.ProductTypeMaster;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ProductTypeMasterRepository extends JpaRepository<ProductTypeMaster, Integer> {
    // Add custom queries here if needed, e.g., find by type description
    // List<ProductTypeMaster> findByTypeDesc(String typeDesc);
}
