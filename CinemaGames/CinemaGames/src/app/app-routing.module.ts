import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//import { DashboardComponent } from './dashboard/dashboard.component';
import { GenresComponent } from './genres/genres.component';
import { GenreDetailsComponent } from './genre-details/genre-details.component';
import { SeasonsComponent } from './seasons/seasons.component';
import { MatchesComponent } from './matches/matches.component';
import { MovieSubmissionComponent } from './movie-submission/movie-submission.component';
import { MovieRatingsComponent } from './movie-ratings/movie-ratings.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MatchSummaryComponent } from './match-summary/match-summary.component';
import { SubmitMovieComponent } from './submit-movie/submit-movie.component';

const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' },
  //{ path: 'dashboard', component: DashboardComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'genres', component: GenresComponent },
  { path: 'genre-details/:id', component: GenreDetailsComponent },
  { path: 'seasons', component: SeasonsComponent },
  { path: 'matches', component: MatchesComponent },
  { path: 'movieSubmissions', component: MovieSubmissionComponent },
  { path: 'movieRatings', component: MovieRatingsComponent },
  { path: 'matchSummary/:id', component: MatchSummaryComponent },
  {path: 'submitMovie/:id', component: SubmitMovieComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
