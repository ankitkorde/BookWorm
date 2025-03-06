package com.Project.BookWorm.Models;


import java.time.LocalDate;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class ProductMaster {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "product_id")
    private int productId;

    @Column(nullable = true)
    private String productName;

    @Column(nullable = true)
    private String productEnglishName;
    
    @Column(nullable = true)
    private String imgSrc;

    public String getImgSrc() {
		return imgSrc;
	}

	public void setImgSrc(String imgSrc) {
		this.imgSrc = imgSrc;
	}

	public int getProductId() {
		return productId;
	}

	public void setProductId(int productId) {
		this.productId = productId;
	}

	public String getProductName() {
		return productName;
	}

	public void setProductName(String productName) {
		this.productName = productName;
	}

	public String getProductEnglishName() {
		return productEnglishName;
	}

	public void setProductEnglishName(String productEnglishName) {
		this.productEnglishName = productEnglishName;
	}

	public ProductTypeMaster getProductType() {
		return productType;
	}

	public void setProductType(ProductTypeMaster productType) {
		this.productType = productType;
	}

	public double getProductBasePrice() {
		return productBasePrice;
	}

	public void setProductBasePrice(double productBasePrice) {
		this.productBasePrice = productBasePrice;
	}

	public double getProductSpCost() {
		return productSpCost;
	}

	public void setProductSpCost(double productSpCost) {
		this.productSpCost = productSpCost;
	}

	public double getProductOfferPrice() {
		return productOfferPrice;
	}

	public void setProductOfferPrice(double productOfferPrice) {
		this.productOfferPrice = productOfferPrice;
	}

	public LocalDate getProductOffPriceExpiryDate() {
		return productOffPriceExpiryDate;
	}

	public void setProductOffPriceExpiryDate(LocalDate productOffPriceExpiryDate) {
		this.productOffPriceExpiryDate = productOffPriceExpiryDate;
	}

	public String getProductDescriptionShort() {
		return productDescriptionShort;
	}

	public void setProductDescriptionShort(String productDescriptionShort) {
		this.productDescriptionShort = productDescriptionShort;
	}

	public String getProductDescriptionLong() {
		return productDescriptionLong;
	}

	public void setProductDescriptionLong(String productDescriptionLong) {
		this.productDescriptionLong = productDescriptionLong;
	}

	public String getProductIsbn() {
		return productIsbn;
	}

	public void setProductIsbn(String productIsbn) {
		this.productIsbn = productIsbn;
	}

	public String getProductAuthor() {
		return productAuthor;
	}

	public void setProductAuthor(String productAuthor) {
		this.productAuthor = productAuthor;
	}

	public LanguageMaster getProductLang() {
		return productLang;
	}

	public void setProductLang(LanguageMaster productLang) {
		this.productLang = productLang;
	}

	public GenreMaster getProductGenre() {
		return productGenre;
	}

	public void setProductGenre(GenreMaster productGenre) {
		this.productGenre = productGenre;
	}

	public boolean isRentable() {
		return isRentable;
	}

	public void setRentable(boolean isRentable) {
		this.isRentable = isRentable;
	}

	public double getRentPerDay() {
		return rentPerDay;
	}

	public void setRentPerDay(double rentPerDay) {
		this.rentPerDay = rentPerDay;
	}

	public int getMinRentDays() {
		return minRentDays;
	}

	public void setMinRentDays(int minRentDays) {
		this.minRentDays = minRentDays;
	}

	@ManyToOne
    @JoinColumn(name = "type_id",nullable = true,referencedColumnName = "type_id")
    private ProductTypeMaster productType; 

    @Column(nullable = true)
    private double productBasePrice;

    @Column(nullable = true)
    private double productSpCost;

    @Column(nullable = true)
    private double productOfferPrice;
    
    @Column(nullable = true)
    private LocalDate productOffPriceExpiryDate;
    
    @Column(nullable = true)
    private String productDescriptionShort;

    @Column(nullable = true)
    private String productDescriptionLong;

    @Column(nullable = true)
    private String productIsbn;

    @Column(nullable = true)
    private String productAuthor;

    @ManyToOne
    @JoinColumn(name = "language_id",nullable = true)
    private LanguageMaster productLang; 

    @ManyToOne
    @JoinColumn(name = "genre_id",nullable = true)
    private GenreMaster productGenre;

    @Column(nullable = true)
    private boolean isRentable; // Y/N
    
    @Column(nullable = true )
    private double rentPerDay;

    @Column(nullable = true , columnDefinition = "int default 3") 
    private int minRentDays;
}
