import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { IRegimeTributario } from './regime-tributario';
import { RegimeTributarioService } from '../shared/regime-tributario.service';

@Component({
    selector: 'app-regime-tributario',
    templateUrl: './regime-tributario.component.html',
    styleUrls: ['./regime-tributario.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class RegimeTributarioComponent implements OnInit {
  regimeTributarios: IRegimeTributario[] = [];
  errorMessage: string;

  constructor(private regimeTributarioService: RegimeTributarioService) { }

  ngOnInit() {
    this.regimeTributarioService.getRegimeTributarios().subscribe(
      regimeTributarios =>{
        this.regimeTributarios = regimeTributarios;
      },
      error => this.errorMessage = <any>error   
    );
  }
}
