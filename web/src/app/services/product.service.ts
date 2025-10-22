import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Product from '../models/Product';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  productApiUrl = 'https://localhost:7080/api/product';
  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productApiUrl);
  }

  createProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.productApiUrl, {
      name: product.name,
      price: product.price,
      stock: product.stock
    });
  }

  updateProduct(product: Product): Observable<Product> {
    return this.http.put<Product>(`${this.productApiUrl}/${product.id}`, product);
  }

  deleteProduct(id: number) {
    return this.http.delete(`${this.productApiUrl}/${id}`);
  }


}
