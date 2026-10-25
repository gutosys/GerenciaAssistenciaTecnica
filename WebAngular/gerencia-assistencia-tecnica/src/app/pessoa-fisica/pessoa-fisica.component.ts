import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { IPessoaFisica } from './pessoa-fisica';
import { PessoaFisicaService } from '../shared/pessoa-fisica.service';
import { EstadoService } from '../shared/estado.service';

@Component({
    selector: 'app-pessoa-fisica',
    templateUrl: './pessoa-fisica.component.html',
    styleUrls: ['./pessoa-fisica.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class PessoaFisicaComponent implements OnInit {

  pessoaFisicas: IPessoaFisica[] = [];
  errorMessage: string;

  constructor(private pessoaFisicaService: PessoaFisicaService) { }

  ngOnInit() : void {
    this.pessoaFisicaService.getPessoaFisicas().subscribe(
      pessoaFisicas =>{
        this.pessoaFisicas = pessoaFisicas;
      },
      error => this.errorMessage = <any>error   
    );
  }


}
