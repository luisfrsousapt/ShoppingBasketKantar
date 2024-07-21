import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  addItem(key:any,value:any):void{
    if(value !== null && value !== undefined){
      localStorage.setItem(key,JSON.stringify(value))
    }
  }

  getItem(key:any):any{
    const obj = localStorage.getItem(key);
    return obj ? JSON.parse(obj):null;
  }

  removeItem(key:any):void{
    localStorage.removeItem(key);
  }
}
