import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { EstoqueService } from '../shared/estoque.service';

@Component({
    selector: 'app-estoque',
    templateUrl: './estoque.component.html',
    styleUrls: ['./estoque.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EstoqueComponent implements OnInit {
  estoques: IEstoque[] = [];
  errorMessage: string;

  constructor(private estoqueService: EstoqueService) { }

  ngOnInit() : void {
    this.estoqueService.getEstoques().subscribe(
      estoques =>{
        this.estoques = estoques;
      },
      error => this.errorMessage = <any>error   
    );
  }
}
