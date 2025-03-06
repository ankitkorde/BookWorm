package com.Project.BookWorm.Models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class ProductTypeMaster {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "type_id")
    private int TypeId;
    
    public int getTypeId() {
		return TypeId;
	}

	public void setTypeId(int typeId) {
		TypeId = typeId;
	}

	public String getTypeDesc() {
		return TypeDesc;
	}

	public void setTypeDesc(String typeDesc) {
		TypeDesc = typeDesc;
	}

	@Column(nullable = true)
    private String TypeDesc;
}