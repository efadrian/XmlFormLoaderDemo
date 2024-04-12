import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormAddressComponent } from './form-address/form-address.component';
import { HttpClientModule } from '@angular/common/http';
import { MenuBarComponent } from './menu-bar/menu-bar.component';
import { PaymentOptionsComponent } from './payment-options/payment-options.component';

@NgModule({
  declarations: [
    AppComponent,
    FormAddressComponent,
    MenuBarComponent,
    PaymentOptionsComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
