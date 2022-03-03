import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit
{
  isExpanded = false;

  constructor( private route: ActivatedRoute,) { }

  ngOnInit(): void
  {
    var a = this.route
    console.log(window.location.href);
  }

  collapse()
  {
    this.isExpanded = false;
  }

  toggle()
  {
    this.isExpanded = !this.isExpanded;
  }
}
