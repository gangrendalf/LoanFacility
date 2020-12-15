import { ClassGetter } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { ILoanOffer } from 'src/app/shared/models/loan-offer';
import { LoanFacilityService } from '../../services/loan-facility.service';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.sass']
})
export class OfferComponent implements OnInit {
  offers: ILoanOffer[] = [];

  constructor(private loanFacilityService: LoanFacilityService) { }

  ngOnInit() {
    this.getOffers();
  }

  getOffers() {
    this.loanFacilityService.getOffers().subscribe(response => {
      this.offers = response;
    }, error => {
      console.log(error);
    });
  }

}
