import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared-module/shared.module';
import { ComprovanteCompraComponent } from './comprovante-compra.component';
import { ComprovanteCompraDetailComponent } from './comprovante-compra-detail/comprovante-compra-detail.component';
import { ComprovanteCompraListComponent } from './comprovante-compra-list/compovante-compra-list.component';


@NgModule({
    declarations: [ComprovanteCompraComponent, ComprovanteCompraDetailComponent, ComprovanteCompraListComponent],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule
    ]
})
export class ComprovanteCompraModule { }
