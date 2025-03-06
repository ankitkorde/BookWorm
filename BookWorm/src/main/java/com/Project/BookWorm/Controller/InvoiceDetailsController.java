package com.Project.BookWorm.Controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import com.Project.BookWorm.Models.InvoiceDetails;
import com.Project.BookWorm.Service.InvoiceDetailsService;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/invoice-details")
public class InvoiceDetailsController {

    @Autowired
    private InvoiceDetailsService invoiceDetailsService;

    @GetMapping
    public List<InvoiceDetails> getAllInvoiceDetails() {
        return invoiceDetailsService.getAllInvoiceDetails();
    }

    @GetMapping("/{id}")
    public ResponseEntity<InvoiceDetails> getInvoiceDetailById(@PathVariable int id) {
        Optional<InvoiceDetails> invoiceDetail = invoiceDetailsService.getInvoiceDetailById(id);
        return invoiceDetail.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PostMapping
    public InvoiceDetails createInvoiceDetail(@RequestBody InvoiceDetails invoiceDetail) {
        return invoiceDetailsService.saveInvoiceDetail(invoiceDetail);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteInvoiceDetail(@PathVariable int id) {
        invoiceDetailsService.deleteInvoiceDetail(id);
        return ResponseEntity.noContent().build();
    }
}
