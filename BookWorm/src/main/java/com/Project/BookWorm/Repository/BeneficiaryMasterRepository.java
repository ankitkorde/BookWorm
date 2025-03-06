package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.BeneficiaryMaster;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface BeneficiaryMasterRepository extends JpaRepository<BeneficiaryMaster, Integer> {
    // You can add custom queries here if needed
}
