import { TestBed } from '@angular/core/testing';

import { LoanFacilityService } from './loan-facility.service';

describe('LoanFacilityService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LoanFacilityService = TestBed.get(LoanFacilityService);
    expect(service).toBeTruthy();
  });
});
