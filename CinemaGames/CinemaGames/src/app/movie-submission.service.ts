import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { MovieSubmission } from "../app/models/movieSubmission"

@Injectable({
  providedIn: 'root'
})
export class MovieSubmissionService {

  private movieSubmissionUrl = 'https://localhost:7121/api/MovieSubmission';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' }),
    withCredentials: true
  };

  constructor(private http: HttpClient)
  {
  }


  getMovieSubmissions(): Observable<MovieSubmission[]>
  {
    return this.http.get<MovieSubmission[]>(this.movieSubmissionUrl)
      .pipe(
        tap(_ => this.log('fetched movieSubmissions')),
        catchError(this.handleError<MovieSubmission[]>('getMovieSubmissions', []))
      );
  }

  //getMovieSubmission(id: number): Observable<MovieSubmission>
  //{
  //  const url = `${this.movieSubmissionUrl}/${id}`;
  //  return this.http.get<MovieSubmission>(url)
  //    .pipe(
  //      tap(h =>
  //      {
  //        const outcome = h ? 'fetched' : 'did not find';
  //        this.log(`${outcome} hero id=${id}`);
  //      }),
  //      catchError(this.handleError<MovieSubmission>('getMovieSubmission  id=${id}'))
  //    );
  //}

  addMovieSubmission(movieSubmission: MovieSubmission): Observable<MovieSubmission>
  {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    movieSubmission.created = new Date(mm + '/' + dd + '/' + yyyy);
    return this.http.post<MovieSubmission>(this.movieSubmissionUrl, movieSubmission, this.httpOptions).pipe(
      tap((newMovieSubmission: MovieSubmission) => this.log(`added movieSubmission w/ id=${newMovieSubmission.id}`)),
      catchError(this.handleError<MovieSubmission>('addMovieSubmission'))
    );
  }

  updateMovieSubmission(movieSubmission: MovieSubmission): Observable<any>
  {
    return this.http.put(this.movieSubmissionUrl + '/' + movieSubmission.id, movieSubmission, this.httpOptions).pipe(
      tap(_ => this.log(`updated movieSubmission id=${movieSubmission.id}`)),
      catchError(this.handleError<any>('updateMovieSubmission'))
    );
  }

  deleteMovieSubmission(id: number): Observable<MovieSubmission>
  {
    const url = `${this.movieSubmissionUrl}/${id}`;

    return this.http.delete<MovieSubmission>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted movieSubmission id=${id}`)),
      catchError(this.handleError<MovieSubmission>('deleteMovieSubmission'))
    );
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 *    return this.http.get<MovieSubmission[]>(this.movieSubmissionUrl)
      .pipe(
        tap(_ => this.log('fetched heroes')),
        catchError(this.handleError<MovieSubmission[]>('getMovieSubmissions', []))
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
