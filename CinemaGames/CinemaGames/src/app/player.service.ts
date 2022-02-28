import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Player } from '../app/models/player';


@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  private playerUrl = 'https://localhost:7121/api/Player';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' }),
    withCredentials: true
  };

  constructor(private http: HttpClient)
  {
  }


  /** GET heroes from the server */
  getPlayers(): Observable<Player[]>
  {
    return this.http.get<Player[]>(this.playerUrl)
      .pipe(
        tap(_ => this.log('fetched players')),
        catchError(this.handleError<Player[]>('getPlayers', []))
      );
  }

  //getPlayer(id: number): Observable<Player>
  //{
  //  const url = `${this.playerUrl}/${id}`;
  //  return this.http.get<Player>(url)
  //    .pipe(
  //      tap(h =>
  //      {
  //        const outcome = h ? 'fetched' : 'did not find';
  //        this.log(`${outcome} hero id=${id}`);
  //      }),
  //      catchError(this.handleError<Player>('getPlayer  id=${id}'))
  //    );
  //}

  addPlayer(player: Player): Observable<Player>
  {
    return this.http.post<Player>(this.playerUrl, player, this.httpOptions).pipe(
      tap((newPlayer: Player) => this.log(`added player w/ id=${newPlayer.id}`)),
      catchError(this.handleError<Player>('addPlayer'))
    );
  }

  updatePlayer(player: Player): Observable<any>
  {
    return this.http.put(this.playerUrl + '/' + player.id, player, this.httpOptions).pipe(
      tap(_ => this.log(`updated player id=${player.id}`)),
      catchError(this.handleError<any>('updatePlayer'))
    );
  }

  deletePlayer(id: number): Observable<Player>
  {
    const url = `${this.playerUrl}/${id}`;

    return this.http.delete<Player>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted player id=${id}`)),
      catchError(this.handleError<Player>('deletePlayer'))
    );
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 *    return this.http.get<Player[]>(this.playerUrl)
      .pipe(
        tap(_ => this.log('fetched heroes')),
        catchError(this.handleError<Player[]>('getPlayers', []))
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
