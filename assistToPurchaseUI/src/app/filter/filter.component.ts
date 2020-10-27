import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { SignupService } from '../service/signup.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  list=[];
  referenceForm: FormGroup;
  constructor(@Inject("logger") loggerService:any,private panservice:SignupService,private router:Router) { }
 
  ngOnInit(): void {
    //this.fetchList();
    this.initializeForm();
  }
  initializeForm() {
    this.referenceForm = new FormGroup({
      minwt : new FormControl(''),
      maxwt : new FormControl(''),
      port : new FormControl(''),
      minscrn : new FormControl(''),
      maxscrn : new FormControl(''),
      vitals : new FormControl('')
    });
  }
  
  fetchList4(){
    this.panservice.getListPortable(this.referenceForm.get('port').value).subscribe((result)=>{
      this.list=result;
      console.log(result);
    })
  }
 
 
  fetchList(){
    this.panservice.getListWeight(this.referenceForm.get('minwt').value,this.referenceForm.get('maxwt').value).subscribe((result)=>{
      this.list=result;
      console.log(result);
    })
  }
  fetchList2(){
    this.panservice.getListScreenSize(this.referenceForm.get('minscrn').value,this.referenceForm.get('maxscrn').value).subscribe((result)=>{
      this.list=result;
      console.log(result);
    })
  }
  fetchList3(){
    this.panservice.getListScreenWeight(this.referenceForm.get('minwt').value,this.referenceForm.get('maxwt').value,this.referenceForm.get('minscrn').value,this.referenceForm.get('maxscrn').value,this.referenceForm.get('port').value).subscribe((result)=>{
      this.list=result;
      console.log(result);
    })
  }

  onSubmit2(){
    console.log(this.referenceForm.get('port').value);
    this.fetchList();
//  this.panservice.getListWeight(this.referenceForm.get('minwt').value,this.referenceForm.get('maxwt').value).subscribe((result)=>{
 
//  },error=>{
//   });
  this.router.navigate(['./filter'])
}

onSubmit(){
  //console.log(this.referenceForm.get('minwt').value);
  this.fetchList3();
  this.router.navigate(['./filter'])
}
onSubmit3(){
    this.fetchList2();
  this.router.navigate(['./filter'])
}
onSubmit4(){
  this.fetchList4();
this.router.navigate(['./filter'])
}
onSubmit5(){
  this.router.navigate(['./customerproduct'])
}
}


