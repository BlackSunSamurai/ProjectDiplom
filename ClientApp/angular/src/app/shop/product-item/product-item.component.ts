import { Component, OnInit, Input } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import {Car} from "../../shared/models/car";

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input() car: Car;

  constructor(private basketService: BasketService) { }

  ngOnInit() {
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.car, 1);
  }

}
