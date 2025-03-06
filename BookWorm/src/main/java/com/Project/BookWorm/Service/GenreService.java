package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.GenreMaster;
import com.Project.BookWorm.Models.LanguageMaster;
import com.Project.BookWorm.Repository.GenreMasterRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class GenreService {

    @Autowired
    private GenreMasterRepository genreMasterRepository;

    // Create a new genre
    public GenreMaster createGenre(GenreMaster genreMaster) {
        return genreMasterRepository.save(genreMaster);
    }

    // Retrieve all genres
    public List<GenreMaster> getAllGenres() {
        return genreMasterRepository.findAll();
    }

    // Retrieve a genre by ID
    public Optional<GenreMaster> getGenreById(int id) {
        return genreMasterRepository.findById(id);
    }

    // Update an existing genre
    public GenreMaster updateGenre(int id, GenreMaster genreMaster) {
        if (genreMasterRepository.existsById(id)) {
            genreMaster.setGenreId(id);
            return genreMasterRepository.save(genreMaster);
        }
        return null; // Handle case where genre doesn't exist
    }

    // Delete a genre by ID
    public void deleteGenre(int id) {
        genreMasterRepository.deleteById(id);
    }
    
    // Add multiple languages
    public List<GenreMaster> addMultipleGenres(List<GenreMaster> genres) {

        return genreMasterRepository.saveAll(genres);
    }
}
