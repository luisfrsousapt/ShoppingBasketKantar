import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HeroSliderComponent } from './components/hero-slider/hero-slider.component';
import { ItemCardComponent } from './components/item-card/item-card.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { ProductsComponent } from './components/products/products.component';
import { AccountComponent } from './components/account/account.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { HttpClientModule } from '@angular/common/http';
import { QuantitySelectorComponent } from './components/quantity-selector/quantity-selector.component';
import { ToastrModule } from 'ngx-toastr';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { BasketService } from './services/basket.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeroSliderComponent,
    ItemCardComponent,
    HomepageComponent,
    ProductsComponent,
    AccountComponent,
    CheckoutComponent,
    QuantitySelectorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [BasketService],
  bootstrap: [AppComponent]
})
export class AppModule { }
