import { TemplateRef, ViewContainerRef } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { SecurityService } from './security.service';
import { HasClaimDirective } from './has-claim.directive';

describe('HasClaimDirective', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      { provide: TemplateRef, useValue: {} },
      { provide: ViewContainerRef, useValue: { createEmbeddedView: () => undefined, clear: () => undefined } },
      { provide: SecurityService, useValue: { hasClaim: () => false } }
    ]
  }));

  it('should create an instance', () => {
    const directive = new HasClaimDirective(
      TestBed.inject(TemplateRef),
      TestBed.inject(ViewContainerRef),
      TestBed.inject(SecurityService)
    );
    expect(directive).toBeTruthy();
  });
});
