package com.Project.BookWorm.Security;

import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import jakarta.servlet.FilterChain;
import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.web.authentication.WebAuthenticationDetailsSource;
import org.springframework.stereotype.Component;
import org.springframework.web.filter.OncePerRequestFilter;

import java.io.IOException;

@Component
public class JwtFilter extends OncePerRequestFilter {

   private final JwtUtil jwtUtil;

   // Constructor Injection to use JwtUtil
   @Autowired
   public JwtFilter(JwtUtil jwtUtil) {
       this.jwtUtil = jwtUtil;
   }

   private String extractEmail(String token) {
       return Jwts.parserBuilder()
               .setSigningKey(jwtUtil.getSigningKey())  // Use the key from JwtUtil
               .build()
               .parseClaimsJws(token)
               .getBody()
               .getSubject();
   }

   private boolean validateToken(String token) {
       try {
           Claims claims = Jwts.parserBuilder()
                   .setSigningKey(jwtUtil.getSigningKey())  // Use the key from JwtUtil
                   .build()
                   .parseClaimsJws(token)
                   .getBody();
           return claims.getExpiration().after(new java.util.Date());
       } catch (Exception e) {
           // Log exception and handle invalid token
           System.out.print(e.getMessage());
           return false;
       }
   }

   @Override
   protected void doFilterInternal(HttpServletRequest request, HttpServletResponse response, FilterChain chain)
           throws ServletException, IOException {

       String path = request.getRequestURI();
       if (path.equals("/api/login")) {
           // Skip JWT filter for login endpoint
           chain.doFilter(request, response);
           return;
       }

       String authorizationHeader = request.getHeader("Authorization");

       if (authorizationHeader != null && authorizationHeader.startsWith("Bearer ")) {
           String token = authorizationHeader.substring(7); // Remove "Bearer " prefix

           if (validateToken(token)) {
               String email = extractEmail(token);

               UsernamePasswordAuthenticationToken authentication = new UsernamePasswordAuthenticationToken(
                       new User(email, "", java.util.Collections.emptyList()), null, java.util.Collections.emptyList());

               authentication.setDetails(new WebAuthenticationDetailsSource().buildDetails(request));
               SecurityContextHolder.getContext().setAuthentication(authentication);
           }
       }

       chain.doFilter(request, response);
   }
}
