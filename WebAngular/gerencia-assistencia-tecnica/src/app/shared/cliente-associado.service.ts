import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';

const API_URL = environment.apiUrl + 'ClienteAssociado/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})


export class ClienteAssociadoService {
  clienteAssociadoList: IClienteAssociado[];
  
  constructor(private http: HttpClient) {
    this.getClientesAssociados().subscribe(  
      list => {
          this.clienteAssociadoList = list.map(item => {
            return {
              id: item.id,
              nome: item.nome,
              telefone: item.telefone,
              pessoaJuridicaId: item.pessoaJuridicaId,
              pessoaJuridicaDes: item.pessoaJuridicaDes
            };
          });
        });
   }

   form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    nome: new UntypedFormControl('', Validators.required),
    telefone: new UntypedFormControl(''),
    pessoaJuridicaId: new UntypedFormControl('', Validators.required)
  });

   initializeFormGroup() {
    this.form.setValue({
      id: null,
      nome: '',
      telefone: '',
      pessoaJuridicaId: null      
    });
  }

   getClientesAssociados() {    
    return this.http.get<IClienteAssociado[]>(API_URL);
  }

  getClienteAssociado(id: number): Observable<IClienteAssociado> {
    return this.http.get<IClienteAssociado>(API_URL + id.toString());
  }

  addClienteAssociado(entity: IClienteAssociado): Observable<IClienteAssociado> {    
    return this.http.post<IClienteAssociado>(API_URL, entity, httpOptions);
  }

  updateClienteAssociado(entity: IClienteAssociado): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteClienteAssociado(id: number): Observable<IClienteAssociado> {
    return this.http.delete<IClienteAssociado>(API_URL + id, httpOptions);
  }

  populateForm(clienteAssociado) {
    this.form.patchValue({
      id: clienteAssociado.id,
      nome: clienteAssociado.nome,
      telefone: clienteAssociado.telefone,
      pessoaJuridicaId: clienteAssociado.pessoaJuridicaId
    });
  }

  populateCombo(){
    this.getClientesAssociados().subscribe(  
      list => {
          this.clienteAssociadoList = list.map(item => {
            return {
              id: item.id,
              nome: item.nome,
              telefone: item.telefone,
              pessoaJuridicaId: item.pessoaJuridicaId,
              pessoaJuridicaDes: item.pessoaJuridicaDes
            };
          });
        });
  }
  
}
