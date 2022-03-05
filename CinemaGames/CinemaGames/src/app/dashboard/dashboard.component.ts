import { Component, OnInit } from '@angular/core';
import { SeasonSummary } from '../models/seasonSummary';
import { SeasonSummaryService } from '../season-summary.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  seasonSummaries: SeasonSummary[] = [];
  constructor(private seasonSummaryService: SeasonSummaryService) { }

  ngOnInit(): void
  {
    this.getMovieRatings();
  }

  getMovieRatings(): void
  {
    this.seasonSummaryService.getSeasonSummary().subscribe(m => this.seasonSummaries = m);
  }

  getAccordionHeader(id: number): string
  {
    return 'accordionHeader_' + id
  }

  getCollapseId(index: number): string
  {
    //if (withHash)
    //  return '#collapse_' + index
    //else
      return 'collapse_' + index
  }

  getCollapseIdWithHash(index: number): string
  {
    return '#collapse_' + index
  }

  getMatchId(id: number | undefined)
  {
    return id;
  }
}
