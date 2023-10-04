import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import Swal from 'sweetalert2';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
model:any={}
//@Input() usersFromHomeComponent:any;
@Output() cancleRegister=new EventEmitter();
constructor(private _accountser:AccountService,private toast:ToastrService) {}

  ngOnInit(): void {
  }

  register(){
    return this._accountser.register(this.model).subscribe({
      next:()=>{
        this.cancle();
      },
      error:error=>{
        this.toast.error(error.error)
        console.log(error)
      }
    })
  }

  cancle()
  {
    this.cancleRegister.emit(false);
  }
}
