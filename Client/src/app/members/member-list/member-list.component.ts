import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
/**
 *
 */
constructor(private _mservices:MembersService) {
 
}
members:Member[]=[];

  ngOnInit(): void {
   this.loadMembers();
  }

  loadMembers(){
    debugger
    return this._mservices.getMembers().subscribe({
      next:response=>{
        this.members=response;
        //console.log(response)
      },
      error:error=>console.log(error)
    })
  }

}
