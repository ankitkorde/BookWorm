package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.RentDetails;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.sql.Date;
import java.util.List;

@Repository
public interface RentDetailsRepository extends JpaRepository<RentDetails, Integer> {

}
