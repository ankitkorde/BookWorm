package com.Project.BookWorm.Repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.Project.BookWorm.Models.ProductTypeMaster;

@Repository
public interface ProductTypeRepository extends JpaRepository<ProductTypeMaster, Integer> {

}
