import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EtiquetaDetailComponent } from './etiqueta-detail/etiqueta-detail.component';
import { EtiquetaListComponent } from './etiqueta-list/etiqueta-list.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared-module/shared.module';
import { EtiquetaComponent } from './etiqueta.component';

@NgModule({
    declarations: [EtiquetaComponent, EtiquetaDetailComponent, EtiquetaListComponent],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule
    ]
})
export class EtiquetaModule { }
