import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeasonStandingsComponent } from './season-standings.component';

describe('SeasonStandingsComponent', () => {
  let component: SeasonStandingsComponent;
  let fixture: ComponentFixture<SeasonStandingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeasonStandingsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SeasonStandingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
