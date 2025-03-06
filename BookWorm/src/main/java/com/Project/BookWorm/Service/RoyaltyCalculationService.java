package com.Project.BookWorm.Service;

import com.Project.BookWorm.Models.RoyaltyCalculation;
import com.Project.BookWorm.Models.InvoiceDetails;
import com.Project.BookWorm.Models.ProductMaster;
import com.Project.BookWorm.Models.BeneficiaryMaster;
import com.Project.BookWorm.Models.CartMaster;
import com.Project.BookWorm.Models.Invoice;
import com.Project.BookWorm.Models.CartDetails;
import com.Project.BookWorm.Models.ProductBeneficiary;
import com.Project.BookWorm.Repository.RoyaltyCalculationRepository;
import com.Project.BookWorm.Repository.InvoiceDetailsRepository;
import com.Project.BookWorm.Repository.InvoiceRepository;
import com.Project.BookWorm.Repository.ProductMasterRepository;
import com.Project.BookWorm.Repository.BeneficiaryMasterRepository;
import com.Project.BookWorm.Repository.CartMasterRepository;
import com.Project.BookWorm.Repository.CartDetailsRepository;
import com.Project.BookWorm.Repository.ProductBeneficiaryRepository;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

@Service
public class RoyaltyCalculationService {
    private static final Logger logger = LoggerFactory.getLogger(RoyaltyCalculationService.class);

    @Autowired
    private RoyaltyCalculationRepository royaltyCalculationRepository;

    @Autowired
    private InvoiceRepository invoiceRepository;

    @Autowired
    private CartMasterRepository cartMasterRepository;

    @Autowired
    private CartDetailsRepository cartDetailsRepository;

    @Autowired
    private ProductBeneficiaryRepository productBeneficiaryRepository;

    // Get all royalty calculations
    public List<RoyaltyCalculation> getAllRoyaltyCalculations() {
        return royaltyCalculationRepository.findAll();
    }

    // Get royalty calculation by ID
    public Optional<RoyaltyCalculation> getRoyaltyCalculationById(int id) {
        return royaltyCalculationRepository.findById(id);
    }

    // Create or update royalty calculation
    public RoyaltyCalculation saveRoyaltyCalculation(RoyaltyCalculation royaltyCalculation) {
        return royaltyCalculationRepository.save(royaltyCalculation);
    }

    // Delete royalty calculation by ID
    public void deleteRoyaltyCalculation(int id) {
        royaltyCalculationRepository.deleteById(id);
    }

    // Calculate royalty using invoiceDetailsId and customerId
    public void calculateRoyalty(int invoiceId, long customerId, int cartId) {
        CartMaster cartMaster = cartMasterRepository.findByCartId(cartId).get();
        Invoice invoice = invoiceRepository.findByInvoiceId(invoiceId).get();
        List<CartDetails> cartDetailsList = cartDetailsRepository.findByCartId(cartMaster.getCartId());
        for (CartDetails cartDetails : cartDetailsList) {
            ProductMaster productMaster = cartDetails.getProductId();
            // Get all ProductBeneficiary entries for the product
            List<ProductBeneficiary> productBeneficiaries = productBeneficiaryRepository.findByProductId(productMaster.getProductId());

            for (ProductBeneficiary productBeneficiary : productBeneficiaries) {
                BeneficiaryMaster beneficiaryMaster = productBeneficiary.getBeneficiaryMaster();
                logger.info(""+beneficiaryMaster.getBenId());
                logger.info(""+productBeneficiary.getBeneficiaryId());
                double royaltyPercentage = productBeneficiary.getPercentage();

                RoyaltyCalculation royaltyCalculation = new RoyaltyCalculation();
                royaltyCalculation.setInvoice(invoice);
                royaltyCalculation.setBeneficiaryMaster(beneficiaryMaster);
                royaltyCalculation.setRoyaltyDate(LocalDate.now());
                royaltyCalculation.setProduct(productMaster);
                royaltyCalculation.setTransactionType(cartDetails.getIsRented() ? "rent" : "purchase");
                royaltyCalculation.setSalesPrice(cartDetails.getOfferCost());
                royaltyCalculation.setRoyaltyOnSalesPrice(cartDetails.getOfferCost() * (royaltyPercentage / 100)); // Calculate royalty based on percentage

                royaltyCalculationRepository.save(royaltyCalculation);
            }
        }
    }
}
