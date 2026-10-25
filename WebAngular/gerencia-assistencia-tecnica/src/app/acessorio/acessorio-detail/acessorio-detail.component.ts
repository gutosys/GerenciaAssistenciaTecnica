import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialogRef } from '@angular/material/dialog';
import { IAcessorio } from '../acessorio';
import { Location } from '@angular/common';
import { AcessorioService } from 'src/app/shared/acessorio.service';

@Component({
    selector: 'app-acessorio-detail',
    templateUrl: './acessorio-detail.component.html',
    styleUrls: ['./acessorio-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class AcessorioDetailComponent implements OnInit {
  acessorio: IAcessorio;
  originalacessorio: IAcessorio;
  tela: string = "Acessório";

  constructor(private service: AcessorioService,
    private location: Location,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<AcessorioDetailComponent>){ }

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
         this.service.updateAcessorio(this.service.form.value)
           .subscribe(acessorio => { this.acessorio = this.service.form.value },
             () => null,
             () => this.dataSaved());
      }
      else {
        // Add a product
         this.service.addAcessorio(this.service.form.value)
           .subscribe(acessorio => { this.acessorio = this.service.form.value },
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
