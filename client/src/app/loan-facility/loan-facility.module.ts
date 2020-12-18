import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationComponent } from './components/application/application.component';
import { OfferComponent } from './components/offer/offer.component';
import { LoanFacilityRoutingModule } from './loan-facility-routing.module';
import { OfferItemComponent } from './components/offer-item/offer-item.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApplicationFormComponent } from './components/application-form/application-form.component';
import { ScheduleComponent } from './components/schedule/schedule.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';


@NgModule({
  declarations: [
    ApplicationComponent,
    OfferComponent,
    OfferItemComponent,
    ApplicationFormComponent,
    ScheduleComponent
  ],
  imports: [
    CommonModule,
    LoanFacilityRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    PaginationModule.forRoot(),
  ],
  exports : [
    ApplicationComponent
  ]
})
export class LoanFacilityModule { }
