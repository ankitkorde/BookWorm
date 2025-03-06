package com.Project.BookWorm.Service;

import java.util.List;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.Project.BookWorm.Models.AttributeMaster;
import com.Project.BookWorm.Repository.AttributeMasterRepository;

@Service
public class AttributeMasterService {

     @Autowired
	private AttributeMasterRepository attributeMasterRepository;
	
	public List<AttributeMaster> getAllAttributes() {
        return attributeMasterRepository.findAll();
    }

    public AttributeMaster getAttributeById(int id) {
        return attributeMasterRepository.findById(id).orElse(null);
    }

    public AttributeMaster savAttribute_Master(AttributeMaster attributeMaster) {
        return attributeMasterRepository.save(attributeMaster);
    }

    public String deleteAttribute_Master(int id) {
        attributeMasterRepository.deleteById(id);
        return "Attribute removed !! " + id;
    }

}
