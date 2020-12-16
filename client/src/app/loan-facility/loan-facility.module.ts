import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationComponent } from './components/application/application.component';
import { OfferComponent } from './components/offer/offer.component';
import { LoanFacilityRoutingModule } from './loan-facility-routing.module';
import { OfferItemComponent } from './components/offer-item/offer-item.component';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApplicationFormComponent } from './components/application-form/application-form.component';


@NgModule({
  declarations: [
    ApplicationComponent,
    OfferComponent,
    OfferItemComponent,
    ApplicationFormComponent
  ],
  imports: [
    CommonModule,
    LoanFacilityRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports : [
    ApplicationComponent
  ]
})
export class LoanFacilityModule { }
