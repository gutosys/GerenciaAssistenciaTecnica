import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { EntreguePorService } from '../shared/entregue-por.service';

@Component({
    selector: 'app-entregue-por',
    templateUrl: './entregue-por.component.html',
    styleUrls: ['./entregue-por.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EntreguePorComponent implements OnInit {
  entreguePor: IEntreguePor[] = [];
  errorMessage: string;

  constructor(private entreguePorService: EntreguePorService) { }

  ngOnInit() : void {
    this.entreguePorService.getEntreguePorList().subscribe(
      entreguePor =>{
        this.entreguePor = entreguePor;
      },
      error => this.errorMessage = <any>error   
    );
  }

}
