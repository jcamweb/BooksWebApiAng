import {Injectable,Inject } from '@angular/core';
import { Book } from './book.model';
import { HttpClient,HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private baseURL: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseURL = baseUrl + 'Books' }
 // readonly baseURL = baseUrl + 'api/Books' 
  formData: Book = new Book();
  list: Book[];

  postBook() {
    return this.http.post(this.baseURL, this.formData);
  }

  putBook() {
    return this.http.put(`${this.baseURL}/${this.formData.bookId}`, this.formData);
  }

  deleteBook(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  //refreshList() {
  //  this.http.get(this.baseURL)
  //    .toPromise()
  //    .then(res => this.list = res as Book[]);
  //}

  refreshList() {

    this.http.get<Book[]>(this.baseURL, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
    }).subscribe(result => {
      this.list = result;
    }, error => console.error(error));

  }


  //refreshList(): Observable<Book[]> {
  //  this.list = this.http.get<Book[]>(this.baseURL);
  //  return this.list;
  //} 

}
