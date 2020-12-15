import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FooterComponent } from './components/footer/footer.component';
import { RouterModule } from '@angular/router';
import { AboutComponent } from './components/about/about.component';



@NgModule({
  declarations: [
    NavBarComponent, 
    FooterComponent, 
    AboutComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavBarComponent,
    FooterComponent,
    AboutComponent
  ]
})
export class CoreModule { }
