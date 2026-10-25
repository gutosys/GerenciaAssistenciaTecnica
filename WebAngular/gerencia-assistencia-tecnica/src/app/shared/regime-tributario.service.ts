import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRegimeTributario } from '../regime-tributario/regime-tributario';

const API_URL = environment.apiUrl + 'RegimeTributario/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class RegimeTributarioService {
  regimeTributarioList: IRegimeTributario[];

  constructor(private http: HttpClient) {
    this.getRegimeTributarios().subscribe(  
      list => {
          this.regimeTributarioList = list.map(item => {
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

  getRegimeTributarios(): Observable<IRegimeTributario[]>{
    return this.http.get<IRegimeTributario[]>(API_URL);
  }

  getRegimeTributario(id: number): Observable<IRegimeTributario> {
    return this.http.get<IRegimeTributario>(API_URL + id.toString());
  }

  addRegimeTributario(entity: IRegimeTributario): Observable<IRegimeTributario> {    
    return this.http.post<IRegimeTributario>(API_URL, entity, httpOptions);
  }

  updateRegimeTributario(entity: IRegimeTributario): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteRegimeTributario(id: number): Observable<IRegimeTributario> {    
    return this.http.delete<IRegimeTributario>(API_URL + id, httpOptions);     
  }

  populateForm(regimeTributario) {
    this.form.setValue(regimeTributario);
  }

  populateCombo(){
    this.getRegimeTributarios().subscribe(  
      list => {
          this.regimeTributarioList = list.map(item => {
            return {
              id: item.id,
              descricao: item.descricao           
            };
          });
        });
  }
}