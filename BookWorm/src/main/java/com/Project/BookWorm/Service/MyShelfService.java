package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.CustomerMaster;
import com.Project.BookWorm.Models.MyShelf;
import com.Project.BookWorm.Repository.MyShelfRepository;

import com.Project.BookWorm.Repository.CustomerMasterRepository;
import com.Project.BookWorm.Repository.MyShelfDetailsRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class MyShelfService {

    @Autowired
    private MyShelfRepository myShelfRepository;

    @Autowired
    private MyShelfDetailsRepository myShelfDetailsRepository;

    @Autowired
    private CustomerMasterRepository customerMasterRepository;

    // Create a new shelf for a customer (usually done when a customer registers)
    public MyShelf createShelfForCustomer(Long customerId, int noOfBooks) {
        // Fetch the CustomerMaster object using the customerId
        CustomerMaster customer = customerMasterRepository.findById(customerId)
                .orElseThrow(() -> new RuntimeException("Customer not found"));

        MyShelf myShelf = new MyShelf();
        myShelf.setCustomer(customer); // set the CustomerMaster object
        myShelf.setNoOfBooks(noOfBooks); // set initial number of books
        return myShelfRepository.save(myShelf);
    }
 // Method to get MyShelf by Customer ID
    public MyShelf getMyShelfByCustomer(Integer customerId) {
        return myShelfRepository.findByCustomerId(customerId);
    }

    // Create or update MyShelf
    public MyShelf createMyShelf(MyShelf myShelf) {
        return myShelfRepository.save(myShelf);
    }

    public MyShelf updateMyShelf(Integer shelfId, MyShelf myShelf) {
        if (myShelfRepository.existsById(shelfId)) {
            myShelf.setShelfId(shelfId);
            return myShelfRepository.save(myShelf);
        }
        return null; // Shelf not found
    }

    public void deleteMyShelf(Integer shelfId) {
        myShelfRepository.deleteById(shelfId);
    }
	public boolean isProductInShelf(Long shelfId, Long productId) {
	    return myShelfDetailsRepository.existsByShelfIdShelfIdAndProductIdProductId(shelfId, productId);
	}
}
