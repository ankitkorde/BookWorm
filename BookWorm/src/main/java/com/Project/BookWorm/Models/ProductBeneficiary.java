package com.Project.BookWorm.Models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class ProductBeneficiary {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "product_beneficiary_id")
    private int beneficiaryId;
    @ManyToOne()
    @JoinColumn(name = "beneficiary_id",  nullable = true)
    private BeneficiaryMaster beneficiaryMaster;

    public int getBeneficiaryId() {
		return beneficiaryId;
	}

	public void setBeneficiaryId(int beneficiaryId) {
		this.beneficiaryId = beneficiaryId;
	}

	public BeneficiaryMaster getBeneficiaryMaster() {
		return beneficiaryMaster;
	}

	public void setBeneficiaryMaster(BeneficiaryMaster beneficiaryMaster) {
		this.beneficiaryMaster = beneficiaryMaster;
	}

	public ProductMaster getProductMaster() {
		return productMaster;
	}

	public void setProductMaster(ProductMaster productMaster) {
		this.productMaster = productMaster;
	}

	public double getPercentage() {
		return percentage;
	}

	public void setPercentage(double percentage) {
		this.percentage = percentage;
	}

	@ManyToOne()
    @JoinColumn(name = "product_id",  nullable = true)
    private ProductMaster productMaster;

    @Column(nullable = true,name = "percentage")
    private double percentage;
}
