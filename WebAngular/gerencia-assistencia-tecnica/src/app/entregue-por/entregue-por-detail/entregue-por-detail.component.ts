import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { EntreguePorService } from 'src/app/shared/entregue-por.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Location } from '@angular/common';

@Component({
    selector: 'app-entregue-por-detail',
    templateUrl: './entregue-por-detail.component.html',
    styleUrls: ['./entregue-por-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})

export class EntreguePorDetailComponent implements OnInit {
  entreguePor: IEntreguePor;
  originalEntreguePor: IEntreguePor;
  tela: string = "Comprovante de Compra"

  constructor(private service: EntreguePorService,
    private location: Location,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<EntreguePorDetailComponent>) { }

    ngOnInit() {
    }
  
    onClear() {
      this.service.form.reset();
      this.service.initializeFormGroup();
    }
  
    onSubmit() {
      if (this.service.form.valid) {
        if (this.service.form.value.id) {
          // Update product
          this.service.updateEntreguePor(this.service.form.value)
            .subscribe(entreguePor => { this.entreguePor = this.service.form.value },
              () => null,
              () => this.dataSaved());
        }
        else {
          // Add a product        
          this.service.addEntreguePor(this.service.form.value)
            .subscribe(entreguePor => { this.entreguePor = this.service.form.value },
              () => null,
              () => this.dataSaved());
        }
      }
    }
  
    private dataSaved(): void {
      this.service.form.reset();
      this.service.initializeFormGroup();
      this.notificationService.success('Salvo com sucesso');
      this.onClose();
  
      // Redirect back to list
      //this.goBack();
    }
  
    onClose() {
      this.service.form.reset();
      this.service.initializeFormGroup();
      this.dialogRef.close();
    }
  
    goBack(): void {
      this.location.back();
    }

}
