import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { MovieRating } from "../app/models/movieRating"

@Injectable({
  providedIn: 'root'
})
export class MovieRatingsService {

  private movieRatingUrl = 'https://localhost:7121/api/MovieRating';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' }),
    withCredentials: true
  };

  constructor(private http: HttpClient)
  {
  }


  getMovieRatings(): Observable<MovieRating[]>
  {
    return this.http.get<MovieRating[]>(this.movieRatingUrl)
      .pipe(
        tap(_ => this.log('fetched movieRatings')),
        catchError(this.handleError<MovieRating[]>('getMovieRatings', []))
      );
  }

  //getMovieRating(id: number): Observable<MovieRating>
  //{
  //  const url = `${this.movieRatingUrl}/${id}`;
  //  return this.http.get<MovieRating>(url)
  //    .pipe(
  //      tap(h =>
  //      {
  //        const outcome = h ? 'fetched' : 'did not find';
  //        this.log(`${outcome} hero id=${id}`);
  //      }),
  //      catchError(this.handleError<MovieRating>('getMovieRating  id=${id}'))
  //    );
  //}

  addMovieRating(movieRating: MovieRating): Observable<MovieRating>
  {
    return this.http.post<MovieRating>(this.movieRatingUrl, movieRating, this.httpOptions).pipe(
      tap((newMovieRating: MovieRating) => this.log(`added movieRating w/ id=${newMovieRating.id}`)),
      catchError(this.handleError<MovieRating>('addMovieRating'))
    );
  }

  updateMovieRating(movieRating: MovieRating): Observable<any>
  {
    return this.http.put(this.movieRatingUrl + '/' + movieRating.id, movieRating, this.httpOptions).pipe(
      tap(_ => this.log(`updated movierating id=${movieRating.id}`)),
      catchError(this.handleError<any>('updateMovieRating'))
    );
  }

  deleteMovieRating(id: number): Observable<MovieRating>
  {
    const url = `${this.movieRatingUrl}/${id}`;

    return this.http.delete<MovieRating>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted movieRating id=${id}`)),
      catchError(this.handleError<MovieRating>('deleteMovieRating'))
    );
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 *    return this.http.get<MovieRating[]>(this.movieRatingUrl)
      .pipe(
        tap(_ => this.log('fetched heroes')),
        catchError(this.handleError<MovieRating[]>('getMovieRatings', []))
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
