import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProblemaListComponent } from './problema-list/problema-list.component';
import { ProblemaDetailComponent } from './problema-detail/problema-detail.component';
import { ProblemaComponent } from './problema.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [
        ProblemaComponent,
        ProblemaListComponent,
        ProblemaDetailComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
    ]
})

export class ProblemaModule { }
