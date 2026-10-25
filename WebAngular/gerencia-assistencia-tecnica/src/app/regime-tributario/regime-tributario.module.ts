import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegimeTributarioComponent } from './regime-tributario.component';
import { RegimeTributarioListComponent } from './regime-tributario-list/regime-tributario-list.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { RouterModule } from '@angular/router';
import { RegimeTributarioDetailComponent } from './regime-tributario-detail/regime-tributario-detail.component';

@NgModule({
    declarations: [
        RegimeTributarioComponent,
        RegimeTributarioDetailComponent,
        RegimeTributarioListComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class RegimeTributarioModule { }
