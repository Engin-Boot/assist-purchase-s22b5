import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
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
  ngOnInit(): void {
    this.fetchString();
  }
  fetchString(){
    this.panservice.submitList2(this.referenceForm.value).subscribe((result)=>{
      this.value=result;
      console.log(result);
    })
  }
  onSubmit() {
    this.router.navigate(['/product']);

  }
  onSubmit2(){
    this.router.navigate(['/sign']);

  }
  onSubmit3(){
    console.log(this.referenceForm.value);
this.panservice.submitList2(this.referenceForm.value).subscribe((result)=>{
},error=>{
  });
    this.router.navigate(['/product']);
  }

}
