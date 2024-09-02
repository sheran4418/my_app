import { Component, inject, OnInit } from '@angular/core';
import { environment, myNewConstant } from '../environment/environment.module';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { HttpResponse } from '@angular/common/http';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  title = 'Sample Application';

  logObj:any = {
     
      "username": "",
      "password": ""
    }
  

  public static LoginUserAuth:string  = "";
 

  constructor(private router:Router) {}

  ngOnInit(): void {
   localStorage.removeItem('agularToken');
  }
http = inject(HttpClient);


  addLogin()
  {
    this.http.post("https://localhost:7156/api/account/login", this.logObj).subscribe((res:any) => {
      console.log(res);
      if(res.token != null)
      {
      //  alert(res.token);
        alert("Login successful!");      
        localStorage.setItem('agularToken', res.token);
        this.router.navigateByUrl('products');
      }else if(res == null)
      {
        alert("A");
      }

    })

    
   
  }

}
