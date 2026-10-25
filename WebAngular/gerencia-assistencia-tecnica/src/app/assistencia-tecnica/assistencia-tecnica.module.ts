import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EntradaAssistenciaListComponent } from './entrada-assistencia-list/entrada-assistencia-list.component';
import { UploadModule } from '../upload/upload.module';
import { EntradaAssistenciaDetailComponent } from './entrada-assistencia-detail/entrada-assistencia-detail.component';
import { EntradaAssistenciaComponent } from './entrada-assistencia/entrada-assistencia.component';
import { EntradaAssistenciaFilesComponent } from './entrada-assistencia-files/entrada-assistencia-files.component';
import { SharedModule } from '../shared/shared-module/shared.module';

@NgModule({
    declarations: [
        EntradaAssistenciaComponent,
        EntradaAssistenciaDetailComponent,
        EntradaAssistenciaListComponent,
        EntradaAssistenciaFilesComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        UploadModule,
        SharedModule
    ]
})
export class AssistenciaTecnicaModule { }
