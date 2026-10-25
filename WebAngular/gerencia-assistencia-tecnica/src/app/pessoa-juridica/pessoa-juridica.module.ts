import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PessoaJuridicaComponent } from './pessoa-juridica.component';
import { PessoaJuridicaDetailComponent } from './pessoa-juridica-detail/pessoa-juridica-detail.component';
import { PessoaJuridicaListComponent } from './pessoa-juridica-list/pessoa-juridica-list.component';

@NgModule({
    declarations: [
        PessoaJuridicaComponent,
        PessoaJuridicaDetailComponent,
        PessoaJuridicaListComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class PessoaJuridicaModule { }
