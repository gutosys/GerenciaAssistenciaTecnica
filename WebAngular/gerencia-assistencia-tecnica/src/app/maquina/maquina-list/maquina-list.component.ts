import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { IMaquina } from '../maquina';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/notification.service';
import { DialogService } from 'src/app/shared/dialog.service';
import { MaquinaDetailComponent } from '../maquina-detail/maquina-detail.component';
import { MaquinaService } from 'src/app/shared/maquina.service';

@Component({
    selector: 'app-maquina-list',
    templateUrl: './maquina-list.component.html',
    styleUrls: ['./maquina-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class MaquinaListComponent implements OnInit {
  constructor(private service: MaquinaService,
              private notificationService: NotificationService,
              private dialog: MatDialog,
              private dialogService: DialogService) { }
  
  maquinas: IMaquina[];
  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['descricao', 'modelo','actions'];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  searchKey: string;
  tela: string = "Máquina";

  ngOnInit() {
    this.getMaquinas();    
  }

  onSearchClear() {
    this.searchKey = "";
    this.applyFilter();
  }

  applyFilter() {
    this.listData.filter = this.searchKey.trim().toLowerCase();
  }

  onCreate(){
    this.service.initializeFormGroup();
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "600px";
    
    let dialogRef = this.dialog.open(MaquinaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getMaquinas();
    });    
  }

  onEdit(row){
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "600px";
    
    let dialogRef = this.dialog.open(MaquinaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getMaquinas();
    });
  }

  onDelete(id){
   this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
   .afterClosed().subscribe(res =>{
      if(res){
         this.service.deleteMaquina(id)
         .subscribe(result => {
         this.notificationService.warn('Excluído com sucesso!');
         this.getMaquinas();
       });    
      }
    });
  }

  public getMaquinas():void{
    this.service.getMaquinas().subscribe(
      list => {
        let array = list.map(item => {          
          return {
            id: item.id,
            descricao: item.descricao,
            modelo: item.modelo
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

