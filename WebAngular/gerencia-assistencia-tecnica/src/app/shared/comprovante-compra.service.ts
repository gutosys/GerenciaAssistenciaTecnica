import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl + 'ComprovanteCompra/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class ComprovanteCompraService {
  comprovanteCompraList: IComprovanteCompra[];

  constructor(private http: HttpClient) { 
    this.getComprovanteCompras().subscribe(  
      list => {
          this.comprovanteCompraList = list.map(item => {
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

  getComprovanteCompras(): Observable<IComprovanteCompra[]>{
    return this.http.get<IComprovanteCompra[]>(API_URL);
  }

  getComprovanteCompra(id: number): Observable<IComprovanteCompra> {
    return this.http.get<IComprovanteCompra>(API_URL + id.toString());
  }

  addComprovanteCompra(entity: IComprovanteCompra): Observable<IComprovanteCompra> {    
    return this.http.post<IComprovanteCompra>(API_URL, entity, httpOptions);
  }

  updateComprovanteCompra(entity: IComprovanteCompra): Observable<any> {
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteComprovanteCompra(id: number): Observable<IComprovanteCompra> {    
    return this.http.delete<IComprovanteCompra>(API_URL + id, httpOptions);     
  }

  populateForm(comprovanteCompra) {
    // etiqueta.colorHex = '';
    this.form.setValue(comprovanteCompra);

    //  this.form.patchValue({
    //    id: etiqueta.id,
    //    descricao: etiqueta.descricao,
    //    corId: etiqueta.corId
    //  });
  }

  populateCombo(){
    this.getComprovanteCompras().subscribe(  
      list => {
          this.comprovanteCompraList = list.map(item => {
            return {
              id: item.id,
              descricao: item.descricao              
            };
          });
        });
  }
}
