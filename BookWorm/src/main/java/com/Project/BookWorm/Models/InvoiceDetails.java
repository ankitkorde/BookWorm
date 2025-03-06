package com.Project.BookWorm.Models;

import jakarta.persistence.*;

import lombok.Data;

@Entity
@Data
public class InvoiceDetails {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "inv_dtl_id")
    private int invDtlId;

    public int getInvDtlId() {
		return invDtlId;
	}

	public void setInvDtlId(int invDtlId) {
		this.invDtlId = invDtlId;
	}

	public Invoice getInvoice() {
		return invoice;
	}

	public void setInvoice(Invoice invoice) {
		this.invoice = invoice;
	}

	public ProductMaster getProduct() {
		return product;
	}

	public void setProduct(ProductMaster product) {
		this.product = product;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public Double getSellPrice() {
		return sellPrice;
	}

	public void setSellPrice(Double basePrice) {
		this.sellPrice = basePrice;
	}
	
	

	public Double getRoyaltyAmount() {
		return royaltyAmount;
	}

	public void setRoyaltyAmount(Double royalityAmount) {
		this.royaltyAmount = royalityAmount;
	}

	public String getTranType() {
		return tranType;
	}

	public void setTranType(String tranType) {
		this.tranType = tranType;
	}

	public int getRentNoOfDays() {
		return rentNoOfDays;
	}

	public void setRentNoOfDays(int rentNoOfDays) {
		this.rentNoOfDays = rentNoOfDays;
	}

	@ManyToOne
    @JoinColumn(name = "invoice_id", nullable = true)
    private Invoice invoice;

    @ManyToOne
    @JoinColumn(name = "product_id", nullable = true)
    
    private ProductMaster product;

    @Column(nullable = true)
    private int quantity;

    @Column(nullable = true)
    private Double sellPrice;
    
    @Column(nullable = true)
    private Double royaltyAmount;

    @Column(nullable = true)
    private String tranType;

    private int rentNoOfDays;
}