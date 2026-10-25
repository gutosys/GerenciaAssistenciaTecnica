import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { IPessoaFisica } from '../pessoa-fisica/pessoa-fisica';
import { Observable } from 'rxjs';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';

const API_URL = environment.apiUrl + 'PessoaFisica/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class PessoaFisicaService {
  pessoaFisicaList: IPessoaFisica[];

  constructor(private http: HttpClient) { 
    this.getPessoaFisicas().subscribe(  
      list => {
          this.pessoaFisicaList = list.map(item => {
            return {
              id: item.id,
              nome: item.nome ,
              sobrenome: item.sobrenome,
              cpf: item.cpf,
              rg: item.rg,
              email: item.email,
              telefone: item.telefone,
              celular: item.celular,
              rua: item.rua,
              bairro: item.bairro,
              numero: item.numero,
              cep: item.cep,
              cidadeId: item.cidadeId,
              estadoId: item.estadoId,
              clienteId: item.clienteId              
            };
          });
        });
  }

  form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    nome: new UntypedFormControl('', Validators.required),
    sobrenome: new UntypedFormControl('', Validators.required),
    cpf: new UntypedFormControl('', Validators.required),
    rg: new UntypedFormControl(''),    
    email: new UntypedFormControl('', [Validators.email, Validators.required]),
    telefone: new UntypedFormControl(''),
    celular: new UntypedFormControl(''),
    rua: new UntypedFormControl(''),
    bairro: new UntypedFormControl(''),
    numero: new UntypedFormControl(''),
    cep: new UntypedFormControl(''),
    cidadeId: new UntypedFormControl(''),
    estadoId: new UntypedFormControl(''),
    clienteId: new UntypedFormControl('')
  });

  initializeFormGroup(){
    this.form.setValue({
      id: null,
      nome: '',
      sobrenome: '',
      cpf: '',
      rg: '',
      email: '',
      telefone: '',
      celular: '',
      rua: '',
      bairro: '',
      numero: '',
      cep: '',
      cidadeId: null,
      estadoId: null,
      clienteId: null
    });
  }

  getPessoaFisicas(): Observable<IPessoaFisica[]>{
    return this.http.get<IPessoaFisica[]>(API_URL);
  }

  getPessoaFisica(id: number): Observable<IPessoaFisica> {
    return this.http.get<IPessoaFisica>(API_URL + id.toString());
  }

  addPessoaFisica(entity: IPessoaFisica): Observable<IPessoaFisica> {    
    return this.http.post<IPessoaFisica>(API_URL, entity, httpOptions);
  }

  updatePessoaFisica(entity: IPessoaFisica): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deletePessoaFisica(id: number): Observable<IPessoaFisica> {    
    return this.http.delete<IPessoaFisica>(API_URL + id, httpOptions);     
  }

  populateForm(pessoaFisica) {
    this.form.setValue(pessoaFisica);
  }

  populateCombo(){
    this.getPessoaFisicas().subscribe(  
      list => {
          this.pessoaFisicaList = list.map(item => {
            return {
              id: item.id,
              nome: item.nome ,
              sobrenome: item.sobrenome,
              cpf: item.cpf,
              rg: item.rg,
              email: item.email,
              telefone: item.telefone,
              celular: item.celular,
              rua: item.rua,
              bairro: item.bairro,
              numero: item.numero,
              cep: item.cep,
              cidadeId: item.cidadeId,
              estadoId: item.estadoId,
              clienteId: item.clienteId              
            };
          });
        });
  }
}
