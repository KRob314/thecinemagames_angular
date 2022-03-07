import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitVotesComponent } from './submit-votes.component';

describe('SubmitVotesComponent', () => {
  let component: SubmitVotesComponent;
  let fixture: ComponentFixture<SubmitVotesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubmitVotesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubmitVotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
