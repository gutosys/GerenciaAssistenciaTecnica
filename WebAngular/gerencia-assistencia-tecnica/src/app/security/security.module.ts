import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HasClaimDirective } from './has-claim.directive';

@NgModule({
  declarations: [    
    LoginComponent    
  ],
  imports: [
    CommonModule,    
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,    
    RouterModule.forChild([
      { path: 'login', component: LoginComponent },
    ])
  ]
})

export class SecurityModule {
  
 }
