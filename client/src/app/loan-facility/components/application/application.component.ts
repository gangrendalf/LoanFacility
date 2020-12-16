import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map, switchMap } from 'rxjs/operators';
import { ILoan } from 'src/app/shared/models/loan';
import { ILoanApplication } from 'src/app/shared/models/loan-application';
import { LoanFacilityService } from '../../services/loan-facility.service';

@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.sass']
})
export class ApplicationComponent implements OnInit {
  loan: ILoan;
  application: ILoanApplication;

  displayDurationInMonths = true;
  minDurationInGivenUnits: number;
  maxDurationInGivenUnits: number;
  selectedDurationInGivenUnits: number;

  constructor(private loanFacilityService: LoanFacilityService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.pipe(
      map(paramMap => paramMap.get("searchString")),
      switchMap(searchString => this.getLoan(searchString)))
      .subscribe(loan => {
        this.loan = loan;
        this.initializeApplicationWithDefaults(loan);
      })
  }

  getLoan(searchString: string) {
    return this.loanFacilityService.getLoan(searchString)
  }

  initializeApplicationWithDefaults(loan: ILoan) {
    this.application = {
      annualInterest: loan.interestPerYear,
      durationInMonths: 180,
      payoffsPerYear: 12,
      amount: (loan.minAmount + loan.maxAmount)/2
    }
    this.updateDurationForGivenUnits("Years");

  }

  updateDurationForGivenUnits(units: "Years" | "Months") {
    if(units == "Months") {
      this.displayDurationInMonths = true;

      this.minDurationInGivenUnits = this.loan.minDurationInMonths;
      this.maxDurationInGivenUnits = this.loan.maxDurationInMonths;

      this.selectedDurationInGivenUnits = this.application.durationInMonths;
    } else if(units == "Years") {
      this.displayDurationInMonths = false;

      this.minDurationInGivenUnits = this.loan.minDurationInMonths/12;
      this.maxDurationInGivenUnits = this.loan.maxDurationInMonths/12;

      this.selectedDurationInGivenUnits = this.application.durationInMonths/12;
    }
  }

  updateDuration(duration: number) {
    if(this.displayDurationInMonths) {
      this.application.durationInMonths = duration; 
      this.updateDurationForGivenUnits("Months");
    }
    else {
      this.application.durationInMonths = duration * 12; 
      this.updateDurationForGivenUnits("Years");
    }
  }


}
