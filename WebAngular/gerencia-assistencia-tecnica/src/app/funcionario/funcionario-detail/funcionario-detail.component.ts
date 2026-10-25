import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from 'src/app/shared/notification.service';
import { FuncionarioService } from 'src/app/shared/funcionario.service';
import { MatDialogRef } from '@angular/material/dialog';
import { IFuncionario } from '../funcionario';
import { Location } from '@angular/common';

@Component({
    selector: 'app-funcionario-detail',
    templateUrl: './funcionario-detail.component.html',
    styleUrls: ['./funcionario-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class FuncionarioDetailComponent implements OnInit {
  funcionario: IFuncionario;
  originalFuncionario: IFuncionario;
  tela: string = "Funcionário"

  constructor(private service: FuncionarioService,
              private location: Location,
              private notificationService: NotificationService,              
              public dialogRef: MatDialogRef<FuncionarioDetailComponent>) { }

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
         this.service.updateFuncionario(this.service.form.value)
           .subscribe(pessoaFisica => { this.funcionario = this.service.form.value },
             () => null,
             () => this.dataSaved());
      }
      else {
        // Add a product        
         this.service.addFuncionario(this.service.form.value)
           .subscribe(pessoaFisica => { this.funcionario = this.service.form.value },
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
