package com.Project.BookWorm.Controller;

import com.Project.BookWorm.Models.LanguageMaster;
import com.Project.BookWorm.Service.LanguageMasterService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/languages")
public class LanguageMasterController {

    @Autowired
    private LanguageMasterService languageMasterService;

    // Create a new language
    @PostMapping
    public ResponseEntity<LanguageMaster> createLanguage(@RequestBody LanguageMaster languageMaster) {
        LanguageMaster createdLanguage = languageMasterService.createLanguage(languageMaster);
        return new ResponseEntity<>(createdLanguage, HttpStatus.CREATED);
    }

    // Add multiple languages at once
    @PostMapping("/bulk")
    public ResponseEntity<List<LanguageMaster>> addMultipleLanguages(@RequestBody List<LanguageMaster> languages) {
        List<LanguageMaster> savedLanguages = languageMasterService.addMultipleLanguages(languages);
        return new ResponseEntity<>(savedLanguages, HttpStatus.CREATED);
    }

    // Retrieve all languages
    @GetMapping
    public ResponseEntity<List<LanguageMaster>> getAllLanguages() {
        List<LanguageMaster> languages = languageMasterService.getAllLanguages();
        return new ResponseEntity<>(languages, HttpStatus.OK);
    }

    // Retrieve a language by ID
    @GetMapping("/{id}")
    public ResponseEntity<LanguageMaster> getLanguageById(@PathVariable int id) {
        LanguageMaster language = languageMasterService.getLanguageById(id);
        return language != null ? new ResponseEntity<>(language, HttpStatus.OK)
                : new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

    // Update an existing language
    @PutMapping("/{id}")
    public ResponseEntity<LanguageMaster> updateLanguage(@PathVariable int id, @RequestBody LanguageMaster languageMaster) {
        LanguageMaster updatedLanguage = languageMasterService.updateLanguage(id, languageMaster);
        return updatedLanguage != null ? new ResponseEntity<>(updatedLanguage, HttpStatus.OK)
                : new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

    // Delete a language
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteLanguage(@PathVariable int id) {
        languageMasterService.deleteById(id);
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }
}
