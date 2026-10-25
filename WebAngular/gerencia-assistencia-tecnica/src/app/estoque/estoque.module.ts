import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { EstoqueComponent } from './estoque.component';
import { EstoqueDetailComponent } from './estoque-detail/estoque-detail.component';
import { EstoqueListComponent } from './estoque-list/estoque-list.component';
import { SharedModule } from '../shared/shared-module/shared.module';

@NgModule({
    declarations: [
        EstoqueComponent,
        EstoqueDetailComponent,
        EstoqueListComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule
    ]
})
export class EstoqueModule { }
