import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardAssistenciaTecnicaComponent } from './board-assistencia-tecnica.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { SharedModule } from '../../shared/shared-module/shared.module';

@NgModule({
  declarations: [BoardAssistenciaTecnicaComponent],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    DragDropModule,
    SharedModule
  ]
})
export class BoardAssistenciaTecnicaModule { }
