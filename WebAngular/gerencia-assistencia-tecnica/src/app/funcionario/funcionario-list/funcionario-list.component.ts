import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/notification.service';
import { DialogService } from 'src/app/shared/dialog.service';
import { IFuncionario } from '../funcionario';
import { FuncionarioDetailComponent } from '../funcionario-detail/funcionario-detail.component';
import { FuncionarioService } from 'src/app/shared/funcionario.service';

@Component({
    selector: 'funcionario-list',
    templateUrl: './funcionario-list.component.html',
    styleUrls: ['./funcionario-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class FuncionarioListComponent implements OnInit {

  constructor(
    private service: FuncionarioService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private dialogService: DialogService
  ) { }

  funcionarios: IFuncionario[];
  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['nome', 'sobrenome', 'cpf', 'rg', 'email', 'actions'];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  searchKey: string;
  tela: string = "Funcionário";

  ngOnInit() {
    this.getFuncionarios();    
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

    let dialogRef = this.dialog.open(FuncionarioDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getFuncionarios();
    });    
  }

  onEdit(row){
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "800px";
    dialogConfig.height = "600px";    
    
    let dialogRef = this.dialog.open(FuncionarioDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getFuncionarios();
    });
  }

  onDelete(id){
    this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
    .afterClosed().subscribe(res =>{
       if(res){
          this.service.deleteFuncionario(id)
          .subscribe(result => {
          this.notificationService.warn('Excluído com sucesso!');
          this.getFuncionarios();
        }, error => {
          this.notificationService.warn('Não foi possível excluir este registro');
        });    
       }
     });
   }

   public getFuncionarios():void{
    this.service.getFuncionarios().subscribe(
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
            celular : item.celular            
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
