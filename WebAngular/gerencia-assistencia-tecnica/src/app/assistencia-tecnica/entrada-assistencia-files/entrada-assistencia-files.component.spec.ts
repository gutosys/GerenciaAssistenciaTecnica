import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntradaAssistenciaFilesComponent } from './entrada-assistencia-files.component';

describe('EntradaAssistenciaFilesComponent', () => {
  let component: EntradaAssistenciaFilesComponent;
  let fixture: ComponentFixture<EntradaAssistenciaFilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [ EntradaAssistenciaFilesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EntradaAssistenciaFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
