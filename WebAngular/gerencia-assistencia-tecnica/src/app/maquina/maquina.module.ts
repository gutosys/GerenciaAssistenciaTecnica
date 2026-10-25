import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaquinaComponent } from './maquina.component';
import { MaquinaDetailComponent } from './maquina-detail/maquina-detail.component';
import { MaquinaListComponent } from './maquina-list/maquina-list.component';

@NgModule({
    declarations: [
        MaquinaComponent,
        MaquinaDetailComponent,
        MaquinaListComponent
    ],
    imports: [
        CommonModule,
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class MaquinaModule { }
