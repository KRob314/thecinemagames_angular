import { Component, OnInit } from '@angular/core';
import { Match } from '../models/match';
import { Genre } from '../models/genre';
import { MatchService } from '../match.service';
import { GenreService } from '../genre.service';
import { SeasonService } from '../season.service';
import { Season } from '../models/season';
import { AppToastService } from '../app-toast.service';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.css']
})

export class MatchesComponent implements OnInit {
  genres: Genre[] = [];
  matches: Match[] = [];
  seasons: Season[] = [];
  match: Match = { id: 0, name: '', startDate: new Date(Date.now()), endDate: new Date(Date.now() + 12096e5), isCurrent: true };
  statuses = [{ id: 1, name: 'Open For Movie Submission' }, { id: 2, name: 'Open For Voting' }, { id: 3, name: 'Unavailable' }, {id: 4, name: 'Closed'}]
  selectedGenre = null;
  isEdit: boolean = false;
  pageSize: number = 10;
  page: number = 1;

  constructor(private matchService: MatchService, private genreService: GenreService, private seasonService: SeasonService, private toastService: AppToastService) { }

  ngOnInit(): void
  {
    this.getSeasons();
    this.getGenres();
    this.getMatches();
  }

  toggleEdit(): void
  {
    this.isEdit = !this.isEdit;
  }

  getSeasons(): void
  {
    this.seasonService.getSeasons().subscribe(s => this.seasons = s);
  }

  getGenres(): void
  {
    this.genreService.getGenres().subscribe(g => this.genres = g);
  }

  getMatches(): void
  {
    this.matchService.getMatches().subscribe(m => this.matches = m);
  }

  save(match: Match): void
  {

    this.matchService.updateMatch(match).subscribe(m =>
    {
      
      this.toastService.show(`${match.name} has been saved.`, { classname: 'bg-success text-light', delay: 5000 });
    });
  }

  delete(match: Match): void
  {
    this.matchService.deleteMatch(match.id).subscribe(m =>
    {
      this.matches = this.matches.filter(m => m != match);
    })
  }

  add(): void
  {
    this.matchService.addMatch(this.match).subscribe(s =>
    {
      this.matches.push({ id: this.match.id, name: this.match.name, startDate: this.match.startDate, endDate: this.match.endDate, isCurrent: this.match.isCurrent });
      this.match = { id: 0, name: '', startDate: new Date(Date.now()), endDate: new Date(Date.now() + 12096e5), isCurrent: true };
    });


  }

}
