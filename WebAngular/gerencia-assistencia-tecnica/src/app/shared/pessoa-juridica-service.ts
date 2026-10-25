import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { IPessoaJuridica } from '../pessoa-juridica/pessoa-juridica';
import { Observable } from 'rxjs';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';

const API_URL = environment.apiUrl + 'PessoaJuridica/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class PessoaJuridicaService {
  pessoaJuridicaList: IPessoaJuridica[];

  constructor(private http: HttpClient) { 
    this.getPessoaJuridicas().subscribe(  
      list => {
          this.pessoaJuridicaList = list.map(item => {
            return {
              id: item.id,
              razaoSocial: item.razaoSocial,
              nomeFantasia: item.nomeFantasia,
              cnpj: item.cnpj,
              ie: item.ie,
              email: item.email,
              telefone: item.telefone,
              celular: item.celular,
              enderecoId: item.enderecoId,
              rua: item.rua,
              bairro: item.bairro,
              numero: item.numero,
              cep: item.cep,
              cidadeId: item.cidadeId,
              estadoId: item.estadoId,
              clienteId: item.clienteId,
              regimeTributarioId: item.regimeTributarioId
            };
          });
        });
  }

  form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    razaoSocial: new UntypedFormControl('', Validators.required),
    nomeFantasia: new UntypedFormControl('', Validators.required),
    cnpj: new UntypedFormControl('', Validators.required),
    ie: new UntypedFormControl(''),   
    email: new UntypedFormControl('',[Validators.email, Validators.required]),
    telefone: new UntypedFormControl('', Validators.required),
    celular: new UntypedFormControl(''),
    enderecoId: new UntypedFormControl(''),
    rua: new UntypedFormControl('', Validators.required),
    bairro: new UntypedFormControl('', Validators.required),
    numero: new UntypedFormControl('', Validators.required),
    cep: new UntypedFormControl('', Validators.required),
    cidadeId: new UntypedFormControl('', Validators.required),
    estadoId: new UntypedFormControl('', Validators.required),
    clienteId: new UntypedFormControl(''),    
    regimeTributarioId: new UntypedFormControl('', Validators.required)
  });

  initializeFormGroup(){
    this.form.setValue({
      id: null,
      razaoSocial: '',
      nomeFantasia: '',
      cnpj: '',
      ie: '',
      email: '',
      telefone: '',
      celular: '',
      enderecoId: null,
      rua: '',
      bairro: '',
      numero: '',
      cep: '',
      cidadeId: null,
      estadoId: null,
      clienteId: null,
      regimeTributarioId: null
    });
  }

    getPessoaJuridicas(): Observable<IPessoaJuridica[]>{
      return this.http.get<IPessoaJuridica[]>(API_URL);
    }
  
    getPessoaJuridica(id: number): Observable<IPessoaJuridica> {
      return this.http.get<IPessoaJuridica>(API_URL + id.toString());
    }
  
    addPessoaJuridica(entity: IPessoaJuridica): Observable<IPessoaJuridica> {      
      return this.http.post<IPessoaJuridica>(API_URL, entity, httpOptions);
    }
  
    updatePessoaJuridica(entity: IPessoaJuridica): Observable<any> {
      return this.http.put(API_URL + entity.id, entity, httpOptions);
    }
  
    deletePessoaJuridica(id: number): Observable<IPessoaJuridica> {    
      return this.http.delete<IPessoaJuridica>(API_URL + id, httpOptions);     
    }
  
    populateForm(pessoaJuridica) {
      this.form.setValue(pessoaJuridica);
    }

    populateCombo(){
      this.getPessoaJuridicas().subscribe(  
        list => {
            this.pessoaJuridicaList = list.map(item => {
              return {
                id: item.id,
                razaoSocial: item.razaoSocial,
                nomeFantasia: item.nomeFantasia,
                cnpj: item.cnpj,
                ie: item.ie,
                email: item.email,
                telefone: item.telefone,
                celular: item.celular,
                enderecoId: item.enderecoId,
                rua: item.rua,
                bairro: item.bairro,
                numero: item.numero,
                cep: item.cep,
                cidadeId: item.cidadeId,
                estadoId: item.estadoId,
                clienteId: item.clienteId,
                regimeTributarioId: item.regimeTributarioId
              };
            });
          });
    }
}
