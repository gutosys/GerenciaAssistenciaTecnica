import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/notification.service';
import { DialogService } from 'src/app/shared/dialog.service';
import { EntradaAssistenciaService } from 'src/app/shared/entrada-assistencia.service';
import { IEntradaAssistencia } from '../entrada-assistencia';
import { EntradaAssistenciaDetailComponent } from '../entrada-assistencia-detail/entrada-assistencia-detail.component';


@Component({
    selector: 'app-entrada-assistencia-list',
    templateUrl: './entrada-assistencia-list.component.html',
    styleUrls: ['./entrada-assistencia-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EntradaAssistenciaListComponent implements OnInit {

  constructor(private service: EntradaAssistenciaService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

  entradaAssistencias: IEntradaAssistencia[] = [];
  errorMessage: string;
  tela: string = "Entrada Assistência Técnica";
  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['nome', 'ns', 'maquinaDesc', 'funcionarioDesc','actions'];
  // displayedColumns: string[] = ['nome', 'funcionario', 'maquina', 'nf', 'numeroSerie', 'actions'];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  searchKey: string;


  ngOnInit() {
    this.getEntradaAssistencias();
  }

  onSearchClear() {
    this.searchKey = "";
    this.applyFilter();
  }

  applyFilter() {
    this.listData.filter = this.searchKey.trim().toLowerCase();
  }

  onCreate() {
    this.service.initializeFormGroup();
    const dialogConfig = new MatDialogConfig();

    let dialogRef = this.dialog.open(EntradaAssistenciaDetailComponent, {
      disableClose: true,
      autoFocus: true,
      width: "855px",
      height: "90%",
      panelClass: "dialogCustom",
      data: {
        id: null,
        acessoBotoes: true
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getEntradaAssistencias();
    });
  }

  onEdit(row) {
    //this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "850px";
    dialogConfig.height= "90%"; 
    dialogConfig.panelClass = "dialogCustom"    

    let dialogRef = this.dialog.open(EntradaAssistenciaDetailComponent, {
    disableClose: true,
    autoFocus: true,
    width: "850px",
    height:"90%",
    panelClass: "dialogCustom",
    data: {
      id: row.id,
      acessoBotoes: true
    }
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getEntradaAssistenciasOnEdit();
    });
  }

  onDelete(id) {
    this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
      .afterClosed().subscribe(res => {
        if (res) {
          this.service.deleteEntradaAssistencia(id)
            .subscribe(result => {
              this.notificationService.warn('Excluído com sucesso!');
              this.getEntradaAssistencias();
            });
        }
      });
  }

  public getEntradaAssistencias(): void {
    this.service.getEntradaAssistencias().subscribe(
      list => {
        let array = list.map(item => {
          return {
            id: item.id,
            nome: item.nome,
            ns: item.ns,
            maquinaDesc: item.maquinaDesc,
            funcionarioDesc: item.funcionarioDesc
            // pessoaFisicaId: item.pessoaFisicaId,
            // pessoaJuridicaId: item.pessoaJuridicaId,
            // funcionarioId: item.funcionarioId,
            // numeroNF: item.numeroNF,
            // maquinaId: item.maquinaId,
            // numeroSerie: item.numeroSerie,
            // acessorioList: item.acessorioList
          };
        });

        this.listData = new MatTableDataSource(array);
        this.listData.sort = this.sort;
        this.listData.paginator = this.paginator;
        this.listData.filterPredicate = (data, filter) => {
          return this.displayedColumns.some(ele => {
            return ele != 'actions' && data[ele].toLowerCase().indexOf(filter) != -1;
          });
        };
      });
  }


  public getEntradaAssistenciasOnEdit(): void {
    this.service.getEntradaAssistencias().subscribe(
      list => {
        let array = list.map(item => {
          return {
            id: item.id,
            nome: item.nome,
            maquinaDesc: item.maquinaDesc,
            funcionarioDesc: item.funcionarioDesc,
            pessoaFisicaId: item.pessoaFisicaId,
            pessoaJuridicaId: item.pessoaJuridicaId,
            funcionarioId: item.funcionarioId,
            numeroNF: item.numeroNF,
            maquinaId: item.maquinaId,
            numeroSerie: item.numeroSerie,
            acessorioList: item.acessorioList
          };
        });

        this.listData = new MatTableDataSource(array);
        this.listData.sort = this.sort;
        this.listData.paginator = this.paginator;
        this.listData.filterPredicate = (data, filter) => {
          return this.displayedColumns.some(ele => {
            return ele != 'actions' && data[ele].toLowerCase().indexOf(filter) != -1;
          });
        };
      });
  }


}
