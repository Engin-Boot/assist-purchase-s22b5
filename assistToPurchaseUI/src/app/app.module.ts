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

@NgModule({
  declarations: [
    AppComponent,
    SignupuserComponent,
    HomeComponent,
    ProductComponent
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
