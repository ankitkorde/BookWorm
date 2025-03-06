package com.Project.BookWorm.Models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class ProductArribute {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "product_attribute_id")
    private int productAttributeId;

    @ManyToOne
    @JoinColumn(name = "attribute_id",nullable = true)
    private AttributeMaster attributeId;

    public int getProductAttributeId() {
		return productAttributeId;
	}

	public void setProductAttributeId(int productAttributeId) {
		this.productAttributeId = productAttributeId;
	}

	public AttributeMaster getAttributeId() {
		return attributeId;
	}

	public void setAttributeId(AttributeMaster attributeId) {
		this.attributeId = attributeId;
	}

	public ProductMaster getProductId() {
		return productId;
	}

	public void setProductId(ProductMaster productId) {
		this.productId = productId;
	}

	public String getAttributeValue() {
		return attributeValue;
	}

	public void setAttributeValue(String attributeValue) {
		this.attributeValue = attributeValue;
	}

	@ManyToOne
    @JoinColumn(name = "product_id",nullable = true)
    private ProductMaster productId;

    @Column(nullable = true,name = "attribute_value")
    private String attributeValue;


}