package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.CartDetails;
import com.Project.BookWorm.Models.CartMaster;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface CartDetailsRepository extends JpaRepository<CartDetails, Integer> {
    @Query(value = "SELECT * FROM cart_details WHERE cart_id = :cartId", nativeQuery = true)
    List<CartDetails> findByCartId(@Param("cartId") int cartId);
}

