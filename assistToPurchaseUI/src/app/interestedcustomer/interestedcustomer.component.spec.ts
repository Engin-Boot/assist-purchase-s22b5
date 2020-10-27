import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterestedcustomerComponent } from './interestedcustomer.component';

describe('InterestedcustomerComponent', () => {
  let component: InterestedcustomerComponent;
  let fixture: ComponentFixture<InterestedcustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterestedcustomerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterestedcustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
