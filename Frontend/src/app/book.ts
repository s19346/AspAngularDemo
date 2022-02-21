import { Author } from "./author";

export interface Book {
  idBook: number,
  title: string,
  authors: Author[]
}
