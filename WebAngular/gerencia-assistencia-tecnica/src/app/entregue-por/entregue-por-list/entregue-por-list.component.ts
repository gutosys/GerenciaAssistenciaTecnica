import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/notification.service';
import { DialogService } from 'src/app/shared/dialog.service';
import { EntreguePorDetailComponent } from '../entregue-por-detail/entregue-por-detail.component';
import { EntreguePorService } from 'src/app/shared/entregue-por.service';

@Component({
    selector: 'app-entregue-por-list',
    templateUrl: './entregue-por-list.component.html',
    styleUrls: ['./entregue-por-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EntreguePorListComponent implements OnInit {

  constructor(private service: EntreguePorService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

    entreguePor: IEntreguePor[];
    listData: MatTableDataSource<any>;
    displayedColumns: string[] = [ 'descricao', 'actions'];
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    searchKey: string;
    tela: string = "Entregue Por";

    ngOnInit() {
      this.getEntreguePorList();    
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
      dialogConfig.width = "590px"; 
      dialogConfig.height = "245px"; 
  
      let dialogRef = this.dialog.open(EntreguePorDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getEntreguePorList();
      });    
    }

    onEdit(row){

      delete row.colorHex;

      this.service.populateForm(row);
      const dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = true;
      dialogConfig.autoFocus = true;
      dialogConfig.width = "590px"; 
      dialogConfig.height = "245px";
      
      let dialogRef = this.dialog.open(EntreguePorDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getEntreguePorList();
      });
    }
  
    onDelete(id){
     this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
     .afterClosed().subscribe(res =>{
        if(res){
           this.service.deleteEntreguePor(id)
           .subscribe(result => {
           this.notificationService.warn('Excluído com sucesso!');
           this.getEntreguePorList();
         });    
        }
      });
    }

    public getEntreguePorList():void{
      this.service.getEntreguePorList().subscribe(
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
