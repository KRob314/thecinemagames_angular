import { Component, OnInit } from '@angular/core';
import { SeasonStanding } from '../models/seasonStanding';
import { SeasonStandingsService } from '../season-standings.service';

@Component({
  selector: 'app-season-standings',
  templateUrl: './season-standings.component.html',
  styleUrls: ['./season-standings.component.css']
})
export class SeasonStandingsComponent implements OnInit {
  seasonStandings: SeasonStanding[] = [];
  constructor(private seasonStandingService: SeasonStandingsService) { }

  ngOnInit(): void
  {
    this.getSeasonStandings();
  }

  getSeasonStandings(): void
  {
    this.seasonStandingService.getSeasonStandings().subscribe(s => this.seasonStandings = s);
  }

}
