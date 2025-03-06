package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.RoyaltyCalculation;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface RoyaltyCalculationRepository extends JpaRepository<RoyaltyCalculation, Integer> {

    @Query("SELECT r.royaltyOnSalesPrice FROM RoyaltyCalculation r WHERE r.invoice.invoiceId = :invoiceId AND r.product.productId = :productId")
    double findByInvoiceIdAndProductId(int invoiceId, int productId);
}
