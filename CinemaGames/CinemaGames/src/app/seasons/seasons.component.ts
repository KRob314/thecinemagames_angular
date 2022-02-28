import { Component, OnInit } from '@angular/core';
import { AppToastService } from '../app-toast.service';
import { Season } from '../models/season';
import { SeasonService } from '../season.service';

@Component({
  selector: 'app-seasons',
  templateUrl: './seasons.component.html',
  styleUrls: ['./seasons.component.css']
})
export class SeasonsComponent implements OnInit {
  seasons: Season[] = [];
  season: Season = { id: 0, name: '', startDate: new Date(Date.now()), endDate: new Date(Date.now() + 12096e5), isCurrent: true };
  isEdit: boolean = false;

  constructor(private seasonService: SeasonService, private toastService: AppToastService) { }

  ngOnInit(): void
  {
    this.getSeasons();
  }

  toggleEdit(): void
  {
    this.isEdit = !this.isEdit;
  }

  getCurrentDate(): string
  {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    return mm + '/' + dd + '/' + yyyy;
  }

  getSeasons(): void
  {
    this.seasonService.getSeasons().subscribe(s => this.seasons = s);
  }

  save(season: Season): void
  {
    this.seasonService.updateSeason(season).subscribe(s =>
    {
      this.toastService.show(`${season.name} has been saved.`, { classname: 'bg-success text-light', delay: 5000 });
    });
  }

  delete(season: Season): void
  {
    this.seasonService.deleteSeason(season.id).subscribe(s =>
    {
      this.seasons = this.seasons.filter(s => s !== season);
    });
  }

  add(): void
  {
    this.seasonService.addSeason(this.season).subscribe(s =>
    {
      this.seasons.push({ id: this.season.id, name: this.season.name, startDate: this.season.startDate, endDate: this.season.endDate, isCurrent: this.season.isCurrent });
      this.season = { id: 0, name: '', startDate: new Date(Date.now()), endDate: new Date(Date.now() + 12096e5), isCurrent: true };
    });


  }
}
