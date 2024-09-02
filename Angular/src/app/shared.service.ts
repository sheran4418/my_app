import {inject, Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import { forkJoin } from 'rxjs'; 
import { IProduct } from './Models/ProductsModel';
import { IUser } from './Models/UsersModel';
import { ProductsComponent } from './products/products.component';
@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:7156/api";

  constructor() { }
  http = inject(HttpClient)


  GetProductsList(pagenum:number):Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/products?PageSize=20&PageNumber='+pagenum+'');
  }
  addProducts(data:any)
  {
    return this.http.post(this.APIUrl+'/products', data);
  }
  updateProducts(products: IProduct) {
   return this.http.put(`${this.APIUrl+'/products'}/${products.prod_id}`, products)
  }
  deleteProducts(id: number)
  {
    return this.http.delete(`${this.APIUrl+'/products'}/${id}`);
  }




  GetUsersList(pagenum:number):Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/users?PageSize=20&PageNumber='+pagenum+'');
  }
  addUsers(data:any)
  {
    return this.http.post(this.APIUrl+'/users', data);
  }
  updateUsers(users: IUser) {
   return this.http.put(`${this.APIUrl+'/users'}/${users.user_id}`, users)
  }
  deleteUsers(id: number)
  {
    return this.http.delete(`${this.APIUrl+'/users'}/${id}`);
  }


}
