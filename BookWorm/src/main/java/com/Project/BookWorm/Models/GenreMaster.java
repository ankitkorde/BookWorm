package com.Project.BookWorm.Models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class GenreMaster {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "genre_id")
    private int genreId;

    @Column(nullable = true)
    private String genreDesc;

    public int getGenreId() {
		return genreId;
	}

	public void setGenreId(int genreId) {
		this.genreId = genreId;
	}

	public String getGenreDesc() {
		return genreDesc;
	}

	public void setGenreDesc(String genreDesc) {
		this.genreDesc = genreDesc;
	}


}
