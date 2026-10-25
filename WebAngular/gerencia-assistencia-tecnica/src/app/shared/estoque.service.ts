import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl + 'Estoque/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class EstoqueService {

  constructor(private http: HttpClient) { }

  form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    componenteId: new UntypedFormControl(''),
    componenteDes: new UntypedFormControl(''),
    quantidade: new UntypedFormControl('', Validators.required),
    quantidadeMinima: new UntypedFormControl('', Validators.required)    
  });

  initializeFormGroup(){
    this.form.setValue({
      id: null,
      quantidade: '',
      quantidadeMinima: '',
      componenteId: null,
      componenteDes: ''
    });
  }

  getEstoques(): Observable<IEstoque[]>{
    return this.http.get<IEstoque[]>(API_URL);
  }

  getEstoque(id: number): Observable<IEstoque> {
    return this.http.get<IEstoque>(API_URL + id.toString());
  }

  addEstoque(entity: IEstoque): Observable<IEstoque> {    
    return this.http.post<IEstoque>(API_URL, entity, httpOptions);
  }

  updateEstoque(entity: IEstoque): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteEstoque(id: number): Observable<IEstoque> {    
    return this.http.delete<IEstoque>(API_URL + id, httpOptions);     
  }

  populateForm(estoque) {
    this.form.setValue(estoque);
  }
}