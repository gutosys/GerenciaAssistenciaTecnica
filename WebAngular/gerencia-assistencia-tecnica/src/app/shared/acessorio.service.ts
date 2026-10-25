import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { IAcessorio } from '../acessorio/acessorio';
import { Observable } from 'rxjs';
import { UntypedFormControl, Validators, UntypedFormGroup } from '@angular/forms';

const API_URL = environment.apiUrl + 'Acessorio/';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AcessorioService {
  acessorioList: IAcessorio[];

  constructor(private http: HttpClient) {
    this.getAcessorios().subscribe(  
      list => {
          this.acessorioList = list.map(item => {
            return {
              id: item.id,
              descricao: item.descricao           
            };
          });
        });
  }

  form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    descricao: new UntypedFormControl('', Validators.required)
  });

  initializeFormGroup(){
    this.form.setValue({
      id: null,
      descricao: ''
    });
  }

  getAcessorios(): Observable<IAcessorio[]>{
    return this.http.get<IAcessorio[]>(API_URL);
  }

  getAcessorio(id: number): Observable<IAcessorio> {
    return this.http.get<IAcessorio>(API_URL + id.toString());
  }

  addAcessorio(entity: IAcessorio): Observable<IAcessorio> {    
    return this.http.post<IAcessorio>(API_URL, entity, httpOptions);
  }

  updateAcessorio(entity: IAcessorio): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteAcessorio(id: number): Observable<IAcessorio> {    
    return this.http.delete<IAcessorio>(API_URL + id, httpOptions);     
  }

  populateForm(acessorio) {
    this.form.setValue(acessorio);
  }
  
  populateCombo(){
    this.getAcessorios().subscribe(  
      list => {
          this.acessorioList = list.map(item => {
            return {
              id: item.id,
              descricao: item.descricao           
            };
          });
        });
  }
}
