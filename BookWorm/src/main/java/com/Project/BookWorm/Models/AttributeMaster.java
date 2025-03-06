package com.Project.BookWorm.Models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class AttributeMaster {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "attribute_id")
    private int attributeId;

    public int getAttributeId() {
		return attributeId;
	}

	public void setAttributeId(int attributeId) {
		this.attributeId = attributeId;
	}

	public String getAttributename() {
		return attributename;
	}

	public void setAttributename(String attributeName) {
		this.attributename = attributeName;
	}

	@Column(nullable = true,name = "attribute_name")
    private String attributename;
}
