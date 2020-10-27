import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddproductComponent } from './addproduct/addproduct.component';
import { AppComponent } from './app.component';
import { CustomerproductComponent } from './customerproduct/customerproduct.component';
import { DetailcustomerComponent } from './detailcustomer/detailcustomer.component';
import { HomeComponent } from './home/home.component';
import { InterestedcustomerComponent } from './interestedcustomer/interestedcustomer.component';
import { ProductComponent } from './product/product.component';
import { SignupuserComponent } from './signupuser/signupuser.component';
import { UpdateproductComponent } from './updateproduct/updateproduct.component';


const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'sign' , component: SignupuserComponent },
  {path: 'product' , component: ProductComponent },
  {path:'addproduct',component:AddproductComponent},
  {path:'updateproduct',component:UpdateproductComponent},
  {path:'customerproduct',component:CustomerproductComponent},
  {path:'detailcustomer',component:DetailcustomerComponent},
  {path:'interestedcustomer',component:InterestedcustomerComponent},
  {path: '' , component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
// export const routingComponents=[HomeComponent,AppComponent,SignupuserComponent]