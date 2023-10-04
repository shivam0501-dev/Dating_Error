import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';
import {GalleryItem, GalleryModule, ImageItem } from 'ng-gallery';
@Component({
  selector: 'app-member-detail',
  standalone:true,
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css'],
  imports:[CommonModule,TabsModule,GalleryModule]
})
export class MemberDetailComponent implements OnInit  {
  member: Member| undefined
  images:GalleryItem[]=[];
  constructor(private _member:MembersService,private _route:ActivatedRoute) {
    

  }
  ngOnInit(): void {
    this.loadmember();
  } 
  loadmember(){
    var username=this._route.snapshot.paramMap.get('username');
    if(!username)return;
    this._member.getMember(username).subscribe({
      next:response=>{
        this.member=response;
        this.getimages()
      }
    });
  }
 getimages(){
  if(!this.member) return;
  for(const photo of this.member.photos){
    this.images.push(new ImageItem({src:photo.url,thumb:photo.url}))
  }
 }

}
