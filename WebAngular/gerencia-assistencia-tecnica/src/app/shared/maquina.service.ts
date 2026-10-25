import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UntypedFormControl, Validators, UntypedFormGroup } from '@angular/forms';
import { IMaquina } from '../maquina/maquina';

const API_URL = environment.apiUrl + 'Maquina/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class  MaquinaService{
  maquinaList: IMaquina[];

  constructor(private http: HttpClient) {
    this.getMaquinas().subscribe(
      list => {
        this.maquinaList = list.map(item => {
          return {
            id: item.id,
            descricao: item.descricao,
            modelo: item.modelo
          };
        });
      });
  }

  form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    descricao: new UntypedFormControl('', Validators.required),
    modelo: new UntypedFormControl('', Validators.required)
  });

  initializeFormGroup() {
    this.form.setValue({
      id: null,
      descricao: '',
      modelo: ''
    });
  }

  getMaquinas(): Observable<IMaquina[]> {
    return this.http.get<IMaquina[]>(API_URL);
  }

  getMaquina(id: number): Observable<IMaquina> {
    return this.http.get<IMaquina>(API_URL + id.toString());
  }

  addMaquina(entity: IMaquina): Observable<IMaquina> {    
    return this.http.post<IMaquina>(API_URL, entity, httpOptions);
  }

  updateMaquina(entity: IMaquina): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteMaquina(id: number): Observable<IMaquina> {
    return this.http.delete<IMaquina>(API_URL + id, httpOptions);
  }

  populateForm(maquina) {
    this.form.setValue(maquina);
  }

  populateCombo(){
    this.getMaquinas().subscribe(
      list => {
        this.maquinaList = list.map(item => {
          return {
            id: item.id,
            descricao: item.descricao,
            modelo: item.modelo
          };
        });
      });
  }

}
