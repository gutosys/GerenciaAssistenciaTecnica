import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ClienteAssociadoDetailComponent } from '../cliente-associado-detail/cliente-associado-detail.component';
import { DialogService } from '../../shared/dialog.service';
import { NotificationService } from '../../shared/notification.service';
import { ClienteAssociadoService } from '../../shared/cliente-associado.service';

@Component({
    selector: 'app-cliente-associado-list',
    templateUrl: './cliente-associado-list.component.html',
    styleUrls: ['./cliente-associado-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ClienteAssociadoListComponent implements OnInit {
  constructor(private service: ClienteAssociadoService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

    categorias: IClienteAssociado[];
    listData: MatTableDataSource<any>;
    displayedColumns: string[] = ['nome', 'telefone', 'pessoaJuridicaDes','actions'];
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    searchKey: string;
    tela: string = "Cliente Associado";
  
  ngOnInit() {
    this.getClienteAssociados();    
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
    dialogConfig.height = "300px";
    
    let dialogRef = this.dialog.open(ClienteAssociadoDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getClienteAssociados();
    });    
  }

  onEdit(row){
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "600px";
    dialogConfig.height = "300px";
    
    let dialogRef = this.dialog.open(ClienteAssociadoDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getClienteAssociados();
    });
  }

  onDelete(id){
   this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
   .afterClosed().subscribe(res =>{
      if(res){
         this.service.deleteClienteAssociado(id)
         .subscribe(result => {
         this.notificationService.warn('Excluído com sucesso!');
         this.getClienteAssociados();
       });    
      }
    });
  }

  public getClienteAssociados():void{
    this.service.getClientesAssociados().subscribe(
      list => {
        let array = list.map(item => {          
          return {
            id: item.id,
            nome: item.nome,
            telefone: item.telefone,
            pessoaJuridicaId: item.pessoaJuridicaId,
            pessoaJuridicaDes: item.pessoaJuridicaDes
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
