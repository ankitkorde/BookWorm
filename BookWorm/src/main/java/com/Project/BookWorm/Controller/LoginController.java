package com.Project.BookWorm.Controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import com.Project.BookWorm.Service.CustomerMasterService;

import java.util.HashMap;
import java.util.Map;

@CrossOrigin(origins = "http://localhost:3000")
@RestController
@RequestMapping("/api")
public class LoginController {

    @Autowired
    private CustomerMasterService customerMasterService;

    @PostMapping("/login")
    public Map<String, Object> login(@RequestBody Map<String, String> credentials) {
        String email = credentials.get("email");
        String password = credentials.get("password");
        
        Map<String, Object> response = new HashMap<>();

        customerMasterService.authenticateUser(email, password).ifPresentOrElse(token -> {
            response.put("status", "success");
            response.put("message", "Login successful");
            response.put("token", token);
        }, () -> {
            if (customerMasterService.userExists(email)) {
                response.put("status", "error");
                response.put("message", "Invalid password");
            } else {
                response.put("status", "error");
                response.put("message", "User not found");
            }
        });

        return response;
    }
}
