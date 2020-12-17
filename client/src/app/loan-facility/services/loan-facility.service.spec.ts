import { HttpClient } from '@angular/common/http';
import { async, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { delay } from 'rxjs/operators';
import { ILoan } from 'src/app/shared/models/loan';
import { ILoanApplication } from 'src/app/shared/models/loan-application';
import { ILoanOffer } from 'src/app/shared/models/loan-offer';
import { ISchedule } from 'src/app/shared/models/schedule';

import { LoanFacilityService } from './loan-facility.service';

fdescribe('LoanFacilityService', () => {
  const testOffers: ILoanOffer[] = [
    {description: 'test description 1', title:'test title 1', imgUrl:'test image 1', searchString: 'test string 1', id: 1},
    {description: 'test description 2', title:'test title 2', imgUrl:'test image 2', searchString: 'test string 2', id: 2},
    {description: 'test description 3', title:'test title 3', imgUrl:'test image 3', searchString: 'test string 3', id: 3}
  ];

  const testLoan: ILoan = { 
    interestPerYear: 1, 
    maxAmount: 1, 
    maxDurationInMonths: 1, 
    minAmount: 1, 
    minDurationInMonths: 1, 
    name: 'test loan 1' 
  };

  const testApplication: ILoanApplication = {
    amount: 1, 
    annualInterest: 1, 
    durationInMonths: 1, 
    payoffsPerYear: 1}

  const testSchedule: ISchedule = {
    application: testApplication,
    title: 'test title 1',
    scheduleTable: null,
    totalInterestToPay: 123,
    totalToPay: 123
  }
  
  let httpClientSpy: { get: jasmine.Spy };

  let service: LoanFacilityService;

  beforeEach(async(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);

    TestBed.configureTestingModule({
      providers: [
        { provide: HttpClient, useValue: httpClientSpy}
      ]
    }).compileComponents();
  }));

  beforeEach(() => {
    service = TestBed.get(LoanFacilityService);

  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it(`should return offers`, (done) => {
    httpClientSpy.get.and.returnValue( of<ILoanOffer[]>(testOffers) );

    service.getOffers().subscribe(response => {
      const expectation = JSON.stringify(testOffers);
      const result = JSON.stringify(response);

      expect(result).toEqual(expectation);
      done();
    });
  });

  it(`should return loans`, (done) => {
    httpClientSpy.get.and.returnValue( of<ILoan>(testLoan) );

    service.getLoan('test1').subscribe(response => {
      const expectation = JSON.stringify(testLoan);
      const result = JSON.stringify(response);
      
      expect(result).toEqual(expectation);
      done();
    })
  });

  it(`should return schedule`, (done) => {
    httpClientSpy.get.and.returnValue( of<any>({body: testSchedule}) );

    service.getPaybackSchedule(testApplication).subscribe(response => {
      const expectation = JSON.stringify(testSchedule);
      const result = JSON.stringify(response);

      expect(result).toEqual(expectation);
      done();
    })
  })
});
