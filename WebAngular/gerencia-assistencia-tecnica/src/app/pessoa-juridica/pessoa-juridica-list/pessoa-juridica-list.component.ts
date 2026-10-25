import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DialogService } from 'src/app/shared/dialog.service';
import { PessoaJuridicaDetailComponent } from '../pessoa-juridica-detail/pessoa-juridica-detail.component';
import { PessoaJuridicaService } from 'src/app/shared/pessoa-juridica-service';

@Component({
    selector: 'app-pessoa-juridica-list',
    templateUrl: './pessoa-juridica-list.component.html',
    styleUrls: ['./pessoa-juridica-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class PessoaJuridicaListComponent implements OnInit {

  constructor(
    private service: PessoaJuridicaService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService
  ) { }

  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['razaoSocial', 'nomeFantasia', 'cnpj', 'email', 'actions'];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  searchKey: string;
  tela: string = "Pessoa Jurídica";

  ngOnInit() {
    this.getPessoaJuridicas();
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

    let dialogRef = this.dialog.open(PessoaJuridicaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getPessoaJuridicas();
    });    
  }

  onEdit(row){
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "800px";
    dialogConfig.height = "600px";    
    
    let dialogRef = this.dialog.open(PessoaJuridicaDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getPessoaJuridicas();
    });
  }

  onDelete(id){
    this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
    .afterClosed().subscribe(res =>{
       if(res){
          this.service.deletePessoaJuridica(id)
          .subscribe(result => {
          this.notificationService.warn('Excluído com sucesso!');
          this.getPessoaJuridicas();
        });    
       }
     });
   }

   public getPessoaJuridicas():void{
    this.service.getPessoaJuridicas().subscribe(
      list => {
        let array = list.map(item => {          
          return {
            id: item.id,
            razaoSocial: item.razaoSocial,
            nomeFantasia: item.nomeFantasia,
            cnpj: item.cnpj,
            ie: item.ie,
            email: item.email,            
            telefone : item.telefone,
            celular : item.celular,
            rua : item.rua,
            bairro : item.bairro,
            numero : item.numero,
            cep : item.cep,
            cidadeId : item.cidadeId,
            estadoId : item.estadoId,
            clienteId : item.clienteId,
            enderecoId : item.enderecoId,            
            regimeTributarioId : item.regimeTributarioId
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
