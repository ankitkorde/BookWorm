package com.Project.BookWorm.Controller;

import com.Project.BookWorm.Service.EmailService;
import com.Project.BookWorm.Service.OtpService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.Map;

@RestController
@RequestMapping("/api")
@CrossOrigin("*")
public class OtpController {

    @Autowired
    private OtpService otpService;
    
    @Autowired
    private EmailService emailService;

    @PostMapping("/send-otp")
    public Map<String, String> sendOtp(@RequestBody Map<String, String> request) {
        String email = request.get("email");
        String otp = otpService.generateOtp(email);
        emailService.sendOtpEmail(email, otp);

        Map<String, String> response = new HashMap<>();
        response.put("message", "OTP sent successfully");
        return response;
    }

    @PostMapping("/verify-otp")
    public Map<String, String> verifyOtp(@RequestBody Map<String, String> request) {
        String email = request.get("email");
        String otp = request.get("otp");

        Map<String, String> response = new HashMap<>();
        if (otpService.validateOtp(email, otp)) {
            response.put("message", "OTP verified successfully");
        } else {
            response.put("message", "Invalid OTP");
        }
        return response;
    }
}



