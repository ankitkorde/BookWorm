package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.CartMaster;
import com.Project.BookWorm.Models.CustomerMaster;
import com.Project.BookWorm.Models.RoyaltyCalculation;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.Optional;

public interface CartMasterRepository extends JpaRepository<CartMaster, Integer> {

    @Query(value = "SELECT * FROM cart_master WHERE customer_id = :customerId", nativeQuery = true)
    Optional<CartMaster> findByCustomerId(int customerId);

    @Query(value = "SELECT * FROM cart_master WHERE customer_id = :customerId AND is_active = true", nativeQuery = true)
    Optional<CartMaster> findByCustomerIdAndIsActive(@Param("customerId") long customerId);

    @Query(value = "SELECT * FROM cart_master WHERE cart_id = :cartId", nativeQuery = true)
	Optional<CartMaster> findByCartId(int cartId);
}
