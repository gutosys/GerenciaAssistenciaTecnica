import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { moveItemInArray, transferArrayItem, CdkDragDrop } from '@angular/cdk/drag-drop';
import { EntradaAssistenciaService } from '../../shared/entrada-assistencia.service';
import { EntradaAssistenciaDetailComponent } from '../../assistencia-tecnica/entrada-assistencia-detail/entrada-assistencia-detail.component';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { SecurityService } from '../../security/security.service';
import { AppUserAuth } from '../../security/app-user-auth';
import { NotificationService } from '../../shared/notification.service';

enum EntradaAssistenciaStatus {
  Entrada = 1,
  EmManutencao = 2,
  AguardandoSaida = 4
}

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
  entradaList: IEntradaBoardList[] = [];
  emManutencaoList: IEntradaBoardList[] = [];
  saidaList: IEntradaBoardList[] = [];
  private updatingIds = new Set<number>();
  securityObject: AppUserAuth = null;

  constructor(private service: EntradaAssistenciaService,
    private dialog: MatDialog,
    private securityService: SecurityService,
    private notificationService: NotificationService) {
    this.getEntradaAssistenciaList()
    this.securityObject = securityService.securityObject;
  }

  getEntradaAssistenciaList() {
    this.service.getBoardEntradas().subscribe(
      list => {
        this.entradaList = [];
        this.emManutencaoList = [];
        this.saidaList = [];

        list.forEach(item => {
          const boardItem = {
            id: item.id,
            nome: item.nome,
            numeroNF: item.numeroNF,
            maquinaDesc: item.maquinaDesc,
            numeroSerie: item.numeroSerie,
            entradaAssistenciaStatusId: item.entradaAssistenciaStatusId
          };

          switch (boardItem.entradaAssistenciaStatusId) {
            case EntradaAssistenciaStatus.Entrada:
              this.entradaList.push(boardItem);
              break;
            case EntradaAssistenciaStatus.EmManutencao:
              this.emManutencaoList.push(boardItem);
              break;
            case EntradaAssistenciaStatus.AguardandoSaida:
              this.saidaList.push(boardItem);
              break;
          }
        });
      },
      () => this.notificationService.warn('Nao foi possivel carregar os itens do Board.')
    );
  }

  drop(event: CdkDragDrop<IEntradaBoardList[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
      return;
    }

    const item = event.previousContainer.data[event.previousIndex];
    const newStatusId = this.getStatusId(event.container.data);
    this.updatingIds.add(item.id);

    this.service.updateEntradaAssistenciaStatus(item.id, newStatusId).subscribe(
      () => {
        const previousIndex = event.previousContainer.data.findIndex(candidate => candidate.id === item.id);
        const currentIndex = Math.min(event.currentIndex, event.container.data.length);
        transferArrayItem(
          event.previousContainer.data,
          event.container.data,
          previousIndex,
          currentIndex
        );
        item.entradaAssistenciaStatusId = newStatusId;
        this.updatingIds.delete(item.id);
      },
      () => {
        this.updatingIds.delete(item.id);
        this.notificationService.warn('Nao foi possivel atualizar o status. O item permaneceu na coluna atual.');
      }
    );
  }

  isUpdating(id: number): boolean {
    return this.updatingIds.has(id);
  }

  private getStatusId(list: IEntradaBoardList[]): number {
    if (list === this.entradaList) {
      return EntradaAssistenciaStatus.Entrada;
    }

    if (list === this.emManutencaoList) {
      return EntradaAssistenciaStatus.EmManutencao;
    }

    return EntradaAssistenciaStatus.AguardandoSaida;
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