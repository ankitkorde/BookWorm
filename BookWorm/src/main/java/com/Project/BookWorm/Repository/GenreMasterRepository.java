package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.GenreMaster;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface GenreMasterRepository extends JpaRepository<GenreMaster, Integer> {
    // Optional: Add custom queries if needed
}
