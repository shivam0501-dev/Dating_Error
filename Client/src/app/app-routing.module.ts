import { NgModule, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './members/lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { TestErrorComponent } from './error/test-error/test-error.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';


const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"errors",component:TestErrorComponent},
  {path:"not-found",component:NotFoundComponent},
  {path:"server-error",component:ServerErrorComponent},



  {path:'',runGuardsAndResolvers:'always',canActivate:[AuthGuard],children:[

      {path:"members",component:MemberListComponent},
      {path:"member/:username",component:MemberDetailComponent},
      {path:"lists",component:ListsComponent},
      {path:"messages",component:MessagesComponent},
      {path:"member/edit",component:MemberEditComponent}
  ]},
  {path:"**",component:NotFoundComponent,pathMatch:"full"},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule  {
  
}
