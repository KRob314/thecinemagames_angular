import { Component, OnInit } from '@angular/core';
import { Match } from '../models/match'
import { MovieSubmission } from '../models/movieSubmission';
import { MovieRating } from '../models/movieRating';
import { MovieRatingsService } from '../movie-ratings.service';
import { Player } from '../models/player';
import { PlayerService } from '../player.service';
import { MatchService } from '../match.service';
import { MovieSubmissionService } from '../movie-submission.service';
import { AppToastService } from '../app-toast.service';

@Component({
  selector: 'app-movie-ratings',
  templateUrl: './movie-ratings.component.html',
  styleUrls: ['./movie-ratings.component.css']
})
export class MovieRatingsComponent implements OnInit {
  movieRatings: MovieRating[] = [];
  movieRating: MovieRating = { id: 0, created: '', movieSubmissionId: 0, playerId: 0, rating: 0, reasonForVote: '', pickEm: '' }
  players: Player[] = [];
  matches: Match[] = [];
  movieSubmissions: MovieSubmission[] = [];
  isEdit: boolean = false;
  pageSize: number = 8;
  page: number = 1;

  constructor(private movieRatingService: MovieRatingsService, private playerService: PlayerService, private matchService: MatchService, private movieSubmissionService: MovieSubmissionService, private toastService: AppToastService) { }

  ngOnInit(): void
  {
    this.getMovieSubmissions();
    this.getPlayers();
    this.getMovieRatings();

  }

  maxNavNumbers(): number
  {
    if (window.innerWidth > 1440)
      return 25;
    if (window.innerWidth <= 1440 && window.innerWidth > 1024)
      return 15;
    if (window.innerWidth <= 1024)
      return 10;

    return 15;
  }

  toggleEdit(): void
  {
    this.isEdit = !this.isEdit;
  }

  getMovieSubmissions(): void
  {
    this.movieSubmissionService.getMovieSubmissions().subscribe(m => this.movieSubmissions = m);
  }

  getMatches(): void
  {
    this.matchService.getMatches().subscribe(m => this.matches = m);
  }

  getPlayers(): void
  {
    this.playerService.getPlayers().subscribe(p => this.players = p);
  }

  getMovieRatings(): void
  {
    this.movieRatingService.getMovieRatings().subscribe(m => this.movieRatings = m);
  }

  add(): void
  {

  }

  save(movieRating: MovieRating): void
  {
    this.movieRatingService.updateMovieRating(movieRating).subscribe(m =>
    {
      this.toastService.show(`Rating has been saved.`, { classname: 'bg-success text-light', delay: 5000 });
    });
  }

  delete(movieRating: MovieRating): void
  {

  }

}
