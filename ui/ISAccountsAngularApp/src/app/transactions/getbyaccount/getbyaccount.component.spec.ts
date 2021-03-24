import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetbyaccountComponent } from './getbyaccount.component';

describe('GetbyaccountComponent', () => {
  let component: GetbyaccountComponent;
  let fixture: ComponentFixture<GetbyaccountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetbyaccountComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetbyaccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
