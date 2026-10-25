import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { EtiquetaService } from '../shared/etiqueta.service';

@Component({
    selector: 'app-etiqueta',
    templateUrl: './etiqueta.component.html',
    styleUrls: ['./etiqueta.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EtiquetaComponent implements OnInit {
  etiquetas: IEtiqueta[] = [];
  errorMessage: string;

  constructor(private etiquetaService: EtiquetaService) { }

  ngOnInit() : void {
    this.etiquetaService.getEtiquetas().subscribe(
      etiquetas =>{
        this.etiquetas = etiquetas;
      },
      error => this.errorMessage = <any>error   
    );
  }
}
