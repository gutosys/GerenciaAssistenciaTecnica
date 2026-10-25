import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl + 'CorCombo/';

@Injectable({
  providedIn: 'root'
})
export class CorService {
  corList: ICor[];
  
  constructor(private http: HttpClient) {
    this.getCores().subscribe(  
      list => {
          this.corList = list.map(item => {
            return {
              id: item.id,
              descricao: item.descricao,
              colorHex: item.colorHex           
            };
          });
        });

  }   

  getCores() {    
    return this.http.get<ICor[]>(API_URL);    
  }  
}
