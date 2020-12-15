import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoanApplicationComponent } from './components/loan-application/loan-application.component';
import { OfferComponent } from './components/offer/offer.component';


const routes: Routes = [
  { path: '', component: OfferComponent },
  { path: 'application', component: LoanApplicationComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoanFacilityRoutingModule { }
