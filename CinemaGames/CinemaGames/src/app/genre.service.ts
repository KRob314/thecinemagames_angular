import { Injectable } from '@angular/core';
import { Genre } from '../app/models/genre'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class GenreService {
  private genreUrl = 'https://localhost:7121/api/Genre';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' }),
    withCredentials: true
  };

  constructor(private http: HttpClient)
  {
  }


  /** GET heroes from the server */
  getGenres(): Observable<Genre[]>
  {
    return this.http.get<Genre[]>(this.genreUrl + '/get')
      .pipe(
        tap(_ => this.log('fetched heroes')),
        catchError(this.handleError<Genre[]>('getGenres', []))
      );
  }

  getGenre(id: number): Observable<Genre>
  {
    const url = `${this.genreUrl}/get/${id}`;
    return this.http.get<Genre>(url)
      .pipe(
        tap(h =>
        {
          const outcome = h ? 'fetched' : 'did not find';
          this.log(`${outcome} hero id=${id}`);
        }),
        catchError(this.handleError<Genre>('getGenre  id=${id}'))
      );
  }

  addGenre(genre: Genre): Observable<Genre>
  {
    return this.http.post<Genre>(this.genreUrl + '/post', genre, this.httpOptions).pipe(
      tap((newGenre: Genre) => this.log(`added genre w/ id=${newGenre.id}`)),
      catchError(this.handleError<Genre>('addGenre'))
    );
  }

  updateGenre(genre: Genre): Observable<any>
  {
    return this.http.put(this.genreUrl + '/put', genre, this.httpOptions).pipe(
      tap(_ => this.log(`updated genre id=${genre.id}`)),
      catchError(this.handleError<any>('updateGenre'))
    );
  }

  deleteGenre(id: number): Observable<Genre>
  {
    const url = `${this.genreUrl}/delete/${id}`;

    return this.http.delete<Genre>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted genre id=${id}`)),
      catchError(this.handleError<Genre>('deleteGenre'))
    );
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 *    return this.http.get<Genre[]>(this.genreUrl)
      .pipe(
        tap(_ => this.log('fetched heroes')),
        catchError(this.handleError<Genre[]>('getGenres', []))
      );
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T)
  {
    return (error: any): Observable<T> =>
    {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string)
  {
    //this.messageService.add(`HeroService: ${message}`);
  }

}
