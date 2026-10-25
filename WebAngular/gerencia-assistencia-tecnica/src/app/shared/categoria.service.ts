import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ICategoria } from '../categoria/categoria';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';


const API_URL = environment.apiUrl + 'Categoria/';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class CategoriaService {
  categoriaList: ICategoria[];

  constructor(private http: HttpClient) {
    this.getCategorias().subscribe(  
      list => {
          this.categoriaList = list.map(item => {
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

  getCategorias(): Observable<ICategoria[]>{
    return this.http.get<ICategoria[]>(API_URL);
  }

  getCategoria(id: number): Observable<ICategoria> {
    return this.http.get<ICategoria>(API_URL + id.toString());
  }

  addCategoria(entity: ICategoria): Observable<ICategoria> {    
    return this.http.post<ICategoria>(API_URL, entity, httpOptions);
  }

  updateCategoria(entity: ICategoria): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteCategoria(id: number): Observable<ICategoria> {    
    return this.http.delete<ICategoria>(API_URL + id, httpOptions);     
  }

  populateForm(categoria) {
    this.form.setValue(categoria);
  }
}
