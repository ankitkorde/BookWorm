package com.Project.BookWorm.Security;

import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import io.jsonwebtoken.io.Decoders;
import io.jsonwebtoken.security.Keys;
import org.springframework.stereotype.Component;

import java.security.Key;
import java.util.Date;

@Component
public class JwtUtil {

   private static final String SECRET_KEY = "yoursecretkeyyoursecretkeyyoursecretkey12345678910"; // Must be 32+ chars
   private static final Key SIGNING_KEY = Keys.hmacShaKeyFor(Decoders.BASE64.decode(SECRET_KEY)); // Static decoded key

   public String generateToken(String email) {
       return Jwts.builder()
               .setSubject(email)
               .setIssuedAt(new Date())
               .setExpiration(new Date(System.currentTimeMillis() + 1000 * 60 * 60 * 10)) // 10 hours
               .signWith(SIGNING_KEY, SignatureAlgorithm.HS256) // Use pre-decoded key
               .compact();
   }

   public Key getSigningKey() {
       return SIGNING_KEY;
   }
}
