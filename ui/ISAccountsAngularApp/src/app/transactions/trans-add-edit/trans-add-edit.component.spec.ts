import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransAddEditComponent } from './trans-add-edit.component';

describe('TransAddEditComponent', () => {
  let component: TransAddEditComponent;
  let fixture: ComponentFixture<TransAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
