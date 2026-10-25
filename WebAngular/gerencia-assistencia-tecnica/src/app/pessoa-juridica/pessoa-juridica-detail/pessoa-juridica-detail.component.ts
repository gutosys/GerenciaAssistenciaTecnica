import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { IPessoaJuridica } from '../pessoa-juridica';
import { PessoaJuridicaService } from 'src/app/shared/pessoa-juridica-service';
import { NotificationService } from 'src/app/shared/notification.service';
import { EstadoService } from 'src/app/shared/estado.service';
import { CidadeService } from 'src/app/shared/cidade.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { RegimeTributarioService } from 'src/app/shared/regime-tributario.service';

@Component({
    selector: 'app-pessoa-juridica-detail',
    templateUrl: './pessoa-juridica-detail.component.html',
    styleUrls: ['./pessoa-juridica-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class PessoaJuridicaDetailComponent implements OnInit {
  pessoaJuridica: IPessoaJuridica;
  originalPessoaJuridica: IPessoaJuridica;
  cidades: ICidade[];
  tela: string = "Pessoa Jurídica";
  errors: string[];

  constructor(private service: PessoaJuridicaService,
    private location: Location,
    private notificationService: NotificationService,
    private estadoService: EstadoService,
    private cidadeService: CidadeService,    
    private regimeTributarioService: RegimeTributarioService,
    public dialogRef: MatDialogRef<PessoaJuridicaDetailComponent>) { }

  ngOnInit() {

    this.loadCombos();
    this.errors = [];

    if (this.service.form.value.estadoId != null) {
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
      )
    }
  }

  loadCombos(){    
    this.regimeTributarioService.populateCombo();    
  }


  onClear() {
    this.service.form.reset();
    this.service.initializeFormGroup();
  }

  onSubmit() {
    this.errors = [];

    if (this.service.form.valid) {
      if (this.service.form.value.id) {
        // Update product
        this.service.updatePessoaJuridica(this.service.form.value)
          .subscribe(pessoaJuridica => { this.pessoaJuridica = this.service.form.value },
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
        this.service.addPessoaJuridica(this.service.form.value)
          .subscribe(pessoaJuridica => { this.pessoaJuridica = this.service.form.value },
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

  onClose() {
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
    )
  }

}
