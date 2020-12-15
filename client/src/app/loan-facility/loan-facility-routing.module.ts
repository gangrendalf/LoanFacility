import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ApplicationComponent } from './components/application/application.component';
import { OfferComponent } from './components/offer/offer.component';


const routes: Routes = [
  { path: '', component: OfferComponent },
  { path: ':searchString/application', component: ApplicationComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoanFacilityRoutingModule { }
