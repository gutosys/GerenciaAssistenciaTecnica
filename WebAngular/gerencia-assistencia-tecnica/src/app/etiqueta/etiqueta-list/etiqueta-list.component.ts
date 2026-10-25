import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EtiquetaDetailComponent } from '../etiqueta-detail/etiqueta-detail.component';
import { DialogService } from '../../shared/dialog.service';
import { NotificationService } from '../../shared/notification.service';
import { EtiquetaService } from '../../shared/etiqueta.service';

@Component({
    selector: 'app-etiqueta-list',
    templateUrl: './etiqueta-list.component.html',
    styleUrls: ['./etiqueta-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EtiquetaListComponent implements OnInit {

  constructor(private service: EtiquetaService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

    estoques: IEstoque[];
    listData: MatTableDataSource<any>;
    displayedColumns: string[] = [ 'descricao', 'colorHex', 'actions'];
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    searchKey: string;
    tela: string = "Etiqueta";
 
    ngOnInit() {
      this.getEtiquetas();    
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
      dialogConfig.width = "800px"; 
      dialogConfig.height = "600px";  
  
      let dialogRef = this.dialog.open(EtiquetaDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getEtiquetas();
      });    
    }

    onEdit(row){

      delete row.colorHex;

      this.service.populateForm(row);
      const dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = true;
      dialogConfig.autoFocus = true;
      dialogConfig.width = "800px";
      dialogConfig.height = "600px";    
      
      let dialogRef = this.dialog.open(EtiquetaDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getEtiquetas();
      });
    }
  
    onDelete(id){
     this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
     .afterClosed().subscribe(res =>{
        if(res){
           this.service.deleteEtiqueta(id)
           .subscribe(result => {
           this.notificationService.warn('Excluído com sucesso!');
           this.getEtiquetas();
         });    
        }
      });
    }

    public getEtiquetas():void{
      this.service.getEtiquetas().subscribe(
        list => {
          let array = list.map(item => {          
            return {
              id: item.id,
              descricao: item.descricao,
              corId: item.corId,
              corDes:  item.corDes,
              colorHex: item.colorHex          
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
