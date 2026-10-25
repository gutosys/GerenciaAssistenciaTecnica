import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { MaquinaService } from '../../shared/maquina.service';
import { NotificationService } from '../../shared/notification.service';
import { IMaquina } from '../maquina';
import { Location } from '@angular/common';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
    selector: 'app-maquina-detail',
    templateUrl: './maquina-detail.component.html',
    styleUrls: ['./maquina-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class MaquinaDetailComponent implements OnInit {
  maquina: IMaquina;
  originalMaquina: IMaquina;
  tela: string = "Máquina"
  
  constructor(private service: MaquinaService,
              private location: Location,
              private notificationService: NotificationService,
              public dialogRef: MatDialogRef<MaquinaDetailComponent>){ }

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
         this.service.updateMaquina(this.service.form.value)
           .subscribe(maquina => { this.maquina = this.service.form.value },
             () => null,
             () => this.dataSaved());
      }
      else {
        // Add a product
         this.service.addMaquina(this.service.form.value)
           .subscribe(maquina => { this.maquina = this.service.form.value },
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

