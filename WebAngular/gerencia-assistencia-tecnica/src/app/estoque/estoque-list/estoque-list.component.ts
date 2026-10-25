import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/notification.service';
import { DialogService } from 'src/app/shared/dialog.service';
import { EstoqueDetailComponent } from '../estoque-detail/estoque-detail.component';
import { EstoqueService } from 'src/app/shared/estoque.service';

@Component({
    selector: 'app-estoque-list',
    templateUrl: './estoque-list.component.html',
    styleUrls: ['./estoque-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EstoqueListComponent implements OnInit {

  constructor(private service: EstoqueService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

    estoques: IEstoque[];
    listData: MatTableDataSource<any>;
    displayedColumns: string[] = ['componenteDes', 'quantidade', 'quantidadeMinima', 'actions'];
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    searchKey: string;
    tela: string = "Estoque";
 
    ngOnInit() {
      this.getEstoques();    
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
      dialogConfig.height = "330px";  
  
      let dialogRef = this.dialog.open(EstoqueDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getEstoques();
      });    
    }

    onEdit(row){
      this.service.populateForm(row);
      const dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = true;
      dialogConfig.autoFocus = true;
      dialogConfig.width = "800px";
      dialogConfig.height = "330px";    
      
      let dialogRef = this.dialog.open(EstoqueDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getEstoques();
      });
    }
  
    onDelete(id){
     this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
     .afterClosed().subscribe(res =>{
        if(res){
           this.service.deleteEstoque(id)
           .subscribe(result => {
           this.notificationService.warn('Excluído com sucesso!');
           this.getEstoques();
         });    
        }
      });
    }

    public getEstoques():void{
      this.service.getEstoques().subscribe(
        list => {
          let array = list.map(item => {          
            return {
              id: item.id,
              componenteId: item.componenteId,
              componenteDes:  item.componenteDes,
              quantidade: item.quantidade,
              quantidadeMinima: item.quantidadeMinima
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
