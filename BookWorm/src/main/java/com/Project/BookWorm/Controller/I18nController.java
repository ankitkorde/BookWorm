package com.Project.BookWorm.Controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.MessageSource;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RestController;

import java.util.Locale;

@RestController
public class I18nController {

    @Autowired
    private MessageSource messageSource;
   
    // REST endpoint for greeting
    @GetMapping("/greeting")
    public String getGreeting(@RequestHeader(name = "Accept-Language", required = false) Locale locale) {
        // If no Accept-Language header is provided, default to English
        if (locale == null) {
            locale = Locale.ENGLISH;
        }

        // Retrieve the message based on the locale
        return messageSource.getMessage("greeting", null, locale);
    }
}