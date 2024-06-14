import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Member } from '../_models/member';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }


  getMembers(): Observable<Member[]> {
    return this.http.get<Member[]>(this.baseUrl + 'users');
  }

  getMember(username: string): Observable<Member> {
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

  // private getHttpOptions() {
  //   const userString = localStorage.getItem('user');
  //   if (!userString) {
  //     return {};
  //   }

  //   const user = JSON.parse(userString);
  //   if (!user || !user.token) {
  //     return {};
  //   }

  //   return {
  //     headers: new HttpHeaders({
  //       Authorization: 'Bearer ' + user.token
  //     })
  //   };
  // }


  // getMembers() {
  //   return this.http.get<Member[]>(this.baseUrl + 'users',this.getHttpOptions());//, this.getHttpOptions());
  // }

  // getMember(username: string) {
  //   return this.http.get<Member>(this.baseUrl + 'users/' + username, this.getHttpOptions());
  // }

  // getHttpOptions() {
  //   const userString = localStorage.getItem('user');
  //   if (!userString) return;
  //   const user = JSON.parse(userString);
  //   return {
  //     Headers: new HttpHeaders({
  //       Authorization: 'Bearer ' + user.token
  //     })
  //   }
  // }
}
