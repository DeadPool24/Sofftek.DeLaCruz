import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment'; 
import { HttpClient } from '@angular/common/http';
import { ArticuloModel } from '../Model/ArticuloModel'; 

@Injectable({
  providedIn: 'root',
})
export class ArticuloService {
  private env = environment;
  protected api: string;

  constructor(private http: HttpClient) {
    this.api = `${environment.API}/api`;
  }

  postArticulo(tarea : ArticuloModel) {
    return this.http.post(this.api + `/Articulos/guardararticulo`,tarea);
  }

  getArticulos() {
    return this.http.get(this.api + `/Articulos/listararticulos`);
  }
  
}
