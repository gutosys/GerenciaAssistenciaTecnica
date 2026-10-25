import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UploadComponent } from './upload.component';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatListModule } from '@angular/material/list';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { DialogComponent } from './dialog/dialog.component';
import { UploadService } from './upload.service';

@NgModule({
  declarations: [UploadComponent, DialogComponent],
  exports: [UploadComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    MatDialogModule,
    MatListModule,
    MatProgressBarModule
  ],
  providers: [UploadService]
})
export class UploadModule {}
