package com.Project.BookWorm.Controller;

import com.Project.BookWorm.Models.GenreMaster;
import com.Project.BookWorm.Models.LanguageMaster;
import com.Project.BookWorm.Service.GenreService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/genres")
public class GenreController {

    @Autowired
    private GenreService genreMasterService;

    // Create a new genre
    @PostMapping
    public ResponseEntity<GenreMaster> createGenre(@RequestBody GenreMaster genreMaster) {
        GenreMaster createdGenre = genreMasterService.createGenre(genreMaster);
        return new ResponseEntity<>(createdGenre, HttpStatus.CREATED);
    }

    @PostMapping("/bulk")
    public ResponseEntity<List<GenreMaster>> createMultipleGenres(@RequestBody List<GenreMaster> genres) {
        List<GenreMaster> savedGenres = genreMasterService.addMultipleGenres(genres);
        return new ResponseEntity<>(savedGenres, HttpStatus.CREATED);
    }
    
    // Retrieve all genres
    @GetMapping
    public ResponseEntity<List<GenreMaster>> getAllGenres() {
        List<GenreMaster> genres = genreMasterService.getAllGenres();
        return new ResponseEntity<>(genres, HttpStatus.OK);
    }

    // Retrieve a genre by ID
    @GetMapping("/{id}")
    public ResponseEntity<GenreMaster> getGenreById(@PathVariable int id) {
        Optional<GenreMaster> genre = genreMasterService.getGenreById(id);
        return genre.map(value -> new ResponseEntity<>(value, HttpStatus.OK))
                    .orElseGet(() -> new ResponseEntity<>(HttpStatus.NOT_FOUND));
    }

    // Update an existing genre
    @PutMapping("/{id}")
    public ResponseEntity<GenreMaster> updateGenre(@PathVariable int id, @RequestBody GenreMaster genreMaster) {
        GenreMaster updatedGenre = genreMasterService.updateGenre(id, genreMaster);
        if (updatedGenre != null) {
            return new ResponseEntity<>(updatedGenre, HttpStatus.OK);
        } else {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
    }

    // Delete a genre
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteGenre(@PathVariable int id) {
        genreMasterService.deleteGenre(id);
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }
}
