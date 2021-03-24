import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetbycodeComponent } from './getbycode.component';

describe('GetbycodeComponent', () => {
  let component: GetbycodeComponent;
  let fixture: ComponentFixture<GetbycodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetbycodeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetbycodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
