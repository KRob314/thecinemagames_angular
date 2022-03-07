import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Genre } from '../models/genre'
import { GenreService } from '../genre.service';
import { AppToastService } from '../app-toast.service';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {
  genres: Genre[] = [];
  genre: Genre = { id: 0, name: '', description: '' };
  isEdit: boolean = false;
  pageSize: number = 10;
  page: number = 1;
  genreForm!: FormGroup;
  constructor(private genreService: GenreService, private toastService: AppToastService)
  {
  }

  ngOnInit(): void
  {
    this.getGenres();

    this.genreForm = new FormGroup({
      name: new FormControl(this.genre.name, [
        Validators.required,
        Validators.maxLength(50),
      ]),
      description: new FormControl(this.genre.description, [
        Validators.required,
        Validators.maxLength(500),
      ])
    });
  }

  get name() { return this.genreForm.get('name')!; }
  get description() { return this.genreForm.get('description')!; }

  toggleEdit(): void
  {
    this.isEdit = !this.isEdit;
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
      this.genres.push({ id: this.genre.id, name: this.genre.name, description: this.genre.description });
      this.toastService.show(`${this.genre.name} has been saved.`, { classname: 'bg-success text-light', delay: 5000 });
    });
  }

  save(genre: Genre): void
  {
    if (genre)
    {
      this.genreService.updateGenre(genre).subscribe(g =>
      {
        this.toastService.show(`${genre.name} has been saved.`, { classname: 'bg-success text-light', delay: 5000 });
      });
    }
  }
}
