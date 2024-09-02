import { NgFor } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild, viewChild } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SharedService } from '../shared.service';
import { IProduct } from '../Models/ProductsModel';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [ReactiveFormsModule, NgFor],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {

  @ViewChild('myModal') model : ElementRef | undefined;

  productsForm:FormGroup = new FormGroup({});
  pageNumber:number = 1;

  constructor(private fb:FormBuilder, private service:SharedService){}

  
  productList: IProduct[] =[];


  ngOnInit(): void {
    this.setFormState();
    this.GetProductList();
  
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
    this.productsForm = this.fb.group({
      prod_id:[0],
      prod_code: ['', [Validators.required]],
      prod_name: ['', [Validators.required]],
      prod_description: ['', [Validators.required]],
      prod_qty: ['', [Validators.required]],
      prod_status: ['', [Validators.required]],
      prod_price: ['', [Validators.required]]
     
    })
  }

  GetProductList()
  {
    debugger;
   this.service.GetProductsList(this.pageNumber).subscribe(data=>{this.productList=data;});    
  }

formValues:any;
  onSubmit()
  {

  if(this.productsForm.value.prod_id == 0)
  {
      if(this.productsForm.invalid){alert("Please Fill All Fields!"); return; }
       this.formValues = this.productsForm.value;
       this.service.addProducts(this.formValues).subscribe((res) => {
       alert('Product Added!');
       this.GetProductList();
       this.productsForm.reset();
       this.closeModal();});
       }else{
       if(this.productsForm.invalid){ alert("Please Fill All Fields!"); return; }
       this.formValues = this.productsForm.value;
       this.service.updateProducts(this.formValues).subscribe((res) => {
       alert('Product Updated!');
       this.GetProductList();
       this.productsForm.reset();
       this.closeModal();});}
   }

  onDelete(id: number)
  {
    const isConfirm = confirm("Are You Sure ?");
    if(isConfirm)
    {
      this.service.deleteProducts(id).subscribe((res) => {
        alert('Product Deleted!');
        this.GetProductList();
      });
    }
  }

  onEdit(products :IProduct)
  {
    this.openModal();
    this.productsForm.patchValue(products);
  }

  pageup()
  {
    this.pageNumber++;
    this.GetProductList();
  }

  pagedn()
  {
    this.pageNumber--;
    if(this.pageNumber >= 1)
    {
      this.GetProductList();
    }else{
      this.pageNumber = 1;
    }
  }

}
