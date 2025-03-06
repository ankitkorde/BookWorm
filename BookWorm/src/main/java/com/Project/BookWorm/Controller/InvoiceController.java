package com.Project.BookWorm.Controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import com.Project.BookWorm.Models.Invoice;
import com.Project.BookWorm.Models.InvoiceRequest;
import com.Project.BookWorm.Service.InvoiceService;
import com.Project.BookWorm.Service.InvoiceDetailsService;
import com.Project.BookWorm.Service.CartMasterService;
import com.Project.BookWorm.Repository.CartMasterRepository;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/invoices")
@CrossOrigin("*")
public class InvoiceController {

    @Autowired
    private InvoiceService invoiceService;

    @Autowired
    private InvoiceDetailsService invoiceDetailsService;

    @Autowired
    private CartMasterRepository cartMasterRepository;

    @Autowired
    private CartMasterService cartMasterService;

    @GetMapping
    public List<Invoice> getAllInvoices() {
        return invoiceService.getAllInvoices();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Invoice> getInvoiceById(@PathVariable int id) {
        Optional<Invoice> invoice = invoiceService.getInvoiceById(id);
        return invoice.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PostMapping
    public ResponseEntity<Invoice> createInvoice(@RequestBody InvoiceRequest invoiceRequest) {
        try {
            Invoice savedInvoice = invoiceService.createInvoiceAndCalculateRoyalty(invoiceRequest.getCustomerId(), invoiceRequest.getCartId());
            invoiceDetailsService.createInvoiceDetails(savedInvoice.getInvoiceId());
            return ResponseEntity.status(201).body(savedInvoice);
        } catch (RuntimeException e) {
            return ResponseEntity.badRequest().body(null);
        }
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteInvoice(@PathVariable int id) {
        invoiceService.deleteInvoice(id);
        return ResponseEntity.noContent().build();
    }
}
