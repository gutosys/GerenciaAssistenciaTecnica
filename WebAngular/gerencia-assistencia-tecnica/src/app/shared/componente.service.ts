import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';

const API_URL = environment.apiUrl + 'Componente/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ComponenteService {
  componenteList: IComponente[];
  
  constructor(private http: HttpClient) { 
    this.getComponentes().subscribe(  
      list => {
          this.componenteList = list.map(item => {
            return {
              id: item.id,
              nome: item.nome,
              descricao: item.descricao,
              precoCompra: item.precoCompra,
              precoVenda: item.precoVenda,
              precoVendaAutorizada : item.precoVendaAutorizada
            };
          });
        });

  }

  form: UntypedFormGroup = new UntypedFormGroup({
    id: new UntypedFormControl(null),
    nome: new UntypedFormControl('', Validators.required),
    descricao: new UntypedFormControl(''),
    precoCompra: new UntypedFormControl('', Validators.required),
    precoVenda: new UntypedFormControl('', Validators.required),    
    precoVendaAutorizada: new UntypedFormControl('', Validators.required)    
  });

  initializeFormGroup(){
    this.form.setValue({
      id: null,
      nome: '',
      descricao: '',
      precoCompra: '',
      precoVenda: '',
      precoVendaAutorizada: ''      
    });
  }

  getComponentes(): Observable<IComponente[]>{
    return this.http.get<IComponente[]>(API_URL);
  } 

  getComponente(id: number): Observable<IComponente> {
    return this.http.get<IComponente>(API_URL + id.toString());
  }

  addComponente(entity: IComponente): Observable<IComponente> {
    entity.precoCompra = parseFloat(entity.precoCompra.toString().replace('R$', '').replace(',', '.'));
    entity.precoVenda = parseFloat(entity.precoVenda.toString().replace('R$', '').replace(',', '.'));
    entity.precoVendaAutorizada = parseFloat(entity.precoVendaAutorizada.toString().replace('R$', '').replace(',', '.'));
    return this.http.post<IComponente>(API_URL, entity, httpOptions);
  }

  updateComponente(entity: IComponente): Observable<any> {
    entity.precoCompra = parseFloat(entity.precoCompra.toString().replace('R$', '').replace(',', '.'));
    entity.precoVenda = parseFloat(entity.precoVenda.toString().replace('R$', '').replace(',', '.'));
    entity.precoVendaAutorizada = parseFloat(entity.precoVendaAutorizada.toString().replace('R$', '').replace(',', '.'));
    return this.http.put(API_URL + entity.id, entity, httpOptions);
  }

  deleteComponente(id: number): Observable<IComponente> {
    return this.http.delete<IComponente>(API_URL + id, httpOptions);     
  }

  populateForm(pessoaFisica) {
    this.form.setValue(pessoaFisica);
  }
}
