import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UntypedFormGroup, UntypedFormControl, Validators, FormBuilder } from '@angular/forms';
import { IEntradaAssistencia, IEntradaAssistenciaListPage } from '../assistencia-tecnica/entrada-assistencia';

const API_URL = environment.apiUrl + 'EntradaAssistenciaTecnica/';
const API_URL_UPLOAD = environment.apiUrl + 'Upload/';
const API_URL_UPLOAD_DIRECTORY = environment.apiUrl + 'UploadDeleteFromDirectory/';
const API_URL_UPLOADCheckDocumento = environment.apiUrl + 'UploadCheckDocumento/';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class EntradaAssistenciaService {
  entradaAssistenciaList: IEntradaAssistencia[];
  entradaAssistenciaListPage: IEntradaAssistenciaListPage[];  

  constructor(private http: HttpClient) {
    this.getEntradaAssistencias().subscribe(
      list => {
        this.entradaAssistenciaListPage = list.map(item => {
          return {
            id: item.id,
            nome: item.nome,
            maquinaDesc: item.maquinaDesc,
            funcionarioDesc: item.funcionarioDesc
            // pessoaFisicaId: item.pessoaFisicaId,
            // pessoaJuridicaId: item.pessoaJuridicaId,
            // funcionarioId: item.funcionarioId,
            // numeroNF: item.numeroNF,
            // maquinaId: item.maquinaId,
            // numeroSerie: item.numeroSerie,
            // acessorioList: item.acessorioList
          };
        });
      });
  }

  form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    nome: new UntypedFormControl(''),
    entreguePorId: new UntypedFormControl(''),
    comprovanteCompraId: new UntypedFormControl(''),
    pessoaFisicaId: new UntypedFormControl(''),
    pessoaJuridicaId: new UntypedFormControl(''),
    clienteAssociadoId: new UntypedFormControl(''),
    codigoRastreio: new UntypedFormControl(''),
    funcionarioId: new UntypedFormControl(''),
    ns: new UntypedFormControl(''),
    numeroRemessa: new UntypedFormControl(''), 
    dataEntrada: new UntypedFormControl(''),
    numeroProtocoloTroca: new UntypedFormControl(''),
    trocaJaEfetuada: new UntypedFormControl(false),
    numeroComprovanteCompra: new UntypedFormControl(''),     
    numeroNF: new UntypedFormControl(''),     
    maquinaId: new UntypedFormControl(''),
    numeroSerie: new UntypedFormControl(''),
    acessorioList: new UntypedFormControl(''),
    
  });

  initializeFormGroup(){
    this.form.setValue({
      id: null,
      nome: '',
      pessoaFisicaId: null,
      pessoaJuridicaId: null,
      comprovanteCompraId: null,
      entreguePorId: null,
      clienteAssociadoId: null,
      funcionarioId: null,
      numeroProtocoloTroca: '',
      ns: '',
      codigoRastreio: '',
      numeroRemessa: null,
      trocaJaEfetuada: false,
      dataEntrada: null,
      numeroNF: '',    
      numeroComprovanteCompra: '',
      maquinaId: null,
      numeroSerie: '',
      acessorioList: []    
    });
  }

  getEntradaAssistencias(): Observable<IEntradaAssistencia[]>{
    return this.http.get<IEntradaAssistencia[]>(API_URL);
  }

  getBoardEntradas(): Observable<IEntradaAssistencia[]> {
    return this.http.get<IEntradaAssistencia[]>(API_URL + 'board');
  }

  updateEntradaAssistenciaStatus(id: number, statusId: number): Observable<void> {
    return this.http.put<void>(API_URL + id + '/status', statusId, httpOptions);
  }

  getEntradaAssistencia(id: number): Observable<IEntradaAssistencia> {
    return this.http.get<IEntradaAssistencia>(API_URL + id.toString());
  }

  addEntradaAssistencia(entity: IEntradaAssistencia): Observable<IEntradaAssistencia> {    
    return this.http.post<IEntradaAssistencia>(API_URL, entity, httpOptions);
  }

  updateEntradaAssistencia(entity: IEntradaAssistencia): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteEntradaAssistencia(id: number): Observable<IEntradaAssistencia> {    
    return this.http.delete<IEntradaAssistencia>(API_URL + id, httpOptions);     
  }

  deleteDocumento(id: number) {    
    return this.http.delete(API_URL_UPLOAD + id, httpOptions);     
  }  

  deleteDocumentoFromDirectory(id: number) {    
    return this.http.delete(API_URL_UPLOAD_DIRECTORY + id, httpOptions);     
  }  

  checkDocumentoDirectory(id: number): Observable<number>{
    return this.http.get<number>(API_URL_UPLOADCheckDocumento + id.toString());
  }

  populateForm(entrada) {
    this.form.setValue(entrada);
  }
}