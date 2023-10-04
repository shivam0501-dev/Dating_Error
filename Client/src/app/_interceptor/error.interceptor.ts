import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private _router:Router,private _toast:ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error:HttpErrorResponse)=>{
        if(error){
          switch(error.status){
            case 400:
              if(error.error.errors){
                const ModelStateError=[];
                for(const key in error.error.errors){
                  if(error.error.errors[key]){
                    ModelStateError.push(error.error.errors[key])
                  }
                }
                throw ModelStateError.flat();
              }
              else{
                this._toast.error(error.error,error.status.toString())
              }
              break;
              case 401:
                this._toast.error("Unauthorised",error.status.toString())
                break;
              case 404:
                this._router.navigateByUrl('/not-found')
                break;
              case 500:
                const navigationExtras:NavigationExtras={state:{error:error.error}}
                this._router.navigateByUrl('/server-error',navigationExtras)
                break;
              default:
                this._toast.error('Something Unexpected went Wrong')
                console.log(error)
                break;
          }
        }
        throw error;
      })
    );
  }
}
