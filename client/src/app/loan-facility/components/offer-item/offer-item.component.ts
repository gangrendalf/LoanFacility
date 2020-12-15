import { Component, Input, OnInit } from '@angular/core';
import { Params, Router } from '@angular/router';
import { ILoanOffer } from 'src/app/shared/models/loan-offer';

@Component({
  selector: 'app-offer-item',
  templateUrl: './offer-item.component.html',
  styleUrls: ['./offer-item.component.sass']
})
export class OfferItemComponent implements OnInit {

  @Input() offer: ILoanOffer;

  constructor(private router: Router) { 
  }

  ngOnInit() {
  }

  logOffer() {
    console.log(this.offer);
  }
}
