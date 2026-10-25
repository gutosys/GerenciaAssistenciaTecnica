import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl + 'CidadeCombo/';

@Injectable({
  providedIn: 'root'
})

export class CidadeService {
  cidadeList: ICidade[];

  constructor(private http: HttpClient) { }

  getCidades(estadoId: number) {
    return this.http.get<ICidade[]>(API_URL + estadoId.toString());
  }
}
