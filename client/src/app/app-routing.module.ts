import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './core/components/about/about.component';
import { HomeComponent } from './home/home/home.component';
import { ApplicationComponent } from './loan-facility/components/application/application.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'loan', loadChildren: () => import('./loan-facility/loan-facility.module').then(mod => mod.LoanFacilityModule) },
  { path: 'about', component: AboutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
