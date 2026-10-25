import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { IProblema } from '../problema/problema';


const API_URL = environment.apiUrl + 'Problema/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class ProblemaService {
  problemaList: IProblema[];

  constructor(private http: HttpClient) {
    this.getProblemas().subscribe(  
      list => {
          this.problemaList = list.map(item => {
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

  getProblemas(): Observable<IProblema[]>{
    return this.http.get<IProblema[]>(API_URL);
  }

  getProblema(id: number): Observable<IProblema> {
    return this.http.get<IProblema>(API_URL + id.toString());
  }

  addProblema(entity: IProblema): Observable<IProblema> {    
    return this.http.post<IProblema>(API_URL, entity, httpOptions);
  }

  updateProblema(entity: IProblema): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteProblema(id: number): Observable<IProblema> {    
    return this.http.delete<IProblema>(API_URL + id, httpOptions);     
  }

  populateForm(problema) {
    this.form.setValue(problema);
  }
}