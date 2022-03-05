import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchSummaryVotesComponent } from './match-summary-votes.component';

describe('MatchSummaryVotesComponent', () => {
  let component: MatchSummaryVotesComponent;
  let fixture: ComponentFixture<MatchSummaryVotesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MatchSummaryVotesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MatchSummaryVotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
