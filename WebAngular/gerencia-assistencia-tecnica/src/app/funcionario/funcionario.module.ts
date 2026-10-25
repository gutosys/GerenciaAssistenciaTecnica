import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FuncionarioListComponent } from './funcionario-list/funcionario-list.component';
import { FuncionarioDetailComponent } from './funcionario-detail/funcionario-detail.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [
        FuncionarioListComponent,
        FuncionarioDetailComponent,
        FuncionarioComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class FuncionarioModule { }
