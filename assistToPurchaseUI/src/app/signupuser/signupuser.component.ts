import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SignupService } from '../service/signup.service';


@Component({
  selector: 'app-signupuser',
  templateUrl: './signupuser.component.html',
  styleUrls: ['./signupuser.component.css']
})
export class SignupuserComponent implements OnInit {
  title = 'AssistPurchase';
  list=[];
  referenceForm: FormGroup;
  //[{"id":"MRN001","name":"Tom","password":"Tom123","email":"Tom@gmail.com"},{"id":"MRN002","name":"Hary","password":"Harry123","email":"Harry@gmail.com"}];
  constructor(@Inject("logger") loggerService:any,private panservice:SignupService,private router:Router) { }

  

  ngOnInit(): void {
    this.fetchList();
    this.initializeForm();
  }
  initializeForm() {
    this.referenceForm = new FormGroup({
      email: new FormControl('', [Validators.required]),
      password : new FormControl('', [Validators.required]),
      repeatPassword : new FormControl('', [Validators.required]),
      // id: new FormControl('', [Validators.required]),
      // productSeries: new FormControl('', [Validators.required]),
      // productModel: new FormControl('', [Validators.required]),
      // screenSize: new FormControl('', [Validators.required]),
      // weight: new FormControl('', [Validators.required]),
      // portable: new FormControl('', [Validators.required]),
      // monitorResolution: new FormControl('', [Validators.required]),
      // measurement: new FormControl('', [Validators.required])
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
this.panservice.submitList(this.referenceForm.value).subscribe((result)=>{

 

},error=>{
  });
  this.router.navigate(['./home'])
}
  
onSubmit2(){
  this.router.navigate(['./home'])
}

}
