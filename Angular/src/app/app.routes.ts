import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductsComponent } from './products/products.component';
import { UsersComponent } from './users/users.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { LayoutComponent } from './layout/layout.component';
import { authGuard } from './guard/auth.guard';

export const routes: Routes = [

    {path:'', component:LoginComponent},
    {path:'*', component:LoginComponent},
    {path:'login', component:LoginComponent},    
    {path:'',
     component:LayoutComponent,
     children:[
        {path:'products', component:ProductsComponent, title:'Products', canActivate:[authGuard]},
        {path:'users', component:UsersComponent, title:'Users', canActivate:[authGuard]},
        {path:'dashboard', component:DashboardComponent, title:'Dashboard', canActivate:[authGuard]},
        {path:'orders', component:OrdersComponent, title:'Orders', canActivate:[authGuard]},
     ]
    },
    
    {path: '**', pathMatch: 'full', component:PagenotfoundComponent}

];

@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }