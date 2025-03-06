package com.Project.BookWorm.Repository;

import com.Project.BookWorm.Models.LanguageMaster;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface LanguageMasterRepository extends JpaRepository<LanguageMaster, Integer> {
    // Add custom queries here if needed, e.g., find by language description
    // List<LanguageMaster> findByLanguageDesc(String languageDesc);
}
