import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { RegimeTributarioService } from '../../shared/regime-tributario.service';
import { NotificationService } from '../../shared/notification.service';
import { IRegimeTributario } from '../regime-tributario';
import { Location } from '@angular/common';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
    selector: 'app-regime-tributario-detail',
    templateUrl: './regime-tributario-detail.component.html',
    styleUrls: ['./regime-tributario-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class RegimeTributarioDetailComponent implements OnInit {
  regimeTributario: IRegimeTributario;
  originalRegimeTributario: IRegimeTributario;  
  tela: string = "Regime Tributário";
  
  constructor(private service: RegimeTributarioService,
              private location: Location,
              private notificationService: NotificationService,
              public dialogRef: MatDialogRef<RegimeTributarioDetailComponent>){ }

  ngOnInit() {    
  }

  onClear(){
    this.service.form.reset();
    this.service.initializeFormGroup();    
  }

  onSubmit(){
    if(this.service.form.valid)
    {      
      if (this.service.form.value.id) {        
        // Update product
         this.service.updateRegimeTributario(this.service.form.value)
           .subscribe(regimeTributario => { this.regimeTributario = this.service.form.value },
             () => null,
             () => this.dataSaved());
      }
      else {
        // Add a product
         this.service.addRegimeTributario(this.service.form.value)
           .subscribe(regimeTributario => { this.regimeTributario = this.service.form.value },
             () => null,
             () => this.dataSaved());        
      }
    }
  }

  private dataSaved(): void {    
    this.service.form.reset();
    this.service.initializeFormGroup();
    this.notificationService.success('Salvo com sucesso');    
    this.onClose();
    
    // Redirect back to list
    //this.goBack();
  }

  onClose(){
    this.service.form.reset();
    this.service.initializeFormGroup();
    this.dialogRef.close(); 
  }

  goBack(): void {
    this.location.back();
  }
}
