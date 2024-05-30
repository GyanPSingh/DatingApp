import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MemberDetailComponent } from './member-list/member-detail/member-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_gaurds/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {path:'', runGuardsAndResolvers:'always',
    canActivate:[authGuard],
    children:[ { path: 'members', component: MemberListComponent, canActivate:[authGuard] },
    { path: 'members/:id', component: MemberDetailComponent },
    { path: 'about', component: AboutComponent }, 
    { path: 'register', component: RegisterComponent },
    { path: 'messages', component: MessagesComponent },]
  }, 
  { path: '**', component: HomeComponent,pathMatch:'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
