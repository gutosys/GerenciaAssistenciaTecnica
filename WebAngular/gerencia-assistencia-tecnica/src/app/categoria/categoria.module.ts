import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CategoriaComponent } from './categoria.component';
import { CategoriaDetailComponent } from './categoria-detail/categoria-detail.component';
import { CategoriaListComponent } from './categoria-list/categoria-list.component';

@NgModule({
    declarations: [
        CategoriaComponent,
        CategoriaDetailComponent,
        CategoriaListComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        // RouterModule.forChild([
        //   { path: 'categoria', component: CategoriaComponent },
        // ])
    ]
})
export class CategoriaModule { }
