import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    CarouselModule.forRoot()
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
