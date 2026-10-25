import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { EntradaAssistenciaService } from 'src/app/shared/entrada-assistencia.service';
import { UntypedFormGroup, UntypedFormBuilder, FormArray, Validators } from '@angular/forms';
import { PessoaFisicaService } from 'src/app/shared/pessoa-fisica.service';
import { PessoaJuridicaService } from 'src/app/shared/pessoa-juridica-service';
import { FuncionarioService } from 'src/app/shared/funcionario.service';
import { MaquinaService } from 'src/app/shared/maquina.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { Location, formatDate } from '@angular/common';
import { NotificationService } from 'src/app/shared/notification.service';
import { IEntradaAssistencia, IEntradaAssistenciaDocument } from '../entrada-assistencia';
import { Inject } from '@angular/core';
import { DialogService } from 'src/app/shared/dialog.service';
import { ClienteAssociadoService } from '../../shared/cliente-associado.service';
import { ComprovanteCompraService } from '../../shared/comprovante-compra.service';
import { EntreguePorService } from 'src/app/shared/entregue-por.service';
import { AcessorioService } from 'src/app/shared/acessorio.service';

@Component({
    selector: 'app-entrada-assistencia-detail',
    templateUrl: './entrada-assistencia-detail.component.html',
    styleUrls: ['./entrada-assistencia-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EntradaAssistenciaDetailComponent implements OnInit {
  public formEntradaAssistencia: UntypedFormGroup;
  modeloTipoPessoa = 'pessoaFisica';
  HasPessoaFisica: boolean = true;
  entradaAssistencia: IEntradaAssistencia;
  teste: any;
  errors: string[];
  tela: "Entrada Assistência"

  constructor(private service: EntradaAssistenciaService,
    private fb: UntypedFormBuilder,
    private dialogService: DialogService,
    private pessoaFisicaService: PessoaFisicaService,
    private pessoaJuridicaService: PessoaJuridicaService,
    private clienteAssociadoService: ClienteAssociadoService,
    private funcionarioService: FuncionarioService,
    private comprovanteCompraService: ComprovanteCompraService,
    private entreguePorService: EntreguePorService,
    private maquinaService: MaquinaService,
    private acessorioService: AcessorioService,
    public dialogRef: MatDialogRef<EntradaAssistenciaService>,
    private dialog: MatDialog,
    private location: Location,
    private notificationService: NotificationService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }
  isNew: boolean = true;
  acessoBotoes: boolean = false;
  entradaAssistenciaDocumentoList: IEntradaAssistenciaDocument[];

  ngOnInit() {
    this.acessoBotoes = this.data.acessoBotoes;

    this.formEntradaAssistencia = this.fb.group({
      id: null,
      numeroRemessa: [''],
      numeroNF: [''],
      numeroProtocoloTroca: [''],
      numeroComprovanteCompra: ['', Validators.required],
      numeroSerie: [''],
      tipoPessoa: 'pessoaFisica',
      pessoaFisica: '',
      comprovanteCompra: ['', Validators.required],
      codigoRastreio: '',
      entreguePor: ['', Validators.required],
      pessoaJuridica: '',
      dataEntrada: '',
      ns: ['', Validators.required],
      revenda: '',
      clienteAssociado: '',
      funcionario: '',
      maquina: ['', Validators.required],
      trocaJaEfetuada: false,
      acessorios: '',
      acessorioList: [null, Validators.required],
      entradaAssistenciaDocumentoList: [],
      descricao: ''
    });

    this.errors = [];

    this.loadCombos();

    if (this.data.id) {

      this.isNew = false;
      this.service.getEntradaAssistencia(this.data.id)
        .subscribe(testi => {
          this.teste = testi;
          this.populateForm(this.teste);
        });

      // this.service.getEntradaAssistencia(this.data.id).subscribe((data: any) => this.teste= data,
      //   error => () => {
      //     //this.toasterService.pop('error', 'Damn', 'Something went wrong...');
      //   },
      //   () => {
      //    // this.populateForm(this.entradaAssistencia);
      //   });
    }
    else {
      this.isNew = true;
    }

    this.setValidacaoPessoaFisicaJuridica();
  }

  setValidacaoPessoaFisicaJuridica() {
    const tipoPessoa = this.formEntradaAssistencia.get('tipoPessoa');
    const pessoaFisicaControl = this.formEntradaAssistencia.get('pessoaFisica');
    const pessoaJuridicaControl = this.formEntradaAssistencia.get('pessoaJuridica');

    if (this.HasPessoaFisica) {
      pessoaFisicaControl.setValidators([Validators.required]);      
      pessoaJuridicaControl.setValidators(null);
    } else {
      pessoaFisicaControl.setValidators(null);
      pessoaJuridicaControl.setValidators([Validators.required]);
    }

    pessoaFisicaControl.updateValueAndValidity();
    pessoaJuridicaControl.updateValueAndValidity();    
  }

  loadCombos() {
    this.pessoaFisicaService.populateCombo();
    this.pessoaJuridicaService.populateCombo();
    this.clienteAssociadoService.populateCombo();
    this.comprovanteCompraService.populateCombo();
    this.entreguePorService.populateCombo();
    this.funcionarioService.populateCombo();
    this.maquinaService.populateCombo();
    this.acessorioService.populateCombo();
  }

  populateForm(entrada) {
    //this.formEntradaAssistencia.setValue(entrada);
    this.entradaAssistenciaDocumentoList = entrada.entradaAssistenciaDocumentoList;

    this.formEntradaAssistencia.patchValue({
      funcionario: entrada.funcionario,
      id: entrada.id,
      maquina: entrada.maquina,
      entreguePor: entrada.entreguePor,
      dataEntrada: this.formataData(entrada.dataEntrada),
      comprovanteCompra: entrada.comprovanteCompra,
      numeroComprovanteCompra: entrada.numeroComprovanteCompra,
      numeroRemessa: entrada.numeroRemessa,
      codigoRastreio: entrada.codigoRastreio,
      trocaJaEfetuada: entrada.trocaJaEfetuada,
      numeroProtocoloTroca: entrada.numeroProtocoloTroca,
      numeroNF: entrada.numeroNF,
      numeroSerie: entrada.numeroSerie,
      pessoaFisica: entrada.pessoaFisica,
      pessoaJuridica: entrada.pessoaJuridica,
      ns: entrada.ns,
      revenda: entrada.revenda,
      clienteAssociado: entrada.clienteAssociado,
      tipoPessoa: entrada.tipoPessoa,
      acessorios: entrada.acessorios,
      acessorioList: entrada.acessorioList,
      descricao: entrada.descricao,
      entradaAssistenciaDocumentoList: entrada.entradaAssistenciaDocumentoList
    });

    if (entrada.pessoaFisica != null) {
      this.HasPessoaFisica = true;
    }
    else if (entrada.pessoaJuridica != null) {
      this.HasPessoaFisica = false;
    }

    if (!this.acessoBotoes)
      this.formEntradaAssistencia.disable();
  }

  formataData(data: string) {
    let now = new Date(data);
    let year = "" + now.getFullYear();
    let month = "" + (now.getMonth() + 1); if (month.length == 1) { month = "0" + month; }
    let day = "" + now.getDate(); if (day.length == 1) { day = "0" + day; }
    let hour = "" + now.getHours(); if (hour.length == 1) { hour = "0" + hour; }
    let minute = "" + now.getMinutes(); if (minute.length == 1) { minute = "0" + minute; }
    let second = "" + now.getSeconds(); if (second.length == 1) { second = "0" + second; }
    return year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
  }

  setradio(e: string): void {
    this.isPessoaFisicaJuridica(e);

    this.setValidacaoPessoaFisicaJuridica();
  }

  isPessoaFisicaJuridica(name: string): void {
    this.HasPessoaFisica = name === 'Fisica' ? true : false; // if current radio button is selected, return true, else return false  
  }

  onClear() {
    this.service.form.reset();
    this.service.initializeFormGroup();
  }

  onSubmit() {
    if (this.formEntradaAssistencia.valid) {

      this.errors = [];

      if (this.formEntradaAssistencia.value.id) {
        // Update product
        this.service.updateEntradaAssistencia(this.formEntradaAssistencia.value)
          .subscribe(entradaAssistencia => { this.entradaAssistencia = this.formEntradaAssistencia.value },
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

        //this.formEntradaAssistencia.value.acessorioList = this.formEntradaAssistencia.get('acessorioList');


        this.service.addEntradaAssistencia(this.formEntradaAssistencia.value)
          .subscribe(entradaAssistencia => { this.entradaAssistencia = this.formEntradaAssistencia.value },
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
    this.isNew = false;
    this.onClose();
  }

  onClose() {

    if (this.data !== null && this.data.id !== null) {
      this.service.checkDocumentoDirectory(this.data.id)
        .subscribe(result => {

          if (result > 0) {
            this.dialogService.openConfirmDialog('Você tem tem documentos para salvar, deseja fechar mesmo assim?')
              .afterClosed().subscribe(res => {
                if (res) {
                  this.service.deleteDocumentoFromDirectory(this.data.id).subscribe(result => {

                    this.service.form.reset();
                    this.service.initializeFormGroup();
                    this.dialogRef.close();

                  });
                }
              });
          } else {
            this.service.form.reset();
            this.service.initializeFormGroup();
            this.dialogRef.close();
          }
        });
    } else {
      this.service.form.reset();
      this.service.initializeFormGroup();
      this.dialogRef.close();
    }
  }

  goBack(): void {
    this.location.back();
  }

  onNotify(id: number) {
    var element = this.entradaAssistenciaDocumentoList.find(x => x.id === id);
    var index = this.entradaAssistenciaDocumentoList.indexOf(element);

    this.entradaAssistenciaDocumentoList.splice(index, 1);
  }


  //   onClickDescricao(row){
  //     //this.service.populateForm(row);
  //     const dialogConfig = new MatDialogConfig();
  //     dialogConfig.disableClose = true;
  //     dialogConfig.autoFocus = true;
  //     dialogConfig.width = "850px";
  //     dialogConfig.height= "90%"; 
  //     dialogConfig.panelClass = "dialogCustom"    

  //     let dialogRef = this.dialog.open(EntradaAssistenciaDescricao, {
  //     disableClose: true,
  //     autoFocus: true,
  //     width: "850px",
  //     height:"90%",
  //     panelClass: "dialogCustom",
  //     data: {
  //       id: row.id,
  //       acessoBotoes: true
  //     }
  //     });
  //     dialogRef.afterClosed().subscribe(result => {
  //       this.getEntradaAssistenciasOnEdit();
  //     });

  //  }
}
