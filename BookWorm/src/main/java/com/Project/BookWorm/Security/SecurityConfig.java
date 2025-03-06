package com.Project.BookWorm.Security;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.annotation.authentication.configuration.AuthenticationConfiguration;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;
import org.springframework.security.web.util.matcher.AntPathRequestMatcher;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;

@Configuration
@EnableWebSecurity
public class SecurityConfig {

   private final JwtFilter jwtFilter;

   public SecurityConfig(JwtFilter jwtFilter) {
       this.jwtFilter = jwtFilter;
   }

   @Bean
   public AuthenticationManager authenticationManager(AuthenticationConfiguration authenticationConfiguration) throws Exception {
       return authenticationConfiguration.getAuthenticationManager();
   }

   @Bean
   public SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
       http
           .csrf(csrf -> csrf.disable()) // Disable CSRF protection explicitly
           .authorizeHttpRequests(auth -> auth
               .requestMatchers("/api/login", "/api/customers/register", "/api/send-otp","/api/verify-otp").permitAll() // Permit access to login and registration endpoints
               .anyRequest().permitAll() // Protect all other endpoints
           )
           .sessionManagement(sess -> sess.sessionCreationPolicy(SessionCreationPolicy.STATELESS))
           .addFilterBefore(jwtFilter, UsernamePasswordAuthenticationFilter.class);

       return http.build();
   }

   @Bean
   public PasswordEncoder passwordEncoder() {
       return new BCryptPasswordEncoder();
   }
}
