import { HttpClient, HttpParams } from '@angular/common/http';
import { mapToMapExpression } from '@angular/compiler/src/render3/util';
import { Injectable } from '@angular/core';
import { ILoanOffer } from 'src/app/shared/models/loan-offer';
import { map } from 'rxjs/operators';
import { of } from 'rxjs';
import { ILoan } from 'src/app/shared/models/loan';
import { ILoanApplication } from 'src/app/shared/models/loan-application';
import { ISchedule } from 'src/app/shared/models/schedule';

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

  getLoan(searchString: string) {
    return this.http.get<ILoan>(this.baseUrl + searchString);
  }

  getPaybackSchedule(application: ILoanApplication) {
    let params = new HttpParams()
      .append('amount', application.amount.toString())
      .append('annualInterest', application.annualInterest.toString())
      .append('durationInMonths', application.durationInMonths.toString())
      .append('payoffsPerYear', application.payoffsPerYear.toString());

    return this.http.get<ISchedule>(this.baseUrl + 'HomeFixed/paybackplan', {observe: 'response', params})
      .pipe(map(response => response.body));
  }


}
