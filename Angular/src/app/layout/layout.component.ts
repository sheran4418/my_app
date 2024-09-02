import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  constructor(private router:Router) {}

  dashboards:boolean = false;
  users:boolean = false;
  products:boolean = false;
  orders:boolean = false;


  dashboard()
  {
    this.dashboards = true;
    this.router.navigateByUrl('dashboard');
    this.users = false;
    this.products = false;
    this.orders = false;
    this.router.navigate(['/dashboard']);
  }

  product()
  {    
    this.products = true;
    this.router.navigateByUrl('products');
    this.users = false;
    this.dashboards = true;
    this.orders = false;
    this.router.navigate(['/products']);
  }

  user()
  {
    this.users = true;
    this.router.navigateByUrl('users');
    this.dashboards = false;    
    this.products = false;
    this.orders = false;
    this.router.navigate(['/users']);
  }

  order()
  {
    this.orders = true;
    this.router.navigateByUrl('orders');
    this.users = false;
    this.products = false;
    this.dashboards = false;
    this.router.navigate(['/orders']);
  }
}
