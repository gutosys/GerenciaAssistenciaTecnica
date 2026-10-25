import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { IProblema } from '../problema';
import { ProblemaService } from '../../shared/problema.service';

@Component({
    selector: 'app-problema-detail',
    templateUrl: './problema-detail.component.html',
    styleUrls: ['./problema-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ProblemaDetailComponent implements OnInit {

  problema: IProblema;
  originalProblema: IProblema;
  tela: string = "Problema"

  constructor(private service: ProblemaService,
    private location: Location,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<ProblemaDetailComponent>){ }

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
         this.service.updateProblema(this.service.form.value)
           .subscribe(problema => { this.problema = this.service.form.value },
             () => null,
             () => this.dataSaved());
      }
      else {
        // Add a product
         this.service.addProblema(this.service.form.value)
           .subscribe(problema => { this.problema = this.service.form.value },
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
