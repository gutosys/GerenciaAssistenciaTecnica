import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


const API_URL = environment.apiUrl + 'Estado/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class EstadoService {
  estadoList: IEstado[];

  constructor(private http: HttpClient) {     
    this.getEstados().subscribe(  
    list => {
        this.estadoList = list.map(item => {
          return {
            id: item.id,
            descricao: item.descricao           
          };
        });
      });
  }

  getEstados() {    
    return this.http.get<IEstado[]>(API_URL);
  }  
}

interface IEstado{
  id: number,
  descricao: string  
}