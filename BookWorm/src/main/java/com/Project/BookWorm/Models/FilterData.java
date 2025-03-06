package com.Project.BookWorm.Models;

import java.util.List;

public class FilterData {
    private List<String> authors;
    private List<GenreMaster> genres;
    private List<LanguageMaster> languages;
    private List<ProductTypeMaster> types;

    // Custom Getter and Setter for authors
    public List<String> getAuthors() {
        return authors;
    }

    public void setAuthors(List<String> authors) {
        this.authors = authors;
    }

    // Custom Getter and Setter for genres
    public List<GenreMaster> getGenres() {
        return genres;
    }

    public void setGenres(List<GenreMaster> genres) {
        this.genres = genres;
    }

    // Custom Getter and Setter for languages
    public List<LanguageMaster> getLanguages() {
        return languages;
    }

    public void setLanguages(List<LanguageMaster> languages) {
        this.languages = languages;
    }

    // Custom Getter and Setter for types
    public List<ProductTypeMaster> getTypes() {
        return types;
    }

    public void setTypes(List<ProductTypeMaster> types) {
        this.types = types;
    }
}
