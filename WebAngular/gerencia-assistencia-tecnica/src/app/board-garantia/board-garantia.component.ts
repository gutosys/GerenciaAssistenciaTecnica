import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { moveItemInArray, transferArrayItem, CdkDragDrop } from '@angular/cdk/drag-drop';

export interface Character {
  name: string;
  image: string;
  fatality: string;
 }

@Component({
    selector: 'app-board-garantia',
    templateUrl: './board-garantia.component.html',
    styleUrls: ['./board-garantia.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class BoardGarantiaComponent implements OnInit {
  myList: Character[]
  confirmList: Character[] = [];
  saidaList: Character[] = [];


  constructor(private httpClient: HttpClient) { 
    this.getMyList()
  }

  getMyList() {
    this.httpClient.get<Character[]>("assets/data.json")
    .subscribe(list =>{
     this.myList = list;
    })
  }

  drop(event: CdkDragDrop<Character[]>) {  

    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
  
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }
  
    ngOnInit() {
    }
  
}
