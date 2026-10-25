import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardGarantiaComponent } from './board-garantia.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { DragDropModule } from '@angular/cdk/drag-drop';

@NgModule({
  declarations: [BoardGarantiaComponent],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    DragDropModule   
  ]
})
export class BoardGarantiaModule { }
