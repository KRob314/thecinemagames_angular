import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { MatchSummaryResults } from './models/matchSummaryResults';
import { MatchSummaryVotes } from './models/matchSummaryVotes';

@Injectable({
  providedIn: 'root'
})
export class MatchSummaryService
{

  private seasonSummaryUrl = 'https://localhost:7121/api/MatchSummary';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' }),
    withCredentials: true
  };

  constructor(private http: HttpClient)
  {
  }



  getMatchResults(matchId? : number): Observable<MatchSummaryResults[]>
  {
    return this.http.get<MatchSummaryResults[]>(this.seasonSummaryUrl + `/GetMatchResults/${matchId}`)
      .pipe(
        tap(_ => this.log('fetched match summary')),
        catchError(this.handleError<MatchSummaryResults[]>('getMatchSummary', []))
      );
  }

  getMatchVotes(matchId?: number): Observable<MatchSummaryVotes[]>
  {
    return this.http.get<MatchSummaryVotes[]>(this.seasonSummaryUrl + `/GetMatchVotes/${matchId}`)
      .pipe(
        tap(_ => this.log('fetched match summary votes')),
        catchError(this.handleError<MatchSummaryVotes[]>('getMatchSummaryVotes', []))
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
