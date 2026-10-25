import { Component, OnInit, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { RegimeTributarioService } from 'src/app/shared/regime-tributario.service';
import { IRegimeTributario } from '../regime-tributario';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/notification.service';
import { DialogService } from 'src/app/shared/dialog.service';
import { RegimeTributarioDetailComponent } from '../regime-tributario-detail/regime-tributario-detail.component';

@Component({
    selector: 'app-regime-tributario-list',
    templateUrl: './regime-tributario-list.component.html',
    styleUrls: ['./regime-tributario-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class RegimeTributarioListComponent implements OnInit {
  constructor(private service: RegimeTributarioService,
              private notificationService: NotificationService,
              private dialog: MatDialog,
              private dialogService: DialogService) { }
  
  regimeTributarios: IRegimeTributario[];
  listData: MatTableDataSource<any>;
  displayedColumns: string[] = ['descricao', 'actions'];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  searchKey: string;
  tela: string = "Regime Tributário";

  ngOnInit() {
    this.getRegimeTributarios();    
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
    
    let dialogRef = this.dialog.open(RegimeTributarioDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getRegimeTributarios();
    });    
  }

  onEdit(row){
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "600px";
    
    let dialogRef = this.dialog.open(RegimeTributarioDetailComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getRegimeTributarios();
    });
  }

  onDelete(id){
   this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este registro ?')
   .afterClosed().subscribe(res =>{
      if(res){
         this.service.deleteRegimeTributario(id)
         .subscribe(result => {
         this.notificationService.warn('Excluído com sucesso!');
         this.getRegimeTributarios();
       });    
      }
    });
  }

  public getRegimeTributarios():void{
    this.service.getRegimeTributarios().subscribe(
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
