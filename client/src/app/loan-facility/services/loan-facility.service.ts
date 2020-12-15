import { HttpClient } from '@angular/common/http';
import { mapToMapExpression } from '@angular/compiler/src/render3/util';
import { Injectable } from '@angular/core';
import { ILoanOffer } from 'src/app/shared/models/loan-offer';
import { map } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoanFacilityService {
  baseUrl = 'https://localhost:5001/api/loan/';
  offers: ILoanOffer[] = [];

  constructor(private http: HttpClient ) { }

  getOffers() {
    if(this.offers.length > 0)
      return of(this.offers);

    return this.http.get<ILoanOffer[]>(this.baseUrl + 'offers').pipe(
      map(response => {
        this.offers = response;
        return response;
      })
    );
  }
}
