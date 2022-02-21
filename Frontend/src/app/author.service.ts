import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Author } from './author';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  private authorsUrl = 'https://localhost:7101/api/authors';

  constructor(private http: HttpClient) { }

  getAuthors(): Observable<Author[]> {
    return this.http.get<Author[]>(this.authorsUrl);
  }

  postAuthor(author: Author): Observable<Author> {
    return this.http.post<Author>(this.authorsUrl, author);
  }

  deleteAuthor(id: number): Observable<Author> {
    const url = `${this.authorsUrl}/${id}`;
    return this.http.delete<Author>(url);
  }
}
