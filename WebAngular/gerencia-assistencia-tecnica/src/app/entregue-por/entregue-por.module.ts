import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EntreguePorComponent } from './entregue-por.component';
import { EntreguePorListComponent } from './entregue-por-list/entregue-por-list.component';
import { EntreguePorDetailComponent } from './entregue-por-detail/entregue-por-detail.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared-module/shared.module';

@NgModule({
    declarations: [EntreguePorComponent, EntreguePorListComponent, EntreguePorDetailComponent],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule
    ]
})
export class EntreguePorModule { }
