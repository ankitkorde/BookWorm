package com.Project.BookWorm.Models;

import java.sql.Date;
import java.time.LocalDate;
import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class RentDetails {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "rent_id")
    private Integer rentId;

    @ManyToOne
    @JoinColumn(name = "customer_id", nullable = false)
    private CustomerMaster customer; // Rent is tied to a customer

    @ManyToOne
    @JoinColumn(name = "product_id", nullable = false)
    private ProductMaster product; // Rent is tied to a product

    @Column(nullable = false)
    private Date rentStartDate; // Rent start date

    @Column(nullable = false)
    private Date rentEndDate; // Rent end date

    @Column(nullable = false)
    private double rentPrice; // Price of rent

    // Getters and setters
}
