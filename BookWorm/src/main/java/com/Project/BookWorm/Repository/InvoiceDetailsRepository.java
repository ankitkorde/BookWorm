package com.Project.BookWorm.Repository;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import com.Project.BookWorm.Models.InvoiceDetails;

@Repository
public interface InvoiceDetailsRepository extends JpaRepository<InvoiceDetails, Integer> {

	@Query(value = "SELECT * FROM invoice_details WHERE inv_dtl_id = :invoiceDetailsId", nativeQuery = true)
	Optional<InvoiceDetails> findByInvoiceDetailsId(int invoiceDetailsId);

	@Query(value = "SELECT * FROM invoice_details WHERE invoice_id = :invoiceId", nativeQuery = true)
	List<InvoiceDetails> findByInvoiceId(int invoiceId);
}
