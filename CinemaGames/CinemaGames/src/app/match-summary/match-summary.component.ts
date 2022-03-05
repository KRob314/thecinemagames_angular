import { Component, OnInit, Input  } from '@angular/core';
import { MatchSummaryResults } from '../models/matchSummaryResults';
import { MatchSummaryService } from '../match-summary-results.service';

@Component({
  selector: 'app-match-summary',
  templateUrl: './match-summary.component.html',
  styleUrls: ['./match-summary.component.css']
})
export class MatchSummaryComponent implements OnInit
{
  @Input() matchId?: number | undefined;
  matchSummary: MatchSummaryResults = { movie: '', moviePoints: 0, movieRank: 0,  weekName: '' }
  matchSummaries: MatchSummaryResults[] = [];

  constructor(private matchSummaryService: MatchSummaryService) { }

  ngOnInit(): void
  {
    console.log('matchId is: ' + this.matchId)
    this.getMatchResults();
  }

  getMatchResults(): void
  {
    this.matchSummaryService.getMatchResults(this.matchId).subscribe(m => this.matchSummaries = m);
  }

  getMatchId(id: number | undefined)
  {
    return id;
  }
}
