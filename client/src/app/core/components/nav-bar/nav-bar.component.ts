import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.sass']
})
export class NavBarComponent implements OnInit {

  @ViewChild("menu", {static: true}) menu: ElementRef;

  constructor() { }

  ngOnInit() {
  }

  toogleMenu() {
    (this.menu.nativeElement as HTMLDivElement).classList.toggle("show");
  }

}
