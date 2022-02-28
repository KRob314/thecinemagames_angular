import { Component, OnInit } from '@angular/core';
import { Genre } from '../models/genre'
import { GenreService } from '../genre.service';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {
  genres: Genre[] = [];
  genre: Genre = {id: 0, name: '', description: '' };

  constructor(private genreService: GenreService) { }

  ngOnInit(): void
  {
    this.getGenres();
  }

  getGenres(): void
  {
    this.genreService.getGenres().subscribe(g => this.genres = g);
  }

  deleteGenre(genreToDelete: Genre): void
  {
    this.genres = this.genres.filter(h => h !== genreToDelete);
    this.genreService.deleteGenre(genreToDelete.id).subscribe();
  }

  addNew(): void
  {
    this.genreService.addGenre(this.genre).subscribe(g =>
    {
      this.genres.push({id: this.genre.id, name: this.genre.name, description: this.genre.description});
    });



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
