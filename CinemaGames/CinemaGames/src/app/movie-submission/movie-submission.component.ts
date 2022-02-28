import { Component, OnInit } from '@angular/core';
import { Match } from '../models/match';
import { MatchService } from '../match.service';
import { MovieSubmission } from '../models/movieSubmission';
import { Player } from '../models/player';
import { MovieSubmissionService } from '../movie-submission.service';
import { PlayerService } from '../player.service';
import { AppToastService } from '../app-toast.service';

@Component({
  selector: 'app-movie-submission',
  templateUrl: './movie-submission.component.html',
  styleUrls: ['./movie-submission.component.css']
})
export class MovieSubmissionComponent implements OnInit {
  movieSubmissions: MovieSubmission[] = [];
  movieSubmission: MovieSubmission = { id: 0, title: '', synopsis: '', trailer: '', matchId: 0, playerId: 0, created: new Date(), reasonToChoose: '' };
  players: Player[] = [];
  matches: Match[] = [];
  isEdit: boolean = false;
  pageSize: number = 8;
  page: number = 1;

  constructor(private movieSubmissionService: MovieSubmissionService, private playerService: PlayerService, private matchService: MatchService, private toastService: AppToastService) { }

  ngOnInit(): void
  {
    this.getPlayers();
    this.getMatches();
    this.getMovieSubmissionsForCurrentMatch();
  }

  toggleEdit(): void
  {
    this.isEdit = !this.isEdit;
  }

  getMatches(): void
  {
    this.matchService.getMatches().subscribe(m => this.matches = m);
  }

  getPlayers(): void
  {
    this.playerService.getPlayers().subscribe(p => this.players = p);
  }

  getMovieSubmissions(): void
  {
    this.movieSubmissionService.getMovieSubmissions().subscribe(m => this.movieSubmissions = m);
  }

  getMovieSubmissionsForCurrentMatch(): void
  {
    this.movieSubmissionService.getMovieSubmissionsForCurrentSeason().subscribe(m => this.movieSubmissions = m);
  }

  add(): void
  {
    console.log('adding movie submission');
    console.log(this.movieSubmission);

    this.movieSubmissionService.addMovieSubmission(this.movieSubmission).subscribe(m =>
    {
      this.movieSubmissions.push({
        id: this.movieSubmission.id, title: this.movieSubmission.title, matchId: this.movieSubmission.matchId, playerId: this.movieSubmission.playerId,
        synopsis: this.movieSubmission.synopsis, reasonToChoose: this.movieSubmission.reasonToChoose, trailer: this.movieSubmission.trailer,
        match: this.movieSubmission.match, player: this.movieSubmission.player      });
    })
  }

  save(movieSubmission: MovieSubmission): void
  {
    this.movieSubmissionService.updateMovieSubmission(movieSubmission).subscribe(m =>
    {
      this.toastService.show(`${movieSubmission.title} has been saved.`, { classname: 'bg-success text-light', delay: 5000 });
    });
  }

  delete(movieSubmission: MovieSubmission): void
  {

  }
}
