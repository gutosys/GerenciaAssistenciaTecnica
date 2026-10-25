import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IAcessorio } from '../acessorio';
import { DialogService } from 'src/app/shared/dialog.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { AcessorioService } from 'src/app/shared/acessorio.service';
import { AcessorioDetailComponent } from '../acessorio-detail/acessorio-detail.component';

@Component({
    selector: 'app-acessorio-list',
    templateUrl: './acessorio-list.component.html',
    styleUrls: ['./acessorio-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class AcessorioListComponent implements OnInit {  
  constructor(private service: AcessorioService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

    acessorios: IAcessorio[];
    listData: MatTableDataSource<any>;
    displayedColumns: string[] = ['descricao', 'actions'];
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    searchKey: string;
    tela: string = "Acessórios";

    ngOnInit() {
      this.getAcessorios();    
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
      
      let dialogRef = this.dialog.open(AcessorioDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getAcessorios();
      });    
    }

    onEdit(row){
      this.service.populateForm(row);
      const dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = true;
      dialogConfig.autoFocus = true;
      dialogConfig.width = "600px";
      
      let dialogRef = this.dialog.open(AcessorioDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getAcessorios();
      });
    }

    onDelete(id){
     this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
     .afterClosed().subscribe(res =>{
        if(res){
           this.service.deleteAcessorio(id)
           .subscribe(result => {
           this.notificationService.warn('Excluído com sucesso!');
           this.getAcessorios();
         }, error => {
          this.notificationService.warn('Não foi possível excluir este registro');
        });    
        }
      });
    }
  
    public getAcessorios():void{
      this.service.getAcessorios().subscribe(
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
