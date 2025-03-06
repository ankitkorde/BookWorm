package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.ProductBeneficiary;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ProductBeneficiaryRepository extends JpaRepository<ProductBeneficiary, Integer> {

    @Query("SELECT p FROM ProductBeneficiary p WHERE p.productMaster.productId = :productId")
    List<ProductBeneficiary> findByProductId(int productId);
}
