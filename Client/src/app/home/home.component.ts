
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent{
  registerMode=false;
  users:any;


  registerToggle(){
    this.registerMode=!this.registerMode
  }

  cancleRegisterMode(event:boolean){
    this.registerMode=event;
  }
}
