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

  public searchResult$;
  public searchForm: FormGroup;
  public firstSearchSubmitted: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.createSearchForm();
  }

  private createSearchForm(): void {
    this.searchForm = new FormGroup({
      keywords: new FormControl('land registry searches', Validators.required),
      url: new FormControl('www.infotrack.co.uk', Validators.required)
    });
  }

  public onSearch(): void {
    console.log("Request sent");
    this.firstSearchSubmitted = true;
    this.searchResult$ = this.http.get(
      this.baseUrl + "api/UrlPositionSearch", 
      {
        responseType: 'text',
        params: {
          keywords: this.searchForm.value.keywords,
          url: this.searchForm.value.url
        }
      }
    );
  }

  public searchButtonEnabled(): boolean {
    if(this.searchForm.valid && (!!this.searchResult$ || this.firstSearchSubmitted == false)) {
      return true;
    }
    else {
      return false;
    }
  }
}
