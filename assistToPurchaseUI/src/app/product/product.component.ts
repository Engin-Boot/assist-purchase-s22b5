import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { SignupService } from '../service/signup.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  title = 'AssistPurchase';
  list=[];
  referenceForm: FormGroup;
  //[{"id":"MRN001","name":"Tom","password":"Tom123","email":"Tom@gmail.com"},{"id":"MRN002","name":"Hary","password":"Harry123","email":"Harry@gmail.com"}];
  constructor(@Inject("logger") loggerService:any,private panservice:SignupService,private router:Router) { }

  

  ngOnInit(): void {
    this.fetchList();
    
  }
  
  

 

  fetchList(){
    this.panservice.getList().subscribe((result)=>{
      this.list=result;
      console.log(result);
    })
  }
  onSubmit(){
    
  this.router.navigate(['./home'])
}
onSubmit2(){
  this.router.navigate(['./addproduct'])
}
onSubmit3(){
  this.router.navigate(['./updateproduct'])
}

}
