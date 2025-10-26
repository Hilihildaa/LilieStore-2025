import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Product } from './core/shared/models/product';
import { Pagination } from './core/shared/models/pagination';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  baseUrl = 'https://localhost:5001/api/';
  private http = inject(HttpClient);
  title = 'LiliStore';
  products: Product[] = [];

  ngOnInit(): void {
    this.http.get<Pagination<Product>>(this.baseUrl + 'products').subscribe({
      next: response => {
        this.products = response.data;
        console.log('Products:', this.products);
      },
      error: error => console.log('Error:', error),
      complete: () => console.log('Request complete')
    });
  }
}


//این کد، وقتی اپ شروع می‌شه، می‌ره سراغ سرور محلی و داده‌های محصولات رو می‌گیره و در کنسول چاپ می‌کنه.
