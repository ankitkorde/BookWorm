package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.BeneficiaryMaster;
import com.Project.BookWorm.Repository.BeneficiaryMasterRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class BeneficiaryMasterService {

    @Autowired
    private BeneficiaryMasterRepository beneficiaryMasterRepository;

    // Save a beneficiary
    public BeneficiaryMaster saveBeneficiary(BeneficiaryMaster beneficiaryMaster) {
        return beneficiaryMasterRepository.save(beneficiaryMaster);
    }

    // Get all beneficiaries
    public List<BeneficiaryMaster> getAllBeneficiaries() {
        return beneficiaryMasterRepository.findAll();
    }

    // Get beneficiary by ID
    public Optional<BeneficiaryMaster> getBeneficiaryById(int benId) {
        return beneficiaryMasterRepository.findById(benId);
    }

    // Delete beneficiary by ID
    public void deleteBeneficiaryById(int benId) {
        beneficiaryMasterRepository.deleteById(benId);
    }

    // Update beneficiary details
    public BeneficiaryMaster updateBeneficiary(int benId, BeneficiaryMaster beneficiaryMaster) {
        if (beneficiaryMasterRepository.existsById(benId)) {
            beneficiaryMaster.setBenId(benId);
            return beneficiaryMasterRepository.save(beneficiaryMaster);
        }
        return null;
    }
}
