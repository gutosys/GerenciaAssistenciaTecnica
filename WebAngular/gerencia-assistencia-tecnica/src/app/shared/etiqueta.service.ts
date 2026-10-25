import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl + 'Etiqueta/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class EtiquetaService {
  constructor(private http: HttpClient) { }

  form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    descricao: new UntypedFormControl('', Validators.required),
    corId: new UntypedFormControl('', Validators.required),
    corDes: new UntypedFormControl('')    
  });

  initializeFormGroup(){
    this.form.setValue({
      id: null,
      descricao: '',
      corId: '',      
      corDes: ''      
    });
  }

  getEtiquetas(): Observable<IEtiqueta[]>{
    return this.http.get<IEtiqueta[]>(API_URL);
  }

  getEtiqueta(id: number): Observable<IEtiqueta> {
    return this.http.get<IEtiqueta>(API_URL + id.toString());
  }

  addEtiqueta(entity: IEtiqueta): Observable<IEtiqueta> {    
    return this.http.post<IEtiqueta>(API_URL, entity, httpOptions);
  }

  updateEtiqueta(entity: IEtiqueta): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteEtiqueta(id: number): Observable<IEtiqueta> {    
    return this.http.delete<IEtiqueta>(API_URL + id, httpOptions);     
  }

  populateForm(etiqueta) {
    // etiqueta.colorHex = '';
    this.form.setValue(etiqueta);

    //  this.form.patchValue({
    //    id: etiqueta.id,
    //    descricao: etiqueta.descricao,
    //    corId: etiqueta.corId
    //  });



  }
}
