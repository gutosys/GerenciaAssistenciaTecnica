import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ComprovanteCompraService } from '../shared/comprovante-compra.service';

@Component({
    selector: 'app-comprovante-compra',
    templateUrl: './comprovante-compra.component.html',
    styleUrls: ['./comprovante-compra.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ComprovanteCompraComponent implements OnInit {
  comprovanteCompras: IComprovanteCompra[] = [];
  errorMessage: string;

  constructor(private comprovanteCompraService: ComprovanteCompraService) { }

  ngOnInit() : void {
    this.comprovanteCompraService.getComprovanteCompras().subscribe(
      comprovanteCompras =>{
        this.comprovanteCompras = comprovanteCompras;
      },
      error => this.errorMessage = <any>error   
    );
  }
}
