package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.MyShelf;
import com.Project.BookWorm.Models.MyShelfDetails;
import com.Project.BookWorm.Models.ProductMaster;
import com.Project.BookWorm.Repository.MyShelfDetailsRepository;
import com.Project.BookWorm.Repository.MyShelfRepository;
import com.Project.BookWorm.Repository.ProductMasterRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Date;
import java.util.List;

@Service
public class MyShelfDetailsService {


    @Autowired
    private MyShelfDetailsRepository myShelfDetailsRepository;

    @Autowired
    private MyShelfRepository myShelfRepository;

    @Autowired
    private ProductMasterRepository productMasterRepository;

    // Method to add a product to the shelf (MyShelfDetails)
    public MyShelfDetails addProductToShelf(Integer shelfId, Integer productId, Date expiryDate, String tranType) {
        // Convert java.util.Date to java.sql.Date
    	java.sql.Date sqlExpiryDate = (expiryDate != null) ? new java.sql.Date(expiryDate.getTime()) : null;
        
        // Fetch the MyShelf object using shelfId
        MyShelf myShelf = myShelfRepository.findById(shelfId)
                .orElseThrow(() -> new RuntimeException("Shelf not found"));

        // Fetch the ProductMaster object using productId
        ProductMaster product = productMasterRepository.findById(productId)
                .orElseThrow(() -> new RuntimeException("Product not found"));

        // Create and populate the MyShelfDetails object
        MyShelfDetails myShelfDetails = new MyShelfDetails();
        myShelfDetails.setShelfId(myShelf); // set the MyShelf object
        myShelfDetails.setProductId(product); // set the ProductMaster object
        myShelfDetails.setExpiryDate(sqlExpiryDate); // set the converted expiry date
        myShelfDetails.setTranType(tranType); // set transaction type

        // Save the MyShelfDetails object
        return myShelfDetailsRepository.save(myShelfDetails);
    }

    // Method to get shelf details by shelf ID
    public List<MyShelfDetails> getShelfDetails(Integer shelfId) {
        return myShelfDetailsRepository.findByShelfIdShelfId(shelfId);
    }

    // Create or update MyShelfDetails
    public MyShelfDetails createMyShelfDetails(MyShelfDetails myShelfDetails) {
        return myShelfDetailsRepository.save(myShelfDetails);
    }

    public MyShelfDetails updateMyShelfDetails(Integer shelfDetailId, MyShelfDetails myShelfDetails) {
        if (myShelfDetailsRepository.existsById(shelfDetailId)) {
            myShelfDetails.setShelfDetailId(shelfDetailId);
            return myShelfDetailsRepository.save(myShelfDetails);
        }
        return null; // ShelfDetail not found
    }

    public void deleteMyShelfDetails(Integer shelfDetailId) {
        myShelfDetailsRepository.deleteById(shelfDetailId);
    }

    public boolean isProductInShelf(Integer shelfId, Integer productId) {
        return myShelfDetailsRepository.existsByShelfIdShelfIdAndProductIdProductId(shelfId, productId);
    }

}
