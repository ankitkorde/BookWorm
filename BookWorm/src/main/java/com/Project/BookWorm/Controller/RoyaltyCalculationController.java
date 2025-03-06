package com.Project.BookWorm.Controller;

import com.Project.BookWorm.Models.RoyaltyCalculation;
import com.Project.BookWorm.Service.RoyaltyCalculationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/royalty-calculations")
@CrossOrigin("*")
public class RoyaltyCalculationController {

    @Autowired
    private RoyaltyCalculationService royaltyCalculationService;

    // Get all royalty calculations
    @GetMapping
    public List<RoyaltyCalculation> getAllRoyaltyCalculations() {
        return royaltyCalculationService.getAllRoyaltyCalculations();
    }

    // Get royalty calculation by ID
    @GetMapping("/{id}")
    public ResponseEntity<RoyaltyCalculation> getRoyaltyCalculationById(@PathVariable int id) {
        Optional<RoyaltyCalculation> royaltyCalculation = royaltyCalculationService.getRoyaltyCalculationById(id);
        return royaltyCalculation.map(value -> new ResponseEntity<>(value, HttpStatus.OK))
                .orElseGet(() -> new ResponseEntity<>(HttpStatus.NOT_FOUND));
    }

    // Create or update royalty calculation
    @PostMapping
    public ResponseEntity<RoyaltyCalculation> saveRoyaltyCalculation(@RequestBody RoyaltyCalculation royaltyCalculation) {
        RoyaltyCalculation savedRoyaltyCalculation = royaltyCalculationService.saveRoyaltyCalculation(royaltyCalculation);
        return new ResponseEntity<>(savedRoyaltyCalculation, HttpStatus.CREATED);
    }

    // Delete royalty calculation by ID
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteRoyaltyCalculation(@PathVariable int id) {
        royaltyCalculationService.deleteRoyaltyCalculation(id);
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }

//    // Calculate royalty upon checkout
//    @PostMapping("/calculate")
//    public ResponseEntity<Void> calculateRoyalty(@RequestParam int invoiceDetailsId, @RequestParam int customerId) {
//        royaltyCalculationService.calculateRoyalty(invoiceDetailsId, customerId);
//        return new ResponseEntity<>(HttpStatus.OK);
//    }
}
