package com.Project.BookWorm.Controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import com.Project.BookWorm.Models.AttributeMaster;
import com.Project.BookWorm.Service.AttributeMasterService;


@RestController
@RequestMapping("/api/attribute")
@CrossOrigin(origins = "*")
public class AttributeController {
    @Autowired
    private AttributeMasterService attributeMasterService;

    @GetMapping
    public List<AttributeMaster> getAllAttributes() {
        return attributeMasterService.getAllAttributes();
    }

    @GetMapping("/{id}")
    public AttributeMaster AttributeById(@PathVariable int id) {
        AttributeMaster attribute = attributeMasterService.getAttributeById(id);
        if(attribute == null) {
            throw new RuntimeException("Attribute not found for the Id:"+id);
        }
        return attribute;
    }

    @PostMapping("/add")
    public ResponseEntity<AttributeMaster> createAttributeType(@RequestBody AttributeMaster AttributeType) {
    	AttributeMaster savedProductType = attributeMasterService.savAttribute_Master(AttributeType);
        return new ResponseEntity<>(savedProductType, HttpStatus.CREATED);
    }

    

}
