import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaJuridicaDetailComponent } from './pessoa-juridica-detail.component';

describe('PessoaJuridicaDetailComponent', () => {
  let component: PessoaJuridicaDetailComponent;
  let fixture: ComponentFixture<PessoaJuridicaDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [ PessoaJuridicaDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PessoaJuridicaDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
