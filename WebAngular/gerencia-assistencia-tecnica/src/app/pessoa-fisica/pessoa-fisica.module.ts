import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PessoaFisicaComponent } from './pessoa-fisica.component';
import { PessoaFisicaDetailComponent } from './pessoa-fisica-detail/pessoa-fisica-detail.component';
import { PessoaFisicaListComponent } from './pessoa-fisica-list/pessoa-fisica-list.component';

@NgModule({
    declarations: [
        PessoaFisicaComponent,
        PessoaFisicaDetailComponent,
        PessoaFisicaListComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class PessoaFisicaModule { }
