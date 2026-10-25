import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
