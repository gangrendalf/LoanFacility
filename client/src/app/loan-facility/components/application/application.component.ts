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

  constructor(private loanFacilityService: LoanFacilityService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.pipe(
      map(paramMap => paramMap.get("searchString")),
      switchMap(searchString => this.getLoan(searchString)))
      .subscribe(loan => {
        this.loan = loan;
      })
  }

  getLoan(searchString: string) {
    return this.loanFacilityService.getLoan(searchString)
  }

  onSubmit(application: ILoanApplication) {
    this.loanFacilityService.getPaybackSchedule(application).subscribe(response => {
      console.log(response);
    })
  }



}
