import { TestBed } from '@angular/core/testing';

import { SeasonSummaryService } from './season-summary.service';

describe('SeasonSummaryService', () => {
  let service: SeasonSummaryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SeasonSummaryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
