import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './components/homepage/homepage.component';
import { ProductsComponent } from './components/products/products.component';
import { AccountComponent } from './components/account/account.component';
import { CheckoutComponent } from './components/checkout/checkout.component';

const routes: Routes = [
  {path:'',component:HomepageComponent,pathMatch:'full'},
  {path:'products',component:ProductsComponent,pathMatch:'full'},
  {path:'account',component:AccountComponent,pathMatch:'full'},
  {path:'checkout',component:CheckoutComponent,pathMatch:'full'},
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
