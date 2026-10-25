import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ICategoria } from './categoria';
import { CategoriaService } from '../shared/categoria.service';

@Component({
    // selector: 'app-categoria',
    templateUrl: './categoria.component.html',
    styleUrls: ['./categoria.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class CategoriaComponent implements OnInit {
  categorias: ICategoria[] = [];
  errorMessage: string;


  constructor(private categoriaService: CategoriaService) { }

  ngOnInit(): void {
    this.categoriaService.getCategorias().subscribe(
      categorias =>{
        this.categorias = categorias;
      },
      error => this.errorMessage = <any>error   
    );
  }
}
