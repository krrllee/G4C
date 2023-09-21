import { Component, OnInit } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  tweets: any[] = [];
  newTweetContent: string = '';
  userData: any[] = []; // Use 'any' for user data

  constructor(
    private http: HttpClient,
    private router: Router,
    private datePipe: DatePipe
  ) {}

  private ngUnsubscribe = new Subject();

  formatDate(date: string | null): any {
    return this.datePipe.transform(date ?? new Date(), 'short');
  }

  ngOnInit(): void {
    this.getTweets();
    this.getUserData();
  }

  

  getTweets() {
    const token = sessionStorage.getItem('authToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http
      .get<any[]>('http://localhost:5050/api/tweets/GetTweets', { headers })
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(
        (response) => {
          response.sort((a, b) => new Date(b.created).getTime() - new Date(a.created).getTime());
          this.tweets.unshift(...response);
        },
        (error) => {
          console.error('Error fetching tweets', error);
        }
      );
  }

  // Method to send the AddTweet request
  addTweet() {
    const token = sessionStorage.getItem('authToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    const requestBody = { content: this.newTweetContent };
    if (this.newTweetContent !== "") {
      this.http
        .post<any>('http://localhost:5050/api/tweets/AddTweet', requestBody, { headers })
        .pipe(takeUntil(this.ngUnsubscribe))
        .subscribe(
          (response) => {
            console.log('Tweet added successfully');

            this.getTweets();

            // Clear the new tweet content
            this.newTweetContent = '';
            this.router.navigate(['/dashboard']);
          },
          (error) => {
            console.error('Error adding tweet', error);
          }
        );
    }
  }

  getUserData() {
    const token = sessionStorage.getItem('authToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http
      .get<any[]>('http://localhost:5050/api/users/GetAll', { headers })
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(
        (response) => {
          console.log(response);
          this.userData = response;
        },
        (error) => {
          console.error('Error fetching user data', error);
        }
      );
  }
}
