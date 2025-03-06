package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.CustomerMaster;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import java.util.Optional;

public interface CustomerMasterRepository extends JpaRepository<CustomerMaster, Long> {

    // @Query(value = "SELECT * FROM customer_master WHERE customeremail = ?1", nativeQuery = true)
    // Optional<CustomerMaster> getCustomerByEmail(String email);

    Optional<CustomerMaster> findById(Long id);  // Use findById for single ID lookup

    Optional<CustomerMaster> findByCustomeremail(String email);
}
