package com.Project.BookWorm.Models;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonManagedReference;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class MyShelf {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "shelf_id")
    private Integer shelfId;

    @JsonManagedReference
    @OneToOne
    @JoinColumn(name = "customer_id", nullable = false)
    private CustomerMaster customer; // One shelf per customer
    
    private int noOfBooks; // Number of books on the shelf

	public Integer getShelfId() {
		return shelfId;
	}

	public void setShelfId(Integer shelfId) {
		this.shelfId = shelfId;
	}

	public CustomerMaster getCustomer() {
		return customer;
	}

	public void setCustomer(CustomerMaster customer) {
		this.customer = customer;
	}

	public int getNoOfBooks() {
		return noOfBooks;
	}

	public void setNoOfBooks(int noOfBooks) {
		this.noOfBooks = noOfBooks;
	}
}

