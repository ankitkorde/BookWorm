package com.Project.BookWorm.dto;

import java.time.LocalDateTime;

import lombok.AllArgsConstructor;

@AllArgsConstructor
public class ApiResponse 
{
	private String message;
    private LocalDateTime timestamp;
    public ApiResponse(String string, Object object) {
		// TODO Auto-generated constructor stub
	}
	public String getMessage() {
        return message;
    }
    public void setMessage(String message) {
        this.message = message;
    }
    public LocalDateTime getTimestamp() {
        return timestamp;
    }
    
    public void setTimestamp(LocalDateTime timestamp)
    {
    	this.timestamp = timestamp;
    }


}