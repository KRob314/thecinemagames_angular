import { TestBed } from '@angular/core/testing';

import { SeasonStandingsService } from './season-standings.service';

describe('SeasonStandingsService', () => {
  let service: SeasonStandingsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SeasonStandingsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
