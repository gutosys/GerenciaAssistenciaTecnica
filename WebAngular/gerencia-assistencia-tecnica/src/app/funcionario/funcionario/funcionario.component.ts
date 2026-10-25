import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { IFuncionario } from '../funcionario';
import { FuncionarioService } from 'src/app/shared/funcionario.service';

@Component({
    selector: 'funcionario',
    templateUrl: './funcionario.component.html',
    styleUrls: ['./funcionario.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class FuncionarioComponent implements OnInit {
  funcionarios: IFuncionario[] = [];
  errorMessage: string;


  constructor(private funcionarioService: FuncionarioService) { }

  ngOnInit() {
    this.funcionarioService.getFuncionarios().subscribe(
      funcionarios =>{
        this.funcionarios = funcionarios;
      },
      error => this.errorMessage = <any>error   
    );
  }
}
