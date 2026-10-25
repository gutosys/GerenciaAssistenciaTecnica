import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from '../../shared/notification.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { ComprovanteCompraService } from '../../shared/comprovante-compra.service';

@Component({
    selector: 'app-comprovante-compra-detail',
    templateUrl: './comprovante-compra-detail.component.html',
    styleUrls: ['./comprovante-compra-detail.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class ComprovanteCompraDetailComponent implements OnInit {
  comprovanteCompra: IComprovanteCompra;
  originalComprovanteCompra: IComprovanteCompra;
  tela: string = "Comprovante Compra"

  constructor(private service: ComprovanteCompraService,
    private location: Location,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<ComprovanteCompraDetailComponent>) { }


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
        this.service.updateComprovanteCompra(this.service.form.value)
          .subscribe(comprovanteCompra => { this.comprovanteCompra = this.service.form.value },
            () => null,
            () => this.dataSaved());
      }
      else {
        // Add a product        
        this.service.addComprovanteCompra(this.service.form.value)
          .subscribe(comprovanteCompra => { this.comprovanteCompra = this.service.form.value },
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
