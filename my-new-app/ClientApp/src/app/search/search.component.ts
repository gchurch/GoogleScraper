import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  public intResponse$: Observable<number>;
  public stringResponse$;
  public searchForm: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.createSearchForm();
  }

  private createSearchForm(): void {
    this.searchForm = new FormGroup({
      keywords: new FormControl('', Validators.required),
      url: new FormControl('', Validators.required)
    });
  }

  public onSearch(): void {
    this.stringResponse$ = this.http.get(this.baseUrl + "api/search/string", 
    {
      responseType: 'text',
      params: {
        keywords: this.searchForm.value.keywords,
        url: this.searchForm.value.url
      }
    });
  }
}
