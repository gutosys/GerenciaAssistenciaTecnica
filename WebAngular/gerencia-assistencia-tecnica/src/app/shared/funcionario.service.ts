import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';
import { IFuncionario } from '../funcionario/funcionario';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl + 'Funcionario/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class FuncionarioService {
  funcionarioList: IFuncionario[];

  constructor(private http: HttpClient) { 
    this.getFuncionarios().subscribe(  
      list => {
          this.funcionarioList = list.map(item => {
            return {
              id: item.id,
              nome: item.nome,
              sobrenome: item.sobrenome,
              cpf: item.cpf,
              rg: item.rg,
              email: item.email,
              telefone: item.telefone,
              celular: item.celular
            };
          });
        });
  }

  form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    nome: new UntypedFormControl('', Validators.required),
    sobrenome: new UntypedFormControl('', Validators.required),
    cpf: new UntypedFormControl('', Validators.maxLength(11)),
    rg: new UntypedFormControl(''),    
    email: new UntypedFormControl('', Validators.email),
    telefone: new UntypedFormControl(''),
    celular: new UntypedFormControl('')    
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
      celular: ''      
    });
  }

  getFuncionarios(): Observable<IFuncionario[]>{
    return this.http.get<IFuncionario[]>(API_URL);
  }

  getFuncionario(id: number): Observable<IFuncionario> {
    return this.http.get<IFuncionario>(API_URL + id.toString());
  }

  addFuncionario(entity: IFuncionario): Observable<IFuncionario> {    
    return this.http.post<IFuncionario>(API_URL, entity, httpOptions);
  }

  updateFuncionario(entity: IFuncionario): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteFuncionario(id: number): Observable<IFuncionario> {    
    return this.http.delete<IFuncionario>(API_URL + id, httpOptions);     
  }

  populateForm(funcionario) {
    this.form.setValue(funcionario);
  }

  populateCombo(){
    this.getFuncionarios().subscribe(  
      list => {
          this.funcionarioList = list.map(item => {
            return {
              id: item.id,
              nome: item.nome,
              sobrenome: item.sobrenome,
              cpf: item.cpf,
              rg: item.rg,
              email: item.email,
              telefone: item.telefone,
              celular: item.celular
            };
          });
        });
  }
}
