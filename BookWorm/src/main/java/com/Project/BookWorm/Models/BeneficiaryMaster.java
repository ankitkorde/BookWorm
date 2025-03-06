package com.Project.BookWorm.Models;

import jakarta.persistence.*;
import jakarta.validation.constraints.Pattern;
import lombok.Data;

@Entity
@Data
public class BeneficiaryMaster {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int benId;
    
    @Column(nullable = true,name = "ben_name")
    private String benName;

    @Column(nullable = true)
    @Pattern(regexp = "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")
    private String benEmail;

    @Column(nullable = true)
    @Pattern(regexp = "^[0-9]{10}$")
    private String benPhone;

    public int getBenId() {
		return benId;
	}

	public void setBenId(int benId) {
		this.benId = benId;
	}

	public String getBenName() {
		return benName;
	}

	public void setBenName(String benName) {
		this.benName = benName;
	}

	public String getBenEmail() {
		return benEmail;
	}

	public void setBenEmail(String benEmail) {
		this.benEmail = benEmail;
	}

	public String getBenPhone() {
		return benPhone;
	}

	public void setBenPhone(String benPhone) {
		this.benPhone = benPhone;
	}

	public String getBenBankName() {
		return benBankName;
	}

	public void setBenBankName(String benBankName) {
		this.benBankName = benBankName;
	}

	public String getBenBankBranch() {
		return benBankBranch;
	}

	public void setBenBankBranch(String benBankBranch) {
		this.benBankBranch = benBankBranch;
	}

	public String getBenBankAccNo() {
		return benBankAccNo;
	}

	public void setBenBankAccNo(String benBankAccNo) {
		this.benBankAccNo = benBankAccNo;
	}

	public String getBenIfsc() {
		return benIfsc;
	}

	public void setBenIfsc(String benIfsc) {
		this.benIfsc = benIfsc;
	}

	public String getBenAccType() {
		return benAccType;
	}

	public void setBenAccType(String benAccType) {
		this.benAccType = benAccType;
	}

	public String getBenPan() {
		return benPan;
	}

	public void setBenPan(String benPan) {
		this.benPan = benPan;
	}

	@Column(nullable = true)
    private String benBankName;

    @Column(nullable = true)
    private String benBankBranch;

    @Column(nullable = true)
    private String benBankAccNo;

    @Column(nullable = true)
    private String benIfsc;

    @Column(nullable = true)
    private String benAccType;

    @Column(nullable = true)
    private String benPan;
}