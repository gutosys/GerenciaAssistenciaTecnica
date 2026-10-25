import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from '../../shared/notification.service';
import { ProblemaService } from '../../shared/problema.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DialogService } from '../../shared/dialog.service';
import { IProblema } from '../problema';
import { ProblemaDetailComponent } from '../problema-detail/problema-detail.component';

@Component({
    selector: 'app-problema-list',
    templateUrl: './problema-list.component.html',
    styleUrls: ['./problema-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ProblemaListComponent implements OnInit {

  constructor(private service: ProblemaService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

    categorias: IProblema[];
    listData: MatTableDataSource<any>;
    displayedColumns: string[] = ['descricao', 'actions'];
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    searchKey: string;
    tela: string = "Problema";
  
  ngOnInit() {
    this.getProblemas();    
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
    
    let dialogRef = this.dialog.open(ProblemaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getProblemas();
    });    
  }

  onEdit(row){
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "600px";
    
    let dialogRef = this.dialog.open(ProblemaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getProblemas();
    });
  }

  onDelete(id){
   this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
   .afterClosed().subscribe(res =>{
      if(res){
         this.service.deleteProblema(id)
         .subscribe(result => {
         this.notificationService.warn('Excluído com sucesso!');
         this.getProblemas();
       });    
      }
    });
  }

  public getProblemas():void{
    this.service.getProblemas().subscribe(
      list => {
        let array = list.map(item => {          
          return {
            id: item.id,
            descricao: item.descricao     
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
