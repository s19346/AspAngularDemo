import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Author } from '../author';
import { AuthorService } from '../author.service';
import { Book } from '../book';
import { BookService } from '../book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: Book[] = [];
  authors: Author[] = [];
  selectedAuthors: Author[] = [];

  constructor(private bookService: BookService, private authorService: AuthorService) { }

  ngOnInit(): void {
    this.getBooks();
    this.getAuthors();
  }

  form = new FormGroup({
    author: new FormControl()
  });

  getBooks(): void {
    this.bookService.getBooks().subscribe(books => this.books = books);
  }

  getAuthors(): void {
    this.authorService.getAuthors().subscribe(authors => this.authors = authors);
  }

  addBook(title: string, authors: Author[]): void {
    console.log(authors);
    this.bookService.postBook({ title, authors } as Book)
      .subscribe(book => this.books.push(book));
  }

  deleteBook(book: Book): void {
    this.books = this.books.filter(b => b !== book);
    this.bookService.deleteBook(book.idBook).subscribe();
  }

}
