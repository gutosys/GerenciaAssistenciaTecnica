import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HasClaimDirective } from '../../security/has-claim.directive';
import { RequiredIfDirective } from '../required-if.directive';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    HasClaimDirective,
    RequiredIfDirective
  ],
  exports:[
    HasClaimDirective,
    RequiredIfDirective
  ]
  
})
export class SharedModule { }
