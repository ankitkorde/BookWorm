package com.Project.BookWorm.Models;

import java.util.Date;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class MyShelfDetails {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "shelf_dtl_id")
    private Integer shelfDetailId;

    @ManyToOne
    @JoinColumn(name = "shelf_id", nullable = false)
    private MyShelf shelfId; // Many details for one shelf
    
    @ManyToOne
    @JoinColumn(name = "product_id", nullable = false)
    private ProductMaster productId; // Each shelf detail links to one product (book)

    @Column(nullable = true)
    private java.util.Date expiryDate; // Expiry date for rental

    @Column(nullable = true)
    private String tranType; // Transaction type (Rental, Purchase, etc.)

    @ManyToOne
    @JoinColumn(name = "rent_id", nullable = true)
    private RentDetails rentDetails; // Link to rent details, if any


	public Integer getShelfDetailId() {
		return shelfDetailId;
	}

	public void setShelfDetailId(Integer shelfDetailId) {
		this.shelfDetailId = shelfDetailId;
	}

	public MyShelf getShelfId() {
		return shelfId;
	}

	public void setShelfId(MyShelf shelfId) {
		this.shelfId = shelfId;
	}

	public ProductMaster getProductId() {
		return productId;
	}

	public void setProductId(ProductMaster productId) {
		this.productId = productId;
	}

	public Date getExpiryDate() {
		return expiryDate;
	}

	public void setExpiryDate(Date expiryDate2) {
		this.expiryDate = expiryDate2;
	}

	public String getTranType() {
		return tranType;
	}

	public void setTranType(String tranType) {
		this.tranType = tranType;
	}

	public RentDetails getRentDetails() {
		return rentDetails;
	}
	
	public void setRentDetails(RentDetails rentDetails) {
		this.rentDetails = rentDetails;
	}

}
