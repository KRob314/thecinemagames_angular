import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { GenreService } from '../genre.service';
import { Genre } from '../models/genre';

@Component({
  selector: 'app-genre-details',
  templateUrl: './genre-details.component.html',
  styleUrls: ['./genre-details.component.css']
})
export class GenreDetailsComponent implements OnInit {
  genre: Genre | undefined;

  constructor(private route: ActivatedRoute,
    private location: Location,
  private genreService: GenreService) { }

  ngOnInit(): void
  {
    this.getGenre()
  }

  getGenre(): void
  {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.genreService.getGenre(id).subscribe(g => this.genre = g);
  }

  goBack(): void
  {
    this.location.back();
  }

  save(): void
  {
    //if (this.hero)
    //{
    //  this.heroService.updateHero(this.hero)
    //    .subscribe(() => this.goBack());
    //}
  }

}
