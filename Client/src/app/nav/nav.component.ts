import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{
model:any={};
constructor(public _accountSer:AccountService,private router:Router,private toastr:ToastrService) {}

ngOnInit(): void {
  
}


login(){
  return this._accountSer.login(this.model).subscribe({
    next:_=>{
      //Swal.fire('Success!', 'User LoggedIn', 'success');
      //this.toastr.error("loggedIn")
      this.router.navigateByUrl('/members')
    }
  });
}


logout(){
  this._accountSer.logout();
  this.router.navigateByUrl('/')
}

}
