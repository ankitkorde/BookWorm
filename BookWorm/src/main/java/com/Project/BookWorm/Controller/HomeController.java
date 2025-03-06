package com.Project.BookWorm.Controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

//@CrossOrigin("http://localhost:3000/")
@RestController
public class HomeController {

    @GetMapping("/book")
    public List<Map<String, Object>> getBooks() {
        // Creating dummy data directly without a model
        Map<String, Object> book1 = new HashMap<>();
        book1.put("title", "Book One");
        book1.put("author", "Author One");
        book1.put("year", 2021);

        Map<String, Object> book2 = new HashMap<>();
        book2.put("title", "Book Two");
        book2.put("author", "Author Two");
        book2.put("year", 2022);

        Map<String, Object> book3 = new HashMap<>();
        book3.put("title", "Book Three");
        book3.put("author", "Author Three");
        book3.put("year", 2023);

        // Return a list of maps as JSON
        return Arrays.asList(book1, book2, book3);
    }
}
