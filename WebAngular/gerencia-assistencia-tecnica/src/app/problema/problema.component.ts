import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { IProblema } from './problema';
import { ProblemaService } from '../shared/problema.service';

@Component({
    selector: 'app-problema',
    templateUrl: './problema.component.html',
    styleUrls: ['./problema.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ProblemaComponent implements OnInit {
  problemas: IProblema[] = [];
  errorMessage: string;

  constructor(private problemaService: ProblemaService) { }

  ngOnInit(): void {
    this.problemaService.getProblemas().subscribe(
      problemas =>{
        this.problemas = problemas;
      },
      error => this.errorMessage = <any>error   
    );
  }

}
