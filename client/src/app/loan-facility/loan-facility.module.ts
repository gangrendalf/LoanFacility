import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoanApplicationComponent } from './components/loan-application/loan-application.component';
import { OfferComponent } from './components/offer/offer.component';
import { LoanFacilityRoutingModule } from './loan-facility-routing.module';



@NgModule({
  declarations: [
    LoanApplicationComponent,
    OfferComponent
  ],
  imports: [
    CommonModule,
    LoanFacilityRoutingModule
  ],
  exports : [
    LoanApplicationComponent
  ]
})
export class LoanFacilityModule { }
