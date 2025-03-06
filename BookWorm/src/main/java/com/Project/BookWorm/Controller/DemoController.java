package com.Project.BookWorm.Controller;

import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import com.Project.BookWorm.Models.CustomerMaster;
import com.Project.BookWorm.Service.CustomerMasterService;

//@RestController
//public class DemoController {
//	
//	@Autowired
//	private CustomerMasterService customerservice;
//
//	@GetMapping("/demo")
//	public List<CustomerMaster> getall() {
//	    List<CustomerMaster> customers = customerservice.getAllCustomers();
//	    System.out.println(customers);
//	    for(CustomerMaster c: customers)
//	    {
//	    	System.out.println(c);
//	    }
//
//	    return customers;  // Spring Boot will automatically convert this to JSON.
//	}
//}

@RestController
public class DemoController {

    @Autowired
    private CustomerMasterService customerservice;

    @GetMapping("/demo")
    public List<CustomerMaster> getAllCustomers() {
        List<CustomerMaster> customers = customerservice.getAllCustomers();
        System.out.println("Fetched customers: " + customers);
        return customers; // Spring will automatically convert this to JSON
    }
}

