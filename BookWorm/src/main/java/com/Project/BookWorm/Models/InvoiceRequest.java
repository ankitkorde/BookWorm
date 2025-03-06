package com.Project.BookWorm.Models;

public class InvoiceRequest {
    private long customerId;
    private int cartId;

    // Getters and setters
    public long getCustomerId() {
        return customerId;
    }

    public void setCustomerId(long customerId) {
        this.customerId = customerId;
    }

    public int getCartId() {
        return cartId;
    }

    public void setCartId(int cartId) {
        this.cartId = cartId;
    }
}
