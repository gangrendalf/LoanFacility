import { Component, Input, OnInit } from '@angular/core';
import { ILoanOffer } from 'src/app/shared/models/loan-offer';

@Component({
  selector: 'app-offer-item',
  templateUrl: './offer-item.component.html',
  styleUrls: ['./offer-item.component.sass']
})
export class OfferItemComponent implements OnInit {

  @Input("offer") offer: ILoanOffer;

  constructor() { }

  ngOnInit() {
  }

  openOffer() {
    // search for this.offer.searchString
  }

}
