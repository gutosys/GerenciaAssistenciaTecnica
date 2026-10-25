import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { ICategoria } from '../categoria';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/notification.service';
import { DialogService } from 'src/app/shared/dialog.service';
import { CategoriaDetailComponent } from '../categoria-detail/categoria-detail.component';
import { CategoriaService } from 'src/app/shared/categoria.service';

@Component({
    selector: 'app-categoria-list',
    templateUrl: './categoria-list.component.html',
    styleUrls: ['./categoria-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class CategoriaListComponent implements OnInit {

  constructor(private service: CategoriaService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

    categorias: ICategoria[];
    listData: MatTableDataSource<any>;
    displayedColumns: string[] = ['descricao', 'actions'];
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    searchKey: string;
    tela: string = "Categoria";
  
  ngOnInit() {
    this.getCategorias();    
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
    
    let dialogRef = this.dialog.open(CategoriaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getCategorias();
    });    
  }

  onEdit(row){
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "600px";
    
    let dialogRef = this.dialog.open(CategoriaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getCategorias();
    });
  }

  onDelete(id){
   this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
   .afterClosed().subscribe(res =>{
      if(res){
         this.service.deleteCategoria(id)
         .subscribe(result => {
         this.notificationService.warn('Excluído com sucesso!');
         this.getCategorias();
       });    
      }
    });
  }

  public getCategorias():void{
    this.service.getCategorias().subscribe(
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
