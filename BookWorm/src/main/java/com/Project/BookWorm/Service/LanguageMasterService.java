package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.LanguageMaster;
import com.Project.BookWorm.Models.ProductTypeMaster;
import com.Project.BookWorm.Repository.LanguageMasterRepository;
import com.Project.BookWorm.Repository.ProductTypeMasterRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.List;

@Service
public class LanguageMasterService {
    
    @Autowired
    private LanguageMasterRepository languageMasterRepository;

    @Autowired
    private ProductTypeMasterRepository productTypeMasterRepository;

    // Fetch all languages
    public List<LanguageMaster> getAllLanguages() {
        return languageMasterRepository.findAll();
    }

    public LanguageMaster saveLanguage(LanguageMaster languageMaster) {
        return languageMasterRepository.save(languageMaster);
    }


    // Get a language by id
    public LanguageMaster getLanguageById(int id) {
        return languageMasterRepository.findById(id).orElse(null);
    }

    // Delete language by id
    public void deleteById(int id) {
        languageMasterRepository.deleteById(id);
    }

    // Update a language
    public LanguageMaster updateLanguage(int id, LanguageMaster languageMaster) {
        if (languageMasterRepository.existsById(id)) {
            languageMaster.setLanguageId(id);
            return languageMasterRepository.save(languageMaster);
        }
        return null;
    }

    // Create a new language
    public LanguageMaster createLanguage(LanguageMaster languageMaster) {
        // Get the ProductTypeMaster by typeId
        return languageMasterRepository.save(languageMaster);
    }
    
    // Add multiple languages
    public List<LanguageMaster> addMultipleLanguages(List<LanguageMaster> languages) {

        return languageMasterRepository.saveAll(languages);
    }
}
