import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms'; 
import { AppComponent } from './app.component';
import { GenresComponent } from './genres/genres.component';
import { GenreDetailsComponent } from './genre-details/genre-details.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SeasonsComponent } from './seasons/seasons.component';
import { MatchesComponent } from './matches/matches.component';
import {GlobalHttpInterceptorService} from '../app/global-http-interceptor-service.service';
import { MovieSubmissionComponent } from './movie-submission/movie-submission.component';
import { MovieRatingsComponent } from './movie-ratings/movie-ratings.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppToastComponent } from './app-toast/app-toast.component';

@NgModule({
  declarations: [
    AppComponent,
    GenresComponent,
    GenreDetailsComponent,
    NavMenuComponent,
    SeasonsComponent,
    MatchesComponent,
    MovieSubmissionComponent,
    MovieRatingsComponent,
    DashboardComponent,
    AppToastComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule,
    //RouterModule.forRoot([
    //  { path: 'genres', component: GenresComponent },
    //  { path: 'genre-details/:id', component: GenreDetailsComponent },
    //]),
    NgbModule,
    AppRoutingModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: GlobalHttpInterceptorService, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
