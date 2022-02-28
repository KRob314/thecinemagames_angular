import { TestBed } from '@angular/core/testing';

import { MovieSubmissionService } from './movie-submission.service';

describe('MovieSubmissionService', () => {
  let service: MovieSubmissionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MovieSubmissionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
