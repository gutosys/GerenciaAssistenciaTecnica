import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AcessorioDetailComponent } from './acessorio-detail/acessorio-detail.component';
import { AcessorioListComponent } from './acessorio-list/acessorio-list.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { AcessorioComponent } from './acessorio.component';

@NgModule({
    declarations: [
        AcessorioDetailComponent,
        AcessorioListComponent,
        AcessorioComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class AcessorioModule { }
