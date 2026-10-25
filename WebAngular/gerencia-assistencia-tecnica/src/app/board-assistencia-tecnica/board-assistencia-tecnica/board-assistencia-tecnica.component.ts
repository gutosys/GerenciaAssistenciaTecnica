import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { moveItemInArray, transferArrayItem, CdkDragDrop } from '@angular/cdk/drag-drop';
import { EntradaAssistenciaService } from '../../shared/entrada-assistencia.service';
import { IEntradaAssistencia } from '../../assistencia-tecnica/entrada-assistencia';
import { EntradaAssistenciaDetailComponent } from '../../assistencia-tecnica/entrada-assistencia-detail/entrada-assistencia-detail.component';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { SecurityService } from '../../security/security.service';
import { AppUserAuth } from '../../security/app-user-auth';

export interface Character {
  name: string;
  image: string;
  fatality: string;
}

@Component({
    selector: 'board-assistencia-tecnica',
    templateUrl: './board-assistencia-tecnica.component.html',
    styleUrls: ['./board-assistencia-tecnica.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})

export class BoardAssistenciaTecnicaComponent implements OnInit {
  entradaList: IEntradaBoardList[];
  emManutencaoList: IEntradaBoardList[] = [];
  saidaList: IEntradaBoardList[] = [];
  securityObject: AppUserAuth = null;

  constructor(private httpClient: HttpClient,
    private service: EntradaAssistenciaService,
    private dialog: MatDialog,
    private securityService: SecurityService) {
    this.getEntradaAssistenciaList()
    this.securityObject = securityService.securityObject;
  }

  getEntradaAssistenciaList() {
    this.service.getEntradaAssistencias().subscribe(
      list => {
        this.entradaList = list.map(item => {
          return {
            id: item.id,
            nome: item.nome,
            numeroNF: item.numeroNF,
            maquinaDesc: item.maquinaDesc,
            numeroSerie: item.numeroSerie,
            entradaAssistenciaStatusId: item.entradaAssistenciaStatusId            
          };
        });
      });
  }

  drop(event: CdkDragDrop<IEntradaBoardList[]>) {

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

  openVisualizarEntradaAssistencia(id: number) {
    //this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "850px";
    dialogConfig.height = "90%";
    dialogConfig.panelClass = "dialogCustom"

    let dialogRef = this.dialog.open(EntradaAssistenciaDetailComponent, {
      disableClose: true,
      autoFocus: true,
      width: "850px",
      height: "90%",
      panelClass: "dialogCustom",
      data: {
        id: id,
        acessoBotoes: false
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      //this.getEntradaAssistenciasOnEdit();
      //SE PRECISAR FAZER ALGO APOS FECHAR
    });
  }
}

export interface IEntradaBoardList {
  id: number,
  nome: string,
  numeroNF: string,
  maquinaDesc: string,
  numeroSerie: string,
  entradaAssistenciaStatusId: number
}