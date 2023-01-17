import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageServiceService {

  constructor() { }
  set(key: string, value: string){
    localStorage.setItem(key, value);
  }

  get(key: string){
    if(localStorage.getItem(key)){
      return {
        status: 200,
        message: "Session activa"
      }
    }else{
      return {
        status: 400,
        message: "Session inactiva"
      }
    }
  }

  remove(key: string){
    localStorage.removeItem(key);
  }
  
}
