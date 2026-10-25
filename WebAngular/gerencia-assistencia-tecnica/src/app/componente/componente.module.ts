import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponenteComponent } from './componente.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material/material.module';
import { ComponenteDetailComponent } from './componente-detail/componente-detail.component';
import { ComponenteListComponent } from './componente-list/componente-list.component';

@NgModule({
    declarations: [
        ComponenteComponent,
        ComponenteDetailComponent,
        ComponenteListComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class ComponenteModule { }
