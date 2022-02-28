import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Season } from '../app/models/season';

@Injectable({
  providedIn: 'root'
})
export class SeasonService {

  private seasonUrl = 'https://localhost:7121/api/Season';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' }),
    withCredentials: true
  };

  constructor(private http: HttpClient)
  {
  }


  /** GET heroes from the server */
  getSeasons(): Observable<Season[]>
  {
    return this.http.get<Season[]>(this.seasonUrl)
      .pipe(
        tap(_ => this.log('fetched seasons')),
        catchError(this.handleError<Season[]>('getSeasons', []))
      );
  }

  //getSeason(id: number): Observable<Season>
  //{
  //  const url = `${this.seasonUrl}/${id}`;
  //  return this.http.get<Season>(url)
  //    .pipe(
  //      tap(h =>
  //      {
  //        const outcome = h ? 'fetched' : 'did not find';
  //        this.log(`${outcome} hero id=${id}`);
  //      }),
  //      catchError(this.handleError<Season>('getSeason  id=${id}'))
  //    );
  //}

  addSeason(season: Season): Observable<Season>
  {
    return this.http.post<Season>(this.seasonUrl, season, this.httpOptions).pipe(
      tap((newSeason: Season) => this.log(`added season w/ id=${newSeason.id}`)),
      catchError(this.handleError<Season>('addSeason'))
    );
  }

  updateSeason(season: Season): Observable<any>
  {
    return this.http.put(this.seasonUrl + '/' + season.id, season, this.httpOptions).pipe(
      tap(_ => this.log(`updated season id=${season.id}`)),
      catchError(this.handleError<any>('updateSeason'))
    );
  }

  deleteSeason(id: number): Observable<Season>
  {
    const url = `${this.seasonUrl}/${id}`;

    return this.http.delete<Season>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted season id=${id}`)),
      catchError(this.handleError<Season>('deleteSeason'))
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
