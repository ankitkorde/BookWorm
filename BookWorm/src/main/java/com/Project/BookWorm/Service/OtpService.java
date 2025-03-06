package com.Project.BookWorm.Service;




import org.springframework.stereotype.Service;
import java.util.HashMap;
import java.util.Random;

@Service
public class OtpService {
    private final HashMap<String, String> otpStorage = new HashMap<>();
    
    public String generateOtp(String email) {
        String otp = String.valueOf(100000 + new Random().nextInt(900000)); // 6-digit OTP
        otpStorage.put(email, otp);
        return otp;
    }

    public boolean validateOtp(String email, String otp) {
        return otpStorage.containsKey(email) && otpStorage.get(email).equals(otp);
    }
}

