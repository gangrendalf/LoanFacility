import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ILoan } from 'src/app/shared/models/loan';
import { ILoanApplication } from 'src/app/shared/models/loan-application';

@Component({
  selector: 'app-application-form',
  templateUrl: './application-form.component.html',
  styleUrls: ['./application-form.component.sass']
})
export class ApplicationFormComponent implements OnInit {
  @Input() loan: ILoan;
  @Output() applicationSubmit = new EventEmitter<ILoanApplication>();

  application: ILoanApplication;

  displayDurationInMonths: boolean;
  minDurationInGivenUnits: number;
  maxDurationInGivenUnits: number;
  durationInGivenUnits: number;

  amountStep: number;

  applicationForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.initializeApplicationWithDefaults(this.loan);

    this.setAmountStep();

    this.initializeFrom();
  }
  
  initializeApplicationWithDefaults(loan: ILoan) {
    this.application = {
      annualInterest: loan.interestPerYear,
      durationInMonths: loan.maxDurationInMonths,
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

      this.durationInGivenUnits = this.application.durationInMonths;
    } else if(units == "Years") {
      this.displayDurationInMonths = false;

      this.minDurationInGivenUnits = Math.ceil(this.loan.minDurationInMonths/12);
      this.maxDurationInGivenUnits = Math.ceil(this.loan.maxDurationInMonths/12);

      if( Math.round(this.application.durationInMonths / 12) >= 1 ) {
        this.durationInGivenUnits = Math.round(this.application.durationInMonths/12);
      } else {
        this.durationInGivenUnits = 1;
      }
      this.application.durationInMonths = this.durationInGivenUnits * 12;
    }
  }

  setAmountStep(){
    this.amountStep = this.loan.minAmount % 10000 == 0 ? 10000 : 1000;
  }

  initializeFrom() {
    this.applicationForm = this.fb.group({
      amount: ['', [
        Validators.min(this.loan.minAmount),
        Validators.max(this.loan.maxAmount),
        Validators.required
      ]],
      term: ['', [
        Validators.min(this.loan.minDurationInMonths),
        Validators.max(this.loan.maxDurationInMonths),
        Validators.required

      ]],
      annualInterest: ['', [
        Validators.min(0),
        Validators.max(100),
        Validators.required

      ]],
      payoffsPerYear: ['', [
        Validators.min(1),
        Validators.max(12),
        Validators.required
      ]], 
    });

    this.applicationForm.get('amount')
      .setValue(this.application.amount);

    this.applicationForm.get('term')
      .setValue(this.application.durationInMonths);
  
    this.applicationForm.get('annualInterest')
      .setValue(this.application.annualInterest);

    this.applicationForm.get('payoffsPerYear')
      .setValue(this.application.payoffsPerYear);
    }

  updateDuration(duration) {
    if(isNaN(parseInt(duration))){
      return;
    } 

    if(this.displayDurationInMonths) {
      this.application.durationInMonths = parseInt(duration); 
      this.updateDurationForGivenUnits("Months");
    }
    else {
      this.application.durationInMonths = parseInt(duration) * 12; 
      this.updateDurationForGivenUnits("Years");
    }

    this.applicationForm.get('term')
      .setValue(this.application.durationInMonths);
  }

  updateAmount(amount) {
    if(isNaN(parseInt(amount))){
      return;
    } 

    this.application.amount = parseInt(amount)

    this.applicationForm.get('amount')
      .setValue(this.application.amount);
  }

  onSubmit() {
    this.applicationSubmit.emit(this.application);
  }

}
