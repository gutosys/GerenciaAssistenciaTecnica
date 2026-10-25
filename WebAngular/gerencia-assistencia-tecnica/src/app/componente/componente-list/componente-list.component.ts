import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/notification.service';
import { DialogService } from 'src/app/shared/dialog.service';
import { ComponenteService } from 'src/app/shared/componente.service';
import { ComponenteDetailComponent } from '../componente-detail/componente-detail.component';


@Component({
    selector: 'app-componente-list',
    templateUrl: './componente-list.component.html',
    styleUrls: ['./componente-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})

export class ComponenteListComponent implements OnInit {

  constructor(private service: ComponenteService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

    componentes: IComponente[];
    listData: MatTableDataSource<any>;
    displayedColumns: string[] = ['nome', 'descricao', 'precoCompra', 'precoVenda', 'precoVendaAutorizada', 'actions'];
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    searchKey: string;
    tela: string = "Componente";
  
    ngOnInit() {
      this.getComponentes();    
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
      dialogConfig.height = "410px";  
  
      let dialogRef = this.dialog.open(ComponenteDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getComponentes();
      });    
    }
  
    onEdit(row){
      this.service.populateForm(row);
      const dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = true;
      dialogConfig.autoFocus = true;
      dialogConfig.width = "800px";
      dialogConfig.height = "410px";     
      
      let dialogRef = this.dialog.open(ComponenteDetailComponent, dialogConfig);
      dialogRef.afterClosed().subscribe(result => {
        this.getComponentes();
      });
    }
  
    onDelete(id){
     this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
     .afterClosed().subscribe(res =>{
        if(res){
           this.service.deleteComponente(id)
           .subscribe(result => {
           this.notificationService.warn('Excluído com sucesso!');
           this.getComponentes();
         });    
        }
      });
    }
  
    public getComponentes():void{
      this.service.getComponentes().subscribe(
        list => {
          let array = list.map(item => {          
            return {
              id: item.id,
              nome: item.nome,
              descricao: item.descricao,
              precoCompra: item.precoCompra,
              precoVenda: item.precoVenda, 
              precoVendaAutorizada: item.precoVendaAutorizada              
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
