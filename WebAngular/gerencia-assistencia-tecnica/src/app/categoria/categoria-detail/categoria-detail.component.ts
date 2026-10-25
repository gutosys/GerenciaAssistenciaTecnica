import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from 'src/app/shared/notification.service';
import { ICategoria } from '../categoria';
import { MatDialogRef } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { CategoriaService } from 'src/app/shared/categoria.service';

@Component({
    selector: 'app-categoria-detail',
    templateUrl: './categoria-detail.component.html',
    styleUrls: ['./categoria-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class CategoriaDetailComponent implements OnInit {
  categoria: ICategoria;
  originalcategoria: ICategoria;
  tela: string = "Categoria"

  constructor(private service: CategoriaService,
    private location: Location,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<CategoriaDetailComponent>){ }

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
         this.service.updateCategoria(this.service.form.value)
           .subscribe(categoria => { this.categoria = this.service.form.value },
             () => null,
             () => this.dataSaved());
      }
      else {
        // Add a product
         this.service.addCategoria(this.service.form.value)
           .subscribe(categoria => { this.categoria = this.service.form.value },
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
