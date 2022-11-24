import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';
import {Car} from "../../shared/models/car";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  car: Car;
  quantity = 1;

  constructor(private shopService: ShopService,
              private activateRoute: ActivatedRoute,
              private bcService: BreadcrumbService,
              private basketService: BasketService) {
    this.bcService.set('@carDetails', '');
  }

  ngOnInit() {
    this.loadProduct();
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.car, this.quantity);
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  loadProduct() {
    this.shopService.getCar(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(car => {
      this.car = car;
      this.bcService.set('@carDetails', car.name);
    }, error => {
      console.log(error);
    });
  }

}
