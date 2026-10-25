import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { EntradaAssistenciaService } from 'src/app/shared/entrada-assistencia.service';
import { IEntradaAssistencia } from '../entrada-assistencia';

@Component({
    selector: 'app-entrada-assistencia',
    templateUrl: './entrada-assistencia.component.html',
    styleUrls: ['./entrada-assistencia.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EntradaAssistenciaComponent implements OnInit {
  entradaAssistencias: IEntradaAssistencia[] = [];
  errorMessage: string;

  constructor(private entradaAssistenciaService: EntradaAssistenciaService) { }

  ngOnInit(): void {
    this.entradaAssistenciaService.getEntradaAssistencias().subscribe(
      entradaAssistencias =>{
        this.entradaAssistencias = entradaAssistencias;
      },
      error => this.errorMessage = <any>error   
    );
  }
}
