import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SignupService } from '../service/signup.service';

@Component({
  selector: 'app-detailcustomer',
  templateUrl: './detailcustomer.component.html',
  styleUrls: ['./detailcustomer.component.css']
})
export class DetailcustomerComponent implements OnInit {
  title = 'AssistPurchase';
  list=[];
  errorMessage=""
  referenceForm: FormGroup;
  //[{"id":"MRN001","name":"Tom","password":"Tom123","email":"Tom@gmail.com"},{"id":"MRN002","name":"Hary","password":"Harry123","email":"Harry@gmail.com"}];
  constructor(@Inject("logger") loggerService:any,private panservice:SignupService,private router:Router) { }
 
  
 
  ngOnInit(): void {
    this.fetchList();
    this.initializeForm();
  }
  initializeForm() {
    this.referenceForm = new FormGroup({
      productname : new FormControl('', [Validators.required]),
      email : new FormControl('', [Validators.required]),
      phonenumber : new FormControl('', [Validators.required]),
    });
  }
  
  fetchList(){
    this.panservice.getList().subscribe((result)=>{
      this.list=result;
      console.log(result);
    })
  }
  onSubmit(){
    console.log(this.referenceForm.value);
this.panservice.submitList4(this.referenceForm.value).subscribe((result)=>{
 
 
 
},error=>{
  });
  this.errorMessage="Interest Submitted Successfully";
  this.router.navigate(['./detailcustomer'])
}
onSubmit2(){
  this.router.navigate(['./customerproduct'])
}

}
