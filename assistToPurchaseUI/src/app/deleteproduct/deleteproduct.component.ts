import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SignupService } from '../service/signup.service';

@Component({
  selector: 'app-deleteproduct',
  templateUrl: './deleteproduct.component.html',
  styleUrls: ['./deleteproduct.component.css']
})
export class DeleteproductComponent implements OnInit {

  list=[];
  referenceForm: FormGroup;
  errorMessage=""
  //[{"id":"MRN001","name":"Tom","password":"Tom123","email":"Tom@gmail.com"},{"id":"MRN002","name":"Hary","password":"Harry123","email":"Harry@gmail.com"}];
  constructor(@Inject("logger") loggerService:any,private panservice:SignupService,private router:Router) { }
 
  
 
  ngOnInit(): void {
    this.initializeForm();
  }
  initializeForm() {
    
    this.referenceForm = new FormGroup({
      
      id : new FormControl('', [Validators.required])
    });
  }
  
 
  onSubmit(){
   console.log(this.referenceForm.get("id").value);
this.panservice.submitList3(this.referenceForm.get("id").value).subscribe((result)=>{
 
},error=>{
  });
  this.errorMessage="Product Deleted"
  this.router.navigate(['./deleteproduct'])
}
onSubmit2(){
  this.router.navigate(['./product'])
}


}
