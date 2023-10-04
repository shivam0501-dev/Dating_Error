import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService implements OnInit {
baseUrl="http://localhost:5019/api/"

private CurrentUserSource=new BehaviorSubject<User | null>(null);
currentUser$=this.CurrentUserSource.asObservable();
  constructor(private _http:HttpClient) { }

  ngOnInit(): void {
  }

  login(model:any){
    return this._http.post<User>(this.baseUrl+"Account/Login",model).pipe(
      map((response:User)=>{
        const user=response;
        if(user){
          this.setCurrentUser(user);
        }
      })
    )
  }

  register(model:any)
  {
    return this._http.post<User>(this.baseUrl+"Account/register",model).pipe(
      map((user)=>{
        if(user){
          this.setCurrentUser(user);
        }
        return user
      })
    )
  }
  setCurrentUser(user:User){
    localStorage.setItem('user', JSON.stringify(user));
    this.CurrentUserSource.next(user);
  }

  logout(){
    localStorage.removeItem("user");
    this.CurrentUserSource.next(null);
  }
}
