package com.Project.BookWorm.Models;
import java.time.LocalDate;

import jakarta.persistence.*;
import lombok.Data;

@Entity
public class RoyaltyCalculation {

    
    @Id 
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name="RoyCalId", length=10, nullable=false)
    private int id;

    @ManyToOne(targetEntity = Invoice.class)
    @JoinColumn(name="InvoiceId", nullable=false)
    private Invoice invoice;

	@ManyToOne(targetEntity = BeneficiaryMaster.class)
    @JoinColumn(name="BeneficiaryId", nullable=false)
	private BeneficiaryMaster beneficiaryMaster;

	@Column(nullable=false)
    private LocalDate royaltyDate;

    @ManyToOne(targetEntity = ProductMaster.class)
    @JoinColumn(name="ProductId", nullable=false)
    private ProductMaster product;

	@Column(nullable=false)
    private String transactionType;

	@Column(nullable=false)
    private double salesPrice;

	@Column(nullable=false)
    private double royaltyOnSalesPrice;


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Invoice getInvoice() {
        return invoice;
    }

    public void setInvoice(Invoice invoice) {
        this.invoice = invoice;
    }

    public BeneficiaryMaster getBeneficiaryMaster() {
        return beneficiaryMaster;
    }

    public void setBeneficiaryMaster(BeneficiaryMaster beneficiaryMaster) {
        this.beneficiaryMaster = beneficiaryMaster;
    }

    public LocalDate getRoyaltyDate() {
        return royaltyDate;
    }

    public void setRoyaltyDate(LocalDate royaltyDate) {
        this.royaltyDate = royaltyDate;
    }

    public ProductMaster getProduct() {
        return product;
    }

    public void setProduct(ProductMaster product) {
        this.product = product;
    }

    public String getTransactionType() {
        return transactionType;
    }

    public void setTransactionType(String transactionType) {
        this.transactionType = transactionType;
    }

    public double getSalesPrice() {
        return salesPrice;
    }

    public void setSalesPrice(double salesPrice) {
        this.salesPrice = salesPrice;
    }

    public double getRoyaltyOnSalesPrice() {
        return royaltyOnSalesPrice;
    }

    public void setRoyaltyOnSalesPrice(double royaltyOnBasePrice) {
        this.royaltyOnSalesPrice = royaltyOnBasePrice;
    }

}