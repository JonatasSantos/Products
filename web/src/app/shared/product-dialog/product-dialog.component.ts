import {ChangeDetectionStrategy, Component, Inject, inject, model, signal} from '@angular/core';
import {FormsModule} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import Product from '../../models/Product';

@Component({
  selector: 'app-product-dialog',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatDialogModule,
    MatButtonModule
  ],
  templateUrl: './product-dialog.component.html',
  styleUrl: './product-dialog.component.scss',
})
export class ProductDialogComponent {
  isChange!: boolean;
  
  constructor(
    public dialogRef: MatDialogRef<ProductDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Product,
  ) { }

  ngOnInit(): void {
    if(this.data.id != 0) 
      this.isChange = true;
     else 
      this.isChange = false;
  }

  onCancel(){
    this.dialogRef.close()
  }

}
