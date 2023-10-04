import { Injectable } from '@angular/core';
import { CanActivate} from '@angular/router';
import { Observable, map } from 'rxjs';
import { AccountService } from '../_services/account.service';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

 
  constructor(private _accountser:AccountService) {}

  canActivate(): Observable<boolean> {
   return this._accountser.currentUser$.pipe(
    map(user=>{
      if(user)return true;
      else{
        Swal.fire('Error',"you shall not pass",'error');
        return false;
      }
    })
   )
    
  }
  
}
