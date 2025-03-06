package com.Project.BookWorm;

import java.util.Locale;

import org.hibernate.validator.spi.messageinterpolation.LocaleResolver;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.boot.autoconfigure.jdbc.DataSourceAutoConfiguration;
import org.springframework.context.MessageSource;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.support.ReloadableResourceBundleMessageSource;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.servlet.i18n.AcceptHeaderLocaleResolver;

@SpringBootApplication
@CrossOrigin("*")
@ComponentScan(basePackages="com.Project.*")
@EntityScan(basePackages="com.Project.*")
@EnableJpaRepositories(basePackages="com.Project.*")
public class BookWormApplication {

	public static void main(String[] args) {
		SpringApplication.run(BookWormApplication.class, args);
	}
	@Bean
    public AcceptHeaderLocaleResolver localeResolver() {
        AcceptHeaderLocaleResolver localeResolver = new AcceptHeaderLocaleResolver();
        localeResolver.setDefaultLocale(Locale.ENGLISH); // Default language
        return localeResolver;
    }

    // Configure the MessageSource for i18n
    @Bean
    public MessageSource messageSource() {
        ReloadableResourceBundleMessageSource messageSource = new ReloadableResourceBundleMessageSource();
        messageSource.setBasename("classpath:message");  // Base name of the messages files
        messageSource.setDefaultEncoding("UTF-8");
        return messageSource;
    }

}
