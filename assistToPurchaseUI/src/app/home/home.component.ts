import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { SignupService } from '../service/signup.service';
 
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  referenceForm: FormGroup;
  constructor(@Inject("logger") loggerService:any,private panservice:SignupService,private router:Router) { }
 value:string;
 errorMessage=""
  ngOnInit(): void {
     this.initializeForm();
  }
  initializeForm() {
    this.referenceForm = new FormGroup({
      email : new FormControl(''),
      password : new FormControl(''),
      
    });
  }
  
  onSubmit() {
    this.router.navigate(['/product']);
 
  }
  onSubmit2(){
    this.router.navigate(['/sign']);
 
  }
  onSubmit3(){
    console.log(this.referenceForm.get("email").value);
    console.log(this.referenceForm.get("password").value);
    if(this.referenceForm.get("email").value=="admin" && this.referenceForm.get("password").value=="admin"){
      this.errorMessage="Login Successfull";
      this.router.navigate(['/product']);
    }
    this.errorMessage="Invalid Credentials";
 
  }
 
}