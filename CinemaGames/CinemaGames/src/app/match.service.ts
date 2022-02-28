import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Match, MatchEdit } from './models/match';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  private matchUrl = 'https://localhost:7121/api/Match';  // URL to web api
  clientError = { code: '', description: '' }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' }),
    withCredentials: true
  };

  constructor(private http: HttpClient)
  {
  }

  getMatches(): Observable<Match[]>
  {
    return this.http.get<Match[]>(this.matchUrl)
      .pipe(
        tap(_ => this.log('fetched matchs')),
        catchError(this.handleError<Match[]>('getMatches', []))
      );
  }

  //getSeason(id: number): Observable<Match>
  //{
  //  const url = `${this.matchUrl}/${id}`;
  //  return this.http.get<Match>(url)
  //    .pipe(
  //      tap(h =>
  //      {
  //        const outcome = h ? 'fetched' : 'did not find';
  //        this.log(`${outcome} hero id=${id}`);
  //      }),
  //      catchError(this.handleError<Match>('getSeason  id=${id}'))
  //    );
  //}

  addMatch(match: Match): Observable<Match>
  {
    return this.http.post<Match>(this.matchUrl, match, this.httpOptions).pipe(
      tap((newSeason: Match) => this.log(`added match w/ id=${newSeason.id}`)),
      catchError(this.handleError<Match>('addSeason'))
    );
  }

  updateMatch(match: Match): Observable<any>
  {
    console.log('update match');
    console.log(match);
    

    return this.http.put(this.matchUrl + '/' + match.id, match,
      this.httpOptions).pipe(
      tap(_ => this.log(`updated match id=${match.id}`)),
      catchError(
        this.handleError<any>('updateMatch')

      )
    );

  }

  deleteMatch(id: number): Observable<Match>
  {
    const url = `${this.matchUrl}/${id}`;

    return this.http.delete<Match>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted match id=${id}`)),
      catchError(this.handleError<Match>('deleteSeason'))
    );
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 *    return this.http.get<Match[]>(this.matchUrl)
      .pipe(
        tap(_ => this.log('fetched heroes')),
        catchError(this.handleError<Match[]>('getSeasons', []))
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
    console.log('ERROR');
    console.log(message);
  }


}
