import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product!: IProduct;
  value:any;
  id!: number;
  quantity=1;

  constructor(private shopService: ShopService,private activatedRoute:ActivatedRoute, private bsService:BreadcrumbService,
    private basketService:BasketService) 
  { 
    this.bsService.set('@productDetails',' ');
  }

  ngOnInit(): void {
    this.loadProduct();
  }

  incrementQuantity(){

    this.quantity++;
  }

  addItemToBasket(){
    this.basketService.addItemToBasket(this.product,this.quantity);

  }

  decrementQuantity(){
    if(this.quantity>1){
      this.quantity--;
    }

  }


  loadProduct() {
    this.shopService.getProduct(Number(this.activatedRoute.snapshot.paramMap.get('id'))).subscribe(product => {
      this.product = product;
      this.bsService.set('@productDetails',product.name);
    }, error => {
      console.log(error);
    }
    )
  }
    
}
