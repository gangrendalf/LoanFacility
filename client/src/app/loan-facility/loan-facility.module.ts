import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationComponent } from './components/application/application.component';
import { OfferComponent } from './components/offer/offer.component';
import { LoanFacilityRoutingModule } from './loan-facility-routing.module';



@NgModule({
  declarations: [
    ApplicationComponent,
    OfferComponent
  ],
  imports: [
    CommonModule,
    LoanFacilityRoutingModule
  ],
  exports : [
    ApplicationComponent
  ]
})
export class LoanFacilityModule { }
