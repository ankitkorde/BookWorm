package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.MyShelfDetails;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface MyShelfDetailsRepository extends JpaRepository<MyShelfDetails, Integer> {

    // Get all books in a specific shelf (by shelfId):
    List<MyShelfDetails> findByShelfIdShelfId(Integer shelfId);

    // Custom query to find by productId
    List<MyShelfDetails> findByProductIdProductId(Integer productId);

    // Optional: Retrieve the latest addition to a shelf (by expiryDate):
    List<MyShelfDetails> findTopByShelfIdShelfIdOrderByExpiryDateDesc(Integer shelfId);

    @Query("SELECT m FROM MyShelfDetails m WHERE m.shelfId.shelfId = :shelfId AND m.productId.productId = :productId")
    Optional<MyShelfDetails> findByShelfIdAndProductId(@Param("shelfId") int shelfId, @Param("productId") int productId);

    boolean existsByShelfIdShelfIdAndProductIdProductId(long shelfId, long productId);
}
