package com.Project.BookWorm.Repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.Project.BookWorm.Models.ProductMaster;

import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

@Repository
public interface ProductMasterRepository extends JpaRepository<ProductMaster, Integer>, JpaSpecificationExecutor<ProductMaster> {
    
    // Your custom queries here (like the one for productType)
    @Query("SELECT p FROM ProductMaster p JOIN FETCH p.productType WHERE p.productType.id = :typeId")
    List<ProductMaster> findByProductTypeId(@Param("typeId") int typeId);
    // @Query(value = "Select * from product_master join language_master where language_id=:id", nativeQuery = true)
    // List<ProductMaster> findByLanguageId(@Param("id") int id);
    // @Query(value = "Select * from product_master join genre_master where genre_id=:id", nativeQuery = true)
    // List<ProductMaster> findByGenreId(@Param("id") int id);
//     @Query("SELECT p FROM ProductMaster p " +
//             "JOIN p.GenreMaster g " +
//             "JOIN p.language_master l " +
//             "WHERE (:genreDesc IS NULL OR g.genreDesc = :genreDesc) " +
//             "AND (:languageDesc IS NULL OR l.languageDesc = :languageDesc)")
//     List<ProductMaster> findProductsByFilters(
//             @Param("genreId") int genreId, 
//             @Param("languageId") int languageId);
// @Query("SELECT p FROM ProductMaster p " +
//             "JOIN p.productGenre g " +
//             "JOIN p.productLang l " +
//             "WHERE (:genreDesc IS NULL OR g.genreDesc = :genreDesc) " +
//             "AND (:languageDesc IS NULL OR l.languageDesc = :languageDesc)")
//     List<ProductMaster> findProductsByFilters(
//             @Param("genreDesc") String genreDesc, 
//             @Param("languageDesc") String languageDesc);
@Query("SELECT p FROM ProductMaster p WHERE (:genreDesc IS NULL OR p.productGenre.genreDesc = :genreDesc) AND (:languageDesc IS NULL OR p.productLang.languageDesc = :languageDesc) AND (:productType IS NULL OR p.productType.TypeDesc = :productType)")
    List<ProductMaster> findProductsByFilters(@Param("genreDesc") String genreDesc, @Param("languageDesc") String languageDesc, @Param("productType") String productType);
    
}
