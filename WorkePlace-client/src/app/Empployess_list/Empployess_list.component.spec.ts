/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Empployess_listComponent } from './Empployess_list.component';

describe('Empployess_listComponent', () => {
  let component: Empployess_listComponent;
  let fixture: ComponentFixture<Empployess_listComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Empployess_listComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Empployess_listComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
