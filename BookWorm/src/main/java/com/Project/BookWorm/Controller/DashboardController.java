package com.Project.BookWorm.Controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import java.util.HashMap;
import java.util.Map;

@RestController
@RequestMapping("/api")
public class DashboardController {

    @GetMapping("/dashboard")
    public Map<String, Object> getDashboard() {
        Map<String, Object> response = new HashMap<>();
        response.put("message", "Welcome to the dashboard!");
        return response;
    }
}
