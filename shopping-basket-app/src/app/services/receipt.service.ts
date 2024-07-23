import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Basket } from '../model/basket.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ReceiptService {

  constructor(private http: HttpClient) { }


    getReceipt(basket: Basket): Observable<Blob> {
      return this.http.post(`${environment.api_receipt_url}/`, basket, { responseType: 'blob' });
    }
}
