import { HttpClient } from '@angular/common/http';
import { Provider } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';

export default [
  {
    provide: ActivatedRoute,
    useValue: {
      snapshot: {
        paramMap: { get: () => null },
        queryParamMap: { get: () => null }
      }
    }
  },
  { provide: Router, useValue: { navigateByUrl: () => Promise.resolve(true) } },
  { provide: MatDialogRef, useValue: { close: () => undefined } },
  { provide: MAT_DIALOG_DATA, useValue: {} },
  {
    provide: HttpClient,
    useValue: {
      get: () => of([]),
      post: () => of({}),
      put: () => of({}),
      patch: () => of({}),
      delete: () => of({})
    }
  }
] satisfies Provider[];
