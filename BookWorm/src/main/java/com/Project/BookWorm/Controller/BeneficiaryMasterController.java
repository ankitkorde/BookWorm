//package com.Project.BookWorm.Controller;
//
//import com.Project.BookWorm.Models.BeneficiaryMaster;
//import com.Project.BookWorm.Service.BeneficiaryMasterService;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.http.HttpStatus;
//import org.springframework.http.ResponseEntity;
//import org.springframework.web.bind.annotation.*;
//
//import java.util.List;
//import java.util.Optional;
//
//@RestController
//@RequestMapping("/api/beneficiaries")
//public class BeneficiaryMasterController {
//
//    @Autowired
//    private BeneficiaryMasterService beneficiaryMasterService;
//
//    // Endpoint to get all beneficiaries
//    @GetMapping
//    public ResponseEntity<List<BeneficiaryMaster>> getAllBeneficiaries() {
//        List<BeneficiaryMaster> beneficiaries = beneficiaryMasterService.getAllBeneficiaries();
//        return new ResponseEntity<>(beneficiaries, HttpStatus.OK);
//    }
//
//    // Endpoint to get beneficiary by ID
//    @GetMapping("/{benId}")
//    public ResponseEntity<BeneficiaryMaster> getBeneficiaryById(@PathVariable int benId) {
//        Optional<BeneficiaryMaster> beneficiary = beneficiaryMasterService.getBeneficiaryById(benId);
//        return beneficiary.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
//    }
//
//    // Endpoint to save a new beneficiary
//    @PostMapping
//    public ResponseEntity<BeneficiaryMaster> createBeneficiary(@RequestBody BeneficiaryMaster beneficiaryMaster) {
//        BeneficiaryMaster savedBeneficiary = beneficiaryMasterService.saveBeneficiary(beneficiaryMaster);
//        return new ResponseEntity<>(savedBeneficiary, HttpStatus.CREATED);
//    }
//
//    // Endpoint to update an existing beneficiary
//    @PutMapping("/{benId}")
//    public ResponseEntity<BeneficiaryMaster> updateBeneficiary(@PathVariable int benId, @RequestBody BeneficiaryMaster beneficiaryMaster) {
//        BeneficiaryMaster updatedBeneficiary = beneficiaryMasterService.updateBeneficiary(benId, beneficiaryMaster);
//        return updatedBeneficiary != null ? ResponseEntity.ok(updatedBeneficiary) : ResponseEntity.notFound().build();
//    }
//
//    // Endpoint to delete a beneficiary by ID
//    @DeleteMapping("/{benId}")
//    public ResponseEntity<Void> deleteBeneficiary(@PathVariable int benId) {
//        beneficiaryMasterService.deleteBeneficiaryById(benId);
//        return ResponseEntity.noContent().build();
//    }
//}
