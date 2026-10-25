import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { EtiquetaService } from '../../shared/etiqueta.service';
import { NotificationService } from '../../shared/notification.service';
import { ComponenteService } from '../../shared/componente.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { CorService } from '../../shared/cor.service';

@Component({
    selector: 'app-etiqueta-detail',
    templateUrl: './etiqueta-detail.component.html',
    styleUrls: ['./etiqueta-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EtiquetaDetailComponent implements OnInit {
  etiqueta: IEtiqueta;
  originalEtiqueta: IEtiqueta;
  cores: ICor[];
  tela: string = "Etiqueta"

  constructor(private service: EtiquetaService,
    private corService: CorService,
    private location: Location,
    private notificationService: NotificationService,    
    private componenteService: ComponenteService,              
    public dialogRef: MatDialogRef<EtiquetaDetailComponent>){ }

    ngOnInit() {
      //console.log(this.service.form.value);
  
      // if(this.service.form.value.id != null){
      //   this.componenteService.getComponentes().subscribe(  
      //     list => {
      //       this.componentes = list.map(item => {          
      //         return {
      //           id: item.id,
      //           descricao: item.descricao,
      //           estadoId: item.estadoId            
      //         };
      //       });
      //   }
      //   )}
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
           this.service.updateEtiqueta(this.service.form.value)
             .subscribe(estoque => { this.etiqueta= this.service.form.value },
               () => null,
               () => this.dataSaved());
        }
        else {
          // Add a product        
           this.service.addEtiqueta(this.service.form.value)
             .subscribe(estoque => { this.etiqueta = this.service.form.value },
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
