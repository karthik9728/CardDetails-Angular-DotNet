import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Card } from 'src/app/Models/card.model'

@Injectable({
  providedIn: 'root'
})
export class CardsService {

  baseUrl = 'https://localhost:7208/api/card'

  constructor(private http:HttpClient) { }

  //Get ALL Cards Details
  getAllCards():Observable<Card[]>{
    return this.http.get<Card[]>(this.baseUrl);
  }

  addCard(card:Card):Observable<Card>{
    card.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Card>(this.baseUrl,card);
  }

  updateCard(card:Card):Observable<Card>{
    return this.http.put<Card>(this.baseUrl +'/'+ card.id,card);
  }

  deleteCard(id:string):Observable<Card>{
    return this.http.delete<Card>(this.baseUrl +'/'+ id )
  }
}
