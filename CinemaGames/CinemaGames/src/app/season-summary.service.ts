import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { SeasonSummary } from '../app/models/seasonSummary';

@Injectable({
  providedIn: 'root'
})
export class SeasonSummaryService {

  private seasonSummaryUrl = 'https://localhost:7121/api/SeasonSummary';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' }),
    withCredentials: true
  };

  constructor(private http: HttpClient)
  {
  }


  /** GET heroes from the server */
  getSeasonSummary(): Observable<SeasonSummary[]>
  {
    return this.http.get<SeasonSummary[]>(this.seasonSummaryUrl )
      .pipe(
        tap(_ => this.log('fetched season summary')),
        catchError(this.handleError<SeasonSummary[]>('getSeasonSummary', []))
      );
  }

  /**
* Handle Http operation that failed.
* Let the app continue.
*    return this.http.get<Season[]>(this.seasonUrl)
    .pipe(
      tap(_ => this.log('fetched heroes')),
      catchError(this.handleError<Season[]>('getSeasons', []))
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
