import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { PessoaFisicaService } from 'src/app/shared/pessoa-fisica.service';
import { IPessoaFisica } from '../pessoa-fisica';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/notification.service';
import { DialogService } from 'src/app/shared/dialog.service';
import { PessoaFisicaDetailComponent } from '../pessoa-fisica-detail/pessoa-fisica-detail.component';

@Component({
    selector: 'app-pessoa-fisica-list',
    templateUrl: './pessoa-fisica-list.component.html',
    styleUrls: ['./pessoa-fisica-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})

export class PessoaFisicaListComponent implements OnInit {
  constructor(private service: PessoaFisicaService,
              private notificationService: NotificationService,
              private dialog: MatDialog,
              private dialogService: DialogService) { }
  
  tipoEmpresas: IPessoaFisica[];
  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['nome', 'sobrenome', 'cpf', 'rg', 'email', 'actions'];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  searchKey: string;
  tela: string = "Pessoa Física";

  ngOnInit() {
    this.getPessoaFisicas();    
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

    let dialogRef = this.dialog.open(PessoaFisicaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getPessoaFisicas();
    });    
  }

  onEdit(row){
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "800px";
    dialogConfig.height = "600px";    
    
    let dialogRef = this.dialog.open(PessoaFisicaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getPessoaFisicas();
    });
  }

  onDelete(id){
   this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
   .afterClosed().subscribe(res =>{
      if(res){
         this.service.deletePessoaFisica(id)
         .subscribe(result => {
         this.notificationService.warn('Excluído com sucesso!');
         this.getPessoaFisicas();
       });    
      }
    });
  }

  public getPessoaFisicas():void{
    this.service.getPessoaFisicas().subscribe(
      list => {
        let array = list.map(item => {          
          return {
            id: item.id,
            nome: item.nome,
            sobrenome: item.sobrenome,
            cpf: item.cpf,
            rg: item.rg, 
            email: item.email,            
            telefone : item.telefone,
            celular : item.celular,
            rua : item.rua,
            bairro : item.bairro,
            numero : item.numero,
            cep : item.cep,
            cidadeId : item.cidadeId,
            estadoId : item.estadoId,
            clienteId : item.clienteId            
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
