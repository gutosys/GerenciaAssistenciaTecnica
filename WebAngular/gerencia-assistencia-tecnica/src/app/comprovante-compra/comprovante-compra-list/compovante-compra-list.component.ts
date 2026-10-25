import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from '../../shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DialogService } from '../../shared/dialog.service';
import { ComprovanteCompraDetailComponent } from '../comprovante-compra-detail/comprovante-compra-detail.component';
import { ComprovanteCompraService } from '../../shared/comprovante-compra.service';

@Component({
    selector: 'app-comprovante-compra-list',
    templateUrl: './comprovante-compra-list.component.html',
    styleUrls: ['./comprovante-compra-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ComprovanteCompraListComponent implements OnInit {

  constructor(private service: ComprovanteCompraService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

    comprovanteCompras: IComprovanteCompra[];
    listData: MatTableDataSource<any>;
    displayedColumns: string[] = [ 'descricao', 'actions'];
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    searchKey: string;
    tela: string = "Comprovante de Compra";

    ngOnInit() {
      this.getComprovanteCompras();    
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
  
      let dialogRef = this.dialog.open(ComprovanteCompraDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getComprovanteCompras();
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
      
      let dialogRef = this.dialog.open(ComprovanteCompraDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getComprovanteCompras();
      });
    }
  
    onDelete(id){
     this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
     .afterClosed().subscribe(res =>{
        if(res){
           this.service.deleteComprovanteCompra(id)
           .subscribe(result => {
           this.notificationService.warn('Excluído com sucesso!');
           this.getComprovanteCompras();
         });    
        }
      });
    }

    public getComprovanteCompras():void{
      this.service.getComprovanteCompras().subscribe(
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
