package com.Project.BookWorm.Models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class CartMaster {
	
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "cart_id")
    private int cartId;
    
    @ManyToOne
    @JoinColumn(name = "customer_id")
    private CustomerMaster customerId;

    @Column(nullable = false)
    private Boolean isActive = true;

    private Double cost; // Moved this line above the getters/setters to fix the syntax error

    public int getCartId() {
        return cartId;
    }

    public void setCartId(int cartId) {
        this.cartId = cartId;
    }

    public CustomerMaster getCustomer() {
        return customerId;
    }

    public void setCustomer(CustomerMaster customer) {
        this.customerId = customer;
    }

    public Boolean getIsActive() {
        return isActive;
    }

    public void setIsActive(Boolean isActive) {
        this.isActive = isActive;
    }

	public Double getCost() {
		return cost;
	}

	public void setCost(Double cost) {
		this.cost = cost;
	}

}
