import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupuserComponent } from './signupuser/signupuser.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './product/product.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignupService } from './service/signup.service';
import { AddproductComponent } from './addproduct/addproduct.component';
import { UpdateproductComponent } from './updateproduct/updateproduct.component';
import { CustomerproductComponent } from './customerproduct/customerproduct.component';
import { DetailcustomerComponent } from './detailcustomer/detailcustomer.component';
import { InterestedcustomerComponent } from './interestedcustomer/interestedcustomer.component';
import { FilterComponent } from './filter/filter.component';
import { FirstpageComponent } from './firstpage/firstpage.component';
import { DeleteproductComponent } from './deleteproduct/deleteproduct.component';


@NgModule({
  declarations: [
    AppComponent,
    SignupuserComponent,
    HomeComponent,
    ProductComponent,
    AddproductComponent,
    UpdateproductComponent,
    CustomerproductComponent,
    DetailcustomerComponent,
    InterestedcustomerComponent,
    FilterComponent,
    FirstpageComponent,
    DeleteproductComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,HttpClientModule,FormsModule,ReactiveFormsModule
  ],
  providers: [{provide:'logger',useClass:SignupService},
  {provide:'apiBaseAddress',useValue:"http://localhost:53951"}],
  bootstrap: [AppComponent]
})
export class AppModule { }
