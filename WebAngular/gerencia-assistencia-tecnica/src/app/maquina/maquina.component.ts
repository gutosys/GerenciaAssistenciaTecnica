import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { IMaquina } from './maquina';
import { MaquinaService } from '../shared/maquina.service';

@Component({
    selector: 'app-maquina',
    templateUrl: './maquina.component.html',
    styleUrls: ['./maquina.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class MaquinaComponent implements OnInit {
  maquinas: IMaquina[] = [];
  errorMessage: string;

  constructor(private maquinaService: MaquinaService) { }

  ngOnInit() : void {
    this.maquinaService.getMaquinas().subscribe(
      maquinas =>{
        this.maquinas = maquinas;
      },
      error => this.errorMessage = <any>error   
    );
  }

}
