package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.FilterData;
import com.Project.BookWorm.Models.GenreMaster;
import com.Project.BookWorm.Models.LanguageMaster;
import com.Project.BookWorm.Models.ProductTypeMaster;
import com.Project.BookWorm.Repository.GenreMasterRepository;
import com.Project.BookWorm.Repository.LanguageMasterRepository;
import com.Project.BookWorm.Repository.ProductTypeMasterRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProductFilterService {

    @Autowired
    private GenreMasterRepository genreRepository;

    @Autowired
    private LanguageMasterRepository languageRepository;

    @Autowired
    private ProductTypeMasterRepository productTypeRepository;

    // Method to get all the filter options for dropdowns
    public FilterData getFilterOptions() {
        FilterData filterData = new FilterData();
        
        List<String> authors = getAuthors(); // Method to get authors
        List<GenreMaster> genres = genreRepository.findAll();
        List<LanguageMaster> languages = languageRepository.findAll();
        List<ProductTypeMaster> types = productTypeRepository.findAll();

        filterData.setAuthors(authors);
        filterData.setGenres(genres);
        filterData.setLanguages(languages);
        filterData.setTypes(types);

        return filterData;
    }

    // Example method to fetch authors (you could implement as needed)
    private List<String> getAuthors() {
        // Implement the logic to fetch authors from the database (or create a custom repository query)
        return List.of("Author1", "Author2", "Author3");
    }
}
