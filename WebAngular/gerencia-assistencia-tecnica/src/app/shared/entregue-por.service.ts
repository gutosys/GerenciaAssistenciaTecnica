import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl + 'EntreguePor/';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class EntreguePorService {
  entreguePorList: IEntreguePor[];

  constructor(private http: HttpClient) { 
    this.getEntreguePorList().subscribe(  
      list => {
          this.entreguePorList = list.map(item => {
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

  getEntreguePorList(): Observable<IEntreguePor[]>{
    return this.http.get<IEntreguePor[]>(API_URL);
  }

  getEntreguePor(id: number): Observable<IEntreguePor> {
    return this.http.get<IEntreguePor>(API_URL + id.toString());
  }

  addEntreguePor(entity: IEntreguePor): Observable<IEntreguePor> {    
    return this.http.post<IEntreguePor>(API_URL, entity, httpOptions);
  }

  updateEntreguePor(entity: IEntreguePor): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteEntreguePor(id: number): Observable<IEntreguePor> {    
    return this.http.delete<IEntreguePor>(API_URL + id, httpOptions);     
  }

  populateForm(entreguePor) {
    // etiqueta.colorHex = '';
    this.form.setValue(entreguePor);

    //  this.form.patchValue({
    //    id: etiqueta.id,
    //    descricao: etiqueta.descricao,
    //    corId: etiqueta.corId
    //  });
  }

  populateCombo(){
    this.getEntreguePorList().subscribe(  
      list => {
          this.entreguePorList = list.map(item => {
            return {
              id: item.id,
              descricao: item.descricao              
            };
          });
        });
  }
}
