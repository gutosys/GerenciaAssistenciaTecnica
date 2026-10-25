import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ClienteAssociadoService } from '../../shared/cliente-associado.service';
import { NotificationService } from '../../shared/notification.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { PessoaJuridicaService } from '../../shared/pessoa-juridica-service';

@Component({
    selector: 'app-cliente-associado-detail',
    templateUrl: './cliente-associado-detail.component.html',
    styleUrls: ['./cliente-associado-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ClienteAssociadoDetailComponent implements OnInit {
  clienteAssociado: IClienteAssociado;
  originalClienteAssociado: IClienteAssociado;

  constructor(private service: ClienteAssociadoService,
    private pessoaJuridicaService: PessoaJuridicaService,
    private location: Location,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<ClienteAssociadoDetailComponent>){ }
    
    tela: string = "Cliente Associado"

  ngOnInit() {
    this.loadCombos();   
  }

  loadCombos(){    
    this.pessoaJuridicaService.populateCombo();    
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
         this.service.updateClienteAssociado(this.service.form.value)
           .subscribe(categoria => { this.clienteAssociado = this.service.form.value },
             () => null,
             () => this.dataSaved());
      }
      else {
        // Add a product
         this.service.addClienteAssociado(this.service.form.value)
           .subscribe(clienteAssociado => { this.clienteAssociado = this.service.form.value },
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
