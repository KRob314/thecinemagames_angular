import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieSubmissionComponent } from './movie-submission.component';

describe('MovieSubmissionComponent', () => {
  let component: MovieSubmissionComponent;
  let fixture: ComponentFixture<MovieSubmissionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieSubmissionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieSubmissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
