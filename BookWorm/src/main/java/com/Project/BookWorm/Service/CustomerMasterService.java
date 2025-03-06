package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.List;
import java.util.Optional;

import com.Project.BookWorm.Repository.CustomerMasterRepository;
//import com.Project.BookWorm.Security.JwtUtil;
import com.Project.BookWorm.Security.JwtUtil;
import org.springframework.security.crypto.password.PasswordEncoder;

@Service
public class CustomerMasterService {

    @Autowired
    private CustomerMasterRepository customerMasterRepository;

    @Autowired
    private PasswordEncoder passwordEncoder;

    public List<CustomerMaster> getAllCustomers(){
        return customerMasterRepository.findAll();
    }

    public Optional<CustomerMaster> getCustomerById(Long id){
        return customerMasterRepository.findById(id);
    }

    public CustomerMaster saveCustomer(CustomerMaster customer) {
        // Check if the customer object is correctly received
        System.out.println("Saving customer: " + customer);
        return customerMasterRepository.save(customer);
    }

    public void deleteCustomer(long id) {
        customerMasterRepository.deleteById(id);
    }

    // public Customer_Master updateCustomer(long id, Customer_Master customerDetails) {
    //     return customerMasterRepository.findById(id).map(customer -> {
    //         customer.setCustomerName(customerDetails.getCustomerName());
    //         customer.setCustomerEmail(customerDetails.getCustomerEmail());
    //         customer.setCustomerPassword(customerDetails.getCustomerPassword());
    //         customer.setDob(customerDetails.getDob());
    //         customer.setPhoneNumber(customerDetails.getPhoneNumber());
    //         customer.setPan(customerDetails.getPan());
    //         customer.setCart(customerDetails.getCart());
    //         customer.setLibraryPackage(customerDetails.getLibraryPackage());
    //         return customerMasterRepository.save(customer);
    //     }).orElseGet(() -> {
    //         customerDetails.setCustomerId(id);
    //         return customerMasterRepository.save(customerDetails);
    //     });
    // }

    // public Optional<Customer_Master> getCustomerByEmailAndPassword(String email, String password) {
    //     return customerMasterRepository.getCustomerByEmailAndPassword(email, password);
    // }

     @Autowired
    private JwtUtil jwtUtil;

    public Optional<String> authenticateUser(String email, String password) {
        Optional<CustomerMaster> customer = customerMasterRepository.findByCustomeremail(email);
        
        if (customer.isPresent() && passwordEncoder.matches(password, customer.get().getCustomerpassword())) {
            // ✅ If user is valid, generate a JWT token
            String token = jwtUtil.generateToken(email);
            return Optional.of(token);
        }
        
        return Optional.empty();
    }

    public boolean userExists(String email) {
        return customerMasterRepository.findByCustomeremail(email).isPresent();
    }

    public Optional<CustomerMaster> getCustomerByEmail(String email) {
        return customerMasterRepository.findByCustomeremail(email);
    }

}
