import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ClienteAssociadoService } from '../shared/cliente-associado.service';

@Component({
    selector: 'app-cliente-associado',
    templateUrl: './cliente-associado.component.html',
    styleUrls: ['./cliente-associado.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ClienteAssociadoComponent implements OnInit {
  clienteAssociados: IClienteAssociado[] = [];
  errorMessage: string;

  constructor(private clienteAssociadoService: ClienteAssociadoService) { }

  ngOnInit() : void {
    this.clienteAssociadoService.getClientesAssociados().subscribe(
      estoques =>{
        this.clienteAssociados = this.clienteAssociados;
      },
      error => this.errorMessage = <any>error   
    );
  }
}
