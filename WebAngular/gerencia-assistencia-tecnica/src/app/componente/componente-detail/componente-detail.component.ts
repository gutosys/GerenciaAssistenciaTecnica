import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { ComponenteService } from 'src/app/shared/componente.service';

@Component({
    selector: 'app-componente-detail',
    templateUrl: './componente-detail.component.html',
    styleUrls: ['./componente-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ComponenteDetailComponent implements OnInit {
  componente: IComponente;
  originalComponente: IComponente;
  tela: string = "Componente"

  constructor(private service: ComponenteService,
    private location: Location,
    private notificationService: NotificationService,    
    public dialogRef: MatDialogRef<ComponenteDetailComponent>){ }

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
           this.service.updateComponente(this.service.form.value)
             .subscribe(componente => { this.componente = this.service.form.value },
               () => null,
               () => this.dataSaved());
        }
        else {
          // Add a product        
           this.service.addComponente(this.service.form.value)
             .subscribe(componente => { this.componente = this.service.form.value },
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
