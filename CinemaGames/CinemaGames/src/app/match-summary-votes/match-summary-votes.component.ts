import { Component, OnInit, Input } from '@angular/core';
import { MatchSummaryVotes } from '../models/matchSummaryVotes';
import { MatchSummaryService } from '../match-summary-results.service';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-match-summary-votes',
  templateUrl: './match-summary-votes.component.html',
  styleUrls: ['./match-summary-votes.component.css']
})
export class MatchSummaryVotesComponent implements OnInit {
  @Input() matchId?: number | undefined;
  matchVotes: MatchSummaryVotes[] = [];
  pageSize: number = 10;
  page: number = 1;

  constructor(private matchSummaryService: MatchSummaryService) { }

  ngOnInit(): void
  {
    console.log('matchId is: ' + this.matchId)
    this.getMatchVotes();
  }

  getMatchVotes(): void
  {
    this.matchSummaryService.getMatchVotes(this.matchId).subscribe(m => this.matchVotes = m);
  }

  getOffcanvasId(): string
  {
    return '';
  }

  showOffCanvas(index: number)
  {
    var offcanvasElementList = [].slice.call(document.querySelectorAll('.offcanvas'))
    $(offcanvasElementList[1]).show();

    $('#movieReason').text(this.matchVotes[index].reason);
    $('#offcanvasTopLabel').text(this.matchVotes[index].movie);
    //var offcanvasList = offcanvasElementList.map(function (offcanvasEl)
    //{
    //  return new bootstrap.Offcanvas(offcanvasEl)

    //})
    //$(`[offcanvasid="${index}"]`).show();
  }

}
