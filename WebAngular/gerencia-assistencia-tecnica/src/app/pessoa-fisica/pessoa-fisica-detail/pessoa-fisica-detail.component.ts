import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { PessoaFisicaService } from '../../shared/pessoa-fisica.service';
import { NotificationService } from '../../shared/notification.service';
import { IPessoaFisica } from '../pessoa-fisica';
import { Location } from '@angular/common';
import { MatDialogRef } from '@angular/material/dialog';
import { EstadoService } from 'src/app/shared/estado.service';
import { CidadeService } from 'src/app/shared/cidade.service';

@Component({
    selector: 'app-pessoa-fisica-detail',
    templateUrl: './pessoa-fisica-detail.component.html',
    styleUrls: ['./pessoa-fisica-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})

export class PessoaFisicaDetailComponent implements OnInit {
  pessoaFisica: IPessoaFisica;
  originalPessoaFisica: IPessoaFisica;
  cidades: ICidade[];
  tela: string = "Pessoa Física";
  errors: string[];


  constructor(private service: PessoaFisicaService,
              private location: Location,
              private notificationService: NotificationService,
              private estadoService: EstadoService,
              private cidadeService: CidadeService,              
              public dialogRef: MatDialogRef<PessoaFisicaDetailComponent>){ }

  ngOnInit() {
    console.log(this.service.form.value);

    this.errors = [];

    if(this.service.form.value.estadoId != null){
      this.cidadeService.getCidades(this.service.form.value.estadoId).subscribe(  
        list => {
          this.cidades = list.map(item => {          
            return {
              id: item.id,
              descricao: item.descricao,
              estadoId: item.estadoId            
            };
          });
      }
      )}
    }

  onClear(){
    this.service.form.reset();
    this.service.initializeFormGroup();    
  }

  onSubmit(){
    this.errors = [];

    if(this.service.form.valid)
    {      
      if (this.service.form.value.id) {        
        // Update product
         this.service.updatePessoaFisica(this.service.form.value)
           .subscribe(pessoaFisica => { this.pessoaFisica = this.service.form.value },
            (err) => {
              if (err.status === 400) {
                for (var fieldName in err.error) {
                  if (err.error.hasOwnProperty(fieldName)) {
                    this.errors.push(err.error[fieldName]);
                  }
                }
              } else {
                this.errors.push("something went wrong!");
              }
            },
             () => this.dataSaved());
      }
      else {
        // Add a product        
         this.service.addPessoaFisica(this.service.form.value)
           .subscribe(pessoaFisica => { this.pessoaFisica = this.service.form.value },
            (err) => {
              if (err.status === 400) {
                for (var fieldName in err.error) {
                  if (err.error.hasOwnProperty(fieldName)) {
                    this.errors.push(err.error[fieldName]);
                  }
                }
              } else {
                this.errors.push("something went wrong!");
              }
            },
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

  onSelect(event) {    
    this.cidadeService.getCidades(event.value).subscribe(  
      list => {
        this.cidades = list.map(item => {          
          return {
            id: item.id,
            descricao: item.descricao,
            estadoId: item.estadoId            
          };
        });
  }
    )}
  }


