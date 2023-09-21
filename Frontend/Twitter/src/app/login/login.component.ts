import { Component, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {
  loginDto: any = {
    username: '', // Change "email" to "username"
    password: '',
  };
  errorMessage: string | null = null;
  private ngUnsubscribe = new Subject();
  constructor(private http: HttpClient,private router: Router) {}


  onSubmit() {
    this.errorMessage = null;
    this.http
    .post('http://localhost:5050/api/login/login',this.loginDto,{ responseType: 'text' })
    .pipe(takeUntil(this.ngUnsubscribe))
    .subscribe((data) => {
      sessionStorage.setItem('authToken', data);
      console.log(sessionStorage);
      this.router.navigate(['/dashboard']);
    });
    ;
    
  }
  
}
