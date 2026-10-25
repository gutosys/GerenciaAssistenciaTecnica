import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
    selector: 'app-componente',
    templateUrl: './componente.component.html',
    styleUrls: ['./componente.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ComponenteComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
