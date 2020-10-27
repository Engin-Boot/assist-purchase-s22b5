import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-firstpage',
  templateUrl: './firstpage.component.html',
  styleUrls: ['./firstpage.component.css']
})
export class FirstpageComponent implements OnInit {


  constructor(@Inject("logger") loggerService:any,private router:Router) { }

  ngOnInit(): void {
  }
  onSubmit()
  {
    this.router.navigate(['./customerproduct'])
  }
  onSubmit2(){
    this.router.navigate(['./home'])
  }
  
}
