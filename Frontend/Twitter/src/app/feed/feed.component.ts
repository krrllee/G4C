import { Component,OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';



@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css']
})
export class FeedComponent implements OnInit {
  tweets:any[] = [];

  constructor(private http: HttpClient) {}
  private ngUnsubscribe = new Subject();

  ngOnInit(): void {
    this.getTweets();
  }

  getTweets() {
    // Fetch the token from sessionStorage
    const token = sessionStorage.getItem('authToken'); // Replace 'token' with your sessionStorage key

    // Set the token in the request headers
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    // Make the API request
    this.http
      .get<any[]>('http://localhost:5050/api/tweets/GetTweets', { headers })
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(
        (response) => {
          console.log(response);
          this.tweets = response;
        },
        (error) => {
          console.error('Error fetching tweets', error);
        }
      );
  }
}
