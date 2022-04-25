import { Component, OnInit } from '@angular/core';
import { CardsService } from './Service/cards.service';
import { Card } from './Models/card.model'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'cards';
  cards:Card[] = [];

  card: Card ={
    id:'',
    cardHolderName:'',
    cardNumber:'',
    cvc:'',
    expiryMonth:'',
    expiryYear:''
  }

  constructor(private cardsService: CardsService){

  }

  ngOnInit(): void {
    this.getAllCards();
  }

  getAllCards(){
    this.cardsService.getAllCards().subscribe(
      responce => {
        this.cards = responce;
        //console.log(this.cards);
      }
    );
  }

  onSubmit(){

    if(this.card.id ===''){
      this.cardsService.addCard(this.card).subscribe(
        responce =>{
          this.card = {
            id:'',
            cardHolderName:'',
            cardNumber:'',
            cvc:'',
            expiryMonth:'',
            expiryYear:''
          }
          //console.log(responce);
          this.getAllCards();
        } 
      ); 
    }else{
       this.updateCard(this.card);
    }
  }

  deleteCard(id:string){
    this.cardsService.deleteCard(id).subscribe(
      responce=>{
        //console.log(responce);
        this.getAllCards();
      }
    );
  }

  populateForm(card:Card){
    this.card = card
  }

  updateCard(card:Card){
    this.cardsService.updateCard(card).subscribe(
      responce=>{
        this.getAllCards();
        this.card = {
          id:'',
          cardHolderName:'',
          cardNumber:'',
          cvc:'',
          expiryMonth:'',
          expiryYear:''
        }
      }
    );
  }
}
