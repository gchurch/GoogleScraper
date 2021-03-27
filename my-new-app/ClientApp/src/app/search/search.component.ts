import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  public intResponse$: Observable<number>;
  public stringResponse$;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.intResponse$ = this.http.get<number>(this.baseUrl + "api/search/int");
    this.stringResponse$ = this.http.get(this.baseUrl + "api/search/string", {responseType: 'text'});
  }

}
