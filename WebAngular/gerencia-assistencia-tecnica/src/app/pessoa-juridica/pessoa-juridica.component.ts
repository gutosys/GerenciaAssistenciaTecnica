import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { IPessoaJuridica } from './pessoa-juridica';
import { PessoaJuridicaService } from '../shared/pessoa-juridica-service';

@Component({
    selector: 'app-pessoa-juridica',
    templateUrl: './pessoa-juridica.component.html',
    styleUrls: ['./pessoa-juridica.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class PessoaJuridicaComponent implements OnInit {
  pessoaJuridicas: IPessoaJuridica[] = [];
  errorMessage: string;

  constructor(private pessoaJuridicaService: PessoaJuridicaService) { }

  ngOnInit() {
    this.pessoaJuridicaService.getPessoaJuridicas().subscribe(
      pessoaJuridicas =>{
        this.pessoaJuridicas = pessoaJuridicas;
      },     
      error => this.errorMessage = <any>error   
    );
  }

}
