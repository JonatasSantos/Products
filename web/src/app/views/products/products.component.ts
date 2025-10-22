import { Component, inject, ViewChild } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTable, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import Product from '../../models/Product';
import { ProductDialogComponent } from '../../shared/product-dialog/product-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [
    MatToolbarModule, 
    MatTableModule, 
    MatButtonModule, 
    MatIconModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {
  @ViewChild(MatTable)
  table!: MatTable<any>
  products: Product[] = [{
    id: 1,
    name: 'Batata',
    price: 4.99,
    stock: 10
  }]
  
  displayedColumns: string[] = ['name', 'price', 'stock', 'actions']
  readonly dialog = inject(MatDialog);

  constructor(
    public productService: ProductService
  ) {
    this.productService.getProducts()
      .subscribe(data => {
        console.log(data);
        this.products = data;
    })
  }
  
  
  openDialog(product: Product | null): void {
    const dialogRef = this.dialog.open(ProductDialogComponent, {
      width: '250px',
      data: product != null ? product : {
        id: 0,
        name: '',
        price: 0,
        stock: 0
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined) {
        if(this.products.map(p => p.id).includes(result.id)) {
          console.log(result);
          this.productService.updateProduct(result)
            .subscribe(data => {
              if(data === null) return;
              const index = this.products.findIndex(p => p.id === data.id);
              this.products[index] = data;
              this.table.renderRows();
            });
        } else {
          this.productService.createProduct(result)
            .subscribe(data => {
              this.products.push(data);
              this.table.renderRows();
            })
        } 
      }
    })
  }
  
  updateProduct(product: Product) {
    this.openDialog(product);
  }

  deleteProduct(id: number) {
    this.productService.deleteProduct(id)
      .subscribe(() => {
        this.products = this.products.filter(p => p.id != id)
      })
  }
}
