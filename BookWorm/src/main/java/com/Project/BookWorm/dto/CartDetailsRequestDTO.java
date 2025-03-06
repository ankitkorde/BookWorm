package com.Project.BookWorm.dto;

import com.Project.BookWorm.Models.ProductMaster;

public class CartDetailsRequestDTO {
    private int customerId;
    private int productId;
    private int quantity;
    private int rentNoOfDays;
    private String transType;
    private double offerCost;
    private ProductMaster product;

    // Getters and setters
    public int getCustomerId() {
        return customerId;
    }

    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }

    public int getProductId() {
        return productId;
    }

    public void setProductId(int productId) {
        this.productId = productId;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public int getRentNoOfDays() {
        return rentNoOfDays;
    }

    public void setRentNoOfDays(int rentNoOfDays) {
        this.rentNoOfDays = Math.max(rentNoOfDays, 7); // Ensure it can't go less than 7
    }

    public String getTransType() {
        return transType;
    }

    public void setTransType(String transType) {
        this.transType = transType;
    }

    public double getOfferCost() {
        return offerCost;
    }

    public void setOfferCost(double offerCost) {
        this.offerCost = offerCost;
    }

    public ProductMaster getProduct() {
        return product;
    }

    public void setProduct(ProductMaster product) {
        this.product = product;
    }
}
