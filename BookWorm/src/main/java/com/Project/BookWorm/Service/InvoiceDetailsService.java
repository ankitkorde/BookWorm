package com.Project.BookWorm.Service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.Project.BookWorm.Models.InvoiceDetails;
import com.Project.BookWorm.Models.Invoice;
import com.Project.BookWorm.Models.CartDetails;
import com.Project.BookWorm.Models.CartMaster;
import com.Project.BookWorm.Models.RoyaltyCalculation;
import com.Project.BookWorm.Repository.InvoiceDetailsRepository;
import com.Project.BookWorm.Repository.InvoiceRepository;
import com.Project.BookWorm.Repository.CartDetailsRepository;
import com.Project.BookWorm.Repository.CartMasterRepository;
import com.Project.BookWorm.Repository.RoyaltyCalculationRepository;

import java.util.List;
import java.util.Optional;

@Service
public class InvoiceDetailsService {
    private static final Logger logger = LoggerFactory.getLogger(InvoiceDetailsService.class);

    @Autowired
    private InvoiceDetailsRepository invoiceDetailsRepository;

    @Autowired
    private InvoiceRepository invoiceRepository;

    @Autowired
    private CartDetailsRepository cartDetailsRepository;

    @Autowired
    private CartMasterRepository cartMasterRepository;

    @Autowired
    private RoyaltyCalculationRepository royaltyCalculationRepository;

    @Autowired
    private RoyaltyCalculationService royaltyCalculationService;

    public List<InvoiceDetails> getAllInvoiceDetails() {
        return invoiceDetailsRepository.findAll();
    }

    public Optional<InvoiceDetails> getInvoiceDetailById(int id) {
        return invoiceDetailsRepository.findById(id);
    }

    public InvoiceDetails saveInvoiceDetail(InvoiceDetails invoiceDetail) {
        return invoiceDetailsRepository.save(invoiceDetail);
    }

    public void deleteInvoiceDetail(int id) {
        invoiceDetailsRepository.deleteById(id);
    }

    public void createInvoiceDetails(int invoiceId) {
        Invoice invoice = invoiceRepository.findByInvoiceId(invoiceId).orElseThrow(() -> new RuntimeException("Invoice not found"));
        List<CartDetails> cartDetailsList = cartDetailsRepository.findByCartId(invoice.getCartId().getCartId());

        for (CartDetails cartDetails : cartDetailsList) {
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.setInvoice(invoice);
            invoiceDetails.setProduct(cartDetails.getProductId());
            invoiceDetails.setQuantity(1); // Assuming quantity is always 1 for simplicity
            invoiceDetails.setTranType(cartDetails.getIsRented() ? "rent" : "purchase");
            invoiceDetails.setRentNoOfDays(cartDetails.getRentNoOfDays());
            invoiceDetails.setSellPrice(cartDetails.getOfferCost());
            invoiceDetailsRepository.save(invoiceDetails);
        }
        royaltyCalculationService.calculateRoyalty(invoiceId, invoice.getCustomerId().getCustomerid(), invoice.getCartId().getCartId());
        //calculateAndStoreRoyaltyAmount(invoiceId);
    }

    // public void calculateAndStoreRoyaltyAmount(int invoiceId) {
    //     List<InvoiceDetails> invoiceDetailsList = invoiceDetailsRepository.findByInvoiceId(invoiceId);

    //     for (InvoiceDetails invoiceDetails : invoiceDetailsList) {
    //         double totalRoyaltyAmount = royaltyCalculationRepository.findByInvoiceIdAndProductId(invoiceId, invoiceDetails.getProduct().getProductId());
    //         invoiceDetails.setRoyaltyAmount(totalRoyaltyAmount);
    //         invoiceDetailsRepository.save(invoiceDetails);
    //     }
    // }
}
