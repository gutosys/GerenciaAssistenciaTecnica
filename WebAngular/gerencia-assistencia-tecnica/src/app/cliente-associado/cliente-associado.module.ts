import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteAssociadoComponent } from './cliente-associado.component';
import { ClienteAssociadoDetailComponent } from './cliente-associado-detail/cliente-associado-detail.component';
import { ClienteAssociadoListComponent } from './cliente-associado-list/cliente-associado-list.component';
import { MaterialModule } from 'src/app/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [ClienteAssociadoComponent, ClienteAssociadoDetailComponent, ClienteAssociadoListComponent],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class ClienteAssociadoModule { }
