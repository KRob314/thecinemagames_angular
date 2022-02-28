import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppToastContainerComponent } from './app-toast-container.component';

describe('AppToastContainerComponent', () => {
  let component: AppToastContainerComponent;
  let fixture: ComponentFixture<AppToastContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppToastContainerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppToastContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
