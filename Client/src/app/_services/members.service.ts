import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl="http://localhost:5019/api/";

  constructor(private _http:HttpClient) { }

  getMembers(){
    return this._http.get<Member[]>(this.baseUrl+'users')
  }
  getMember(username:string){
    return this._http.get<Member>(this.baseUrl+'users/'+ username)
  }
  
// getHttpOptions(){
//   const userString=localStorage.getItem('user');
//   debugger
//   if(!userString)return;
//   const user=JSON.parse(userString);
//   return{
//     headers:new HttpHeaders({
//       Authorization: 'Bearer ' + user.token
//     })
//   }};
}
  

