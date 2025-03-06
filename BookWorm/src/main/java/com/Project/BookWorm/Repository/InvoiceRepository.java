package com.Project.BookWorm.Repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import com.Project.BookWorm.Models.Invoice;

@Repository
public interface InvoiceRepository extends JpaRepository<Invoice, Integer> {

	@Query(value = "SELECT * FROM invoice WHERE invoice_id = :invoiceId", nativeQuery = true)
	Optional<Invoice> findByInvoiceId(int invoiceId);
}
