import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from 'src/app/shared/notification.service';
import { ComponenteService } from 'src/app/shared/componente.service';

import { MatDialogRef } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { EstoqueService } from 'src/app/shared/estoque.service';

@Component({
    selector: 'app-estoque-detail',
    templateUrl: './estoque-detail.component.html',
    styleUrls: ['./estoque-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EstoqueDetailComponent implements OnInit {
  estoque: IEstoque;
  originalEstoque: IEstoque;
  componentes: IComponente[];
  tela: string = "Estoque"

  constructor(private service: EstoqueService,
    private location: Location,
    private notificationService: NotificationService,    
    private componenteService: ComponenteService,              
    public dialogRef: MatDialogRef<EstoqueDetailComponent>){ }

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
           this.service.updateEstoque(this.service.form.value)
             .subscribe(estoque => { this.estoque = this.service.form.value },
               () => null,
               () => this.dataSaved());
        }
        else {
          // Add a product        
           this.service.addEstoque(this.service.form.value)
             .subscribe(estoque => { this.estoque = this.service.form.value },
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
