import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { IAcessorio } from './acessorio';
import { AcessorioService } from '../shared/acessorio.service';

@Component({
    selector: 'app-acessorio',
    templateUrl: './acessorio.component.html',
    styleUrls: ['./acessorio.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class AcessorioComponent implements OnInit {
  acessorios: IAcessorio[] = [];
  errorMessage: string;

  constructor(private acessorioService: AcessorioService) { }

  ngOnInit(): void {
    this.acessorioService.getAcessorios().subscribe(
      acessorios =>{
        this.acessorios = acessorios;
      },
      error => this.errorMessage = <any>error   
    );
  }

}
