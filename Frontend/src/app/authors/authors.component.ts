import { Component, OnInit } from '@angular/core';
import { Author } from '../author';
import { AuthorService } from '../author.service';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {
  authors: Author[] = [];

  constructor(private authorService: AuthorService) { }

  ngOnInit(): void {
    this.getAuthors();
  }

  getAuthors(): void {
    this.authorService.getAuthors().subscribe(authors => this.authors = authors);
  }

  addAuthor(firstName: string, lastName: string): void {
    this.authorService.postAuthor({ firstName, lastName } as Author)
      .subscribe(author => this.authors.push(author));
  }

  deleteAuthor(author: Author): void {
    this.authors = this.authors.filter(a => a !== author);
    this.authorService.deleteAuthor(author.idAuthor).subscribe();
  }
}
