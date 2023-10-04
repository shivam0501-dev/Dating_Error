import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {
  baseUrl="http://localhost:5019/api/"
  validationErros:string[]=[];
  constructor(private _http:HttpClient){}

  ngOnInit(): void {
    
  }

  get404Error(){
    this._http.get(this.baseUrl+'Buggy/not-found').subscribe({
      next:response=>console.log(response),
      error:error=>console.log(error)
    })
  }

  get400Error(){
    this._http.get(this.baseUrl+'Buggy/bad-request').subscribe({
      next:response=>console.log(response),
      error:error=>console.log(error)
    })
  }

  get500Error(){
    this._http.get(this.baseUrl+'Buggy/server-error').subscribe({
      next:response=>console.log(response),
      error:error=>console.log(error)
    })
  }

  get401Error(){
    this._http.get(this.baseUrl+'Buggy/auth').subscribe({
      next:response=>console.log(response),
      error:error=>console.log(error)
    })
  }
  get401ValidationError(){
    this._http.post(this.baseUrl+'Account/register',{}).subscribe({
      next:response=>console.log(response),
      error:error=>{
        console.log(error)
        this.validationErros=error
      }
    })
  }
}
