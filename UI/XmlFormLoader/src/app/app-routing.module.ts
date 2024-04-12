import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormAddressComponent } from './form-address/form-address.component';
import { PaymentOptionsComponent } from './payment-options/payment-options.component';

const routes: Routes = [
  { path: 'form/:country', component: FormAddressComponent },
  { path: 'payment/:country', component: PaymentOptionsComponent },
  // { path: 'order/:country', component: OrderComponent },
  { path: '**', redirectTo: 'form/UK' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
