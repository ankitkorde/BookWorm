package com.Project.BookWorm.Models;

import jakarta.persistence.*;

import lombok.Data;

@Entity
@Data
public class LanguageMaster {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "language_id")
    private int languageId;

    @Column(nullable = true)
    private String languageDesc;

    public int getLanguageId() {
		return languageId;
	}

	public void setLanguageId(int languageId) {
		this.languageId = languageId;
	}

	public String getLanguageDesc() {
		return languageDesc;
	}

	public void setLanguageDesc(String languageDesc) {
		this.languageDesc = languageDesc;
	}

}
