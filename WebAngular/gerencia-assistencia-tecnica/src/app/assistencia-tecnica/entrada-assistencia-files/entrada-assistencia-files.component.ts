import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Input } from '@angular/core';
import { DialogService } from 'src/app/shared/dialog.service';
import { EntradaAssistenciaService } from 'src/app/shared/entrada-assistencia.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-entrada-assistencia-files',
    templateUrl: './entrada-assistencia-files.component.html',
    styleUrls: ['./entrada-assistencia-files.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EntradaAssistenciaFilesComponent implements OnInit {
  @Input() files;
  @Output() notify = new EventEmitter<number>();

  constructor(private dialogService: DialogService,
              private service: EntradaAssistenciaService,
              private notificationService: NotificationService) { }

  ngOnInit() {
  }


  buttonRemoveFile(id){    
    this.dialogService.openConfirmDialog('Você tem certeza que deseja excluir este documento ?')
   .afterClosed().subscribe(res =>{
      if(res){         
        
      this.service.deleteDocumento(id)
          .subscribe(result => {
          this.notify.emit(id);
          this.notificationService.warn('Excluído com sucesso!');
          //this.getCategorias();
        });    
      }
    });
  }
}
