import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  user:any = {
    Username:"",
    FirstName:"",
    LastName:"",
    Email:"",
    Password:""
  }
  
  constructor(private http: HttpClient,private router: Router) {}
  
  private ngUnsubscribe = new Subject();

  registerUser(){
    this.http.post('http://localhost:5050/api/login/register',this.user,{responseType:'text'})
    .pipe(takeUntil(this.ngUnsubscribe))
    .subscribe((data) => { 
      this.router.navigate(['/login']);
    });
  }


}
