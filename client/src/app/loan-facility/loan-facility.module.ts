import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationComponent } from './components/application/application.component';
import { OfferComponent } from './components/offer/offer.component';
import { LoanFacilityRoutingModule } from './loan-facility-routing.module';
import { OfferItemComponent } from './components/offer-item/offer-item.component';



@NgModule({
  declarations: [
    ApplicationComponent,
    OfferComponent,
    OfferItemComponent
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
