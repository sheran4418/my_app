import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { environment } from '../environment/environment.module';
import { Router, RouterLink } from '@angular/router';
import { SharedService } from '../shared.service';
import { NgFor } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../Models/UsersModel';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [ReactiveFormsModule, NgFor],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit {

  @ViewChild('myModal') model : ElementRef | undefined;

  usersForm:FormGroup = new FormGroup({});

  pageNumber:number = 1;

  constructor(private fb:FormBuilder, private service:SharedService){}

  UsersList: IUser[] =[];

  ngOnInit(): void {
    this.setFormState();
    this.GetUserList();
  }


  openModal()
  {
   const empModal = document.getElementById('myModal');
   if(empModal != null)
   {
    empModal.style.display = 'block';
   }
  }

  closeModal()
  {
    this.setFormState();
    if(this.model != null)
    {
      this.model.nativeElement.style.display = 'none';
    }
  }
  
  setFormState()
  {
    this.usersForm = this.fb.group({
      user_id:[0],
      u_name: ['', [Validators.required]],
      username: ['', [Validators.required]],
      u_email: ['', [Validators.required]],
      u_fname: ['', [Validators.required]],
      u_lname: ['', [Validators.required]],
     
     
    })
  }

  GetUserList()
  {
    debugger;
   this.service.GetUsersList(this.pageNumber).subscribe(data=>{this.UsersList=data;});    
  }

formValues:any;
  onSubmit()
  {

  if(this.usersForm.value.user_id == 0)
  {
      if(this.usersForm.invalid){alert("Please Fill All Fields!"); return; }
       this.formValues = this.usersForm.value;
       this.service.addUsers(this.formValues).subscribe((res) => {
       alert('User Added!');
       this.GetUserList();
       this.usersForm.reset();
       this.closeModal();});
       }else{
       if(this.usersForm.invalid){ alert("Please Fill All Fields!"); return; }
       this.formValues = this.usersForm.value;
       this.service.updateUsers(this.formValues).subscribe((res) => {
       alert('User Updated!');
       this.GetUserList();
       this.usersForm.reset();
       this.closeModal();});}
   }

  onDelete(id: number)
  {
    const isConfirm = confirm("Are You Sure ?");
    if(isConfirm)
    {
      this.service.deleteUsers(id).subscribe((res) => {
        alert('User Deleted!');
        this.GetUserList();
      });
    }
  }

  onEdit(users :IUser)
  {
    this.openModal();
    this.usersForm.patchValue(users);
  }


  pageup()
  {
    this.pageNumber++;
    this.GetUserList();
  }

  pagedn()
  {
    this.pageNumber--;
    if(this.pageNumber >= 1)
    {
      this.GetUserList();
    }else{
      this.pageNumber = 1;
    }
  }


}
