package com.Project.BookWorm.Service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.Project.BookWorm.Models.Invoice;
import com.Project.BookWorm.Models.CartMaster;
import com.Project.BookWorm.Repository.InvoiceRepository;
import com.Project.BookWorm.Repository.CartMasterRepository;
import com.Project.BookWorm.Service.RoyaltyCalculationService;

import java.sql.Date;
import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

@Service
public class InvoiceService {

    @Autowired
    private InvoiceRepository invoiceRepository;

    @Autowired
    private CartMasterRepository cartMasterRepository;

    @Autowired
    private RoyaltyCalculationService royaltyCalculationService;

    public List<Invoice> getAllInvoices() {
        return invoiceRepository.findAll();
    }

    public Optional<Invoice> getInvoiceById(int id) {
        return invoiceRepository.findById(id);
    }

    public Invoice saveInvoice(Invoice invoice) {
        return invoiceRepository.save(invoice);
    }

    public void deleteInvoice(int id) {
        invoiceRepository.deleteById(id);
    }

    public Invoice createInvoiceAndCalculateRoyalty(long customerId, int cartId) {
        Optional<CartMaster> cartMasterOptional = cartMasterRepository.findById(cartId);

        if (!cartMasterOptional.isPresent()) {
            throw new RuntimeException("Invalid customerId");
        }

        CartMaster cartMaster = cartMasterOptional.get();
        Invoice invoice = new Invoice();
        invoice.setCustomerId(cartMaster.getCustomer());
        invoice.setCartId(cartMaster);
        invoice.setAmount(cartMaster.getCost());
        invoice.setDate(Date.valueOf(LocalDate.now())); // Convert LocalDate to java.sql.Date

        return invoiceRepository.save(invoice);
    }
}
