package com.Project.BookWorm.Models;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.Data;

@Entity
@Data
public class CartDetails {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "cart_details_id")
    private Integer cartDetailsId;

    @ManyToOne
    @JoinColumn(name = "cart_id", nullable = true)
    private CartMaster cartId;

    @ManyToOne    
    @JoinColumn(name = "product_id", nullable = true)
    private ProductMaster productId;

    @Column(nullable = false)
    private Boolean isRented;
    
    @Column(nullable = false)
    private Boolean isUpdated=false;

    private Integer rentNoOfDays;
    
    private double offerCost;

    public Boolean getIsUpdated() {
		return isUpdated;
	}

	public void setIsUpdated(Boolean isUpdated) {
		this.isUpdated = isUpdated;
	}

	// Getters and setters
    public Integer getCartDetailsId() {
        return cartDetailsId;
    }

    public void setCartDetailsId(Integer cartDetailsId) {
        this.cartDetailsId = cartDetailsId;
    }

    public CartMaster getCartId() {
        return cartId;
    }

    public void setCartId(CartMaster cartId) {
        this.cartId = cartId;
    }

    public ProductMaster getProductId() {
        return productId;
    }

    public void setProductId(ProductMaster productId) {
        this.productId = productId;
    }

    public Boolean getIsRented() {
        return isRented;
    }

    public void setIsRented(Boolean isRented) {
        this.isRented = isRented;
    }

    public Integer getRentNoOfDays() {
        return rentNoOfDays;
    }

    public void setRentNoOfDays(Integer rentNoOfDays) {
        this.rentNoOfDays = rentNoOfDays;
    }

    public double getOfferCost() {
        return offerCost;
    }

    public void setOfferCost(double offerCost) {
        this.offerCost = offerCost;
    }
}