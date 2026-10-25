import { Component, Inject, ChangeDetectionStrategy } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogComponent } from './dialog/dialog.component';
import { UploadService } from './upload.service';

@Component({
    selector: 'app-upload',
    templateUrl: './upload.component.html',
    styleUrls: ['./upload.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class UploadComponent {
  constructor(public dialog: MatDialog,
    public uploadService: UploadService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  public openUploadDialog() {
    let dialogRef = this.dialog.open(DialogComponent, {
      width: '50%',
      height: '50%',
      data: {
        id: this.data
      }
    });
  }
}
