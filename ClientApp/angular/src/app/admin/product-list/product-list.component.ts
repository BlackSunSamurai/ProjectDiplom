import { Component, OnInit } from '@angular/core';
import {ShopService} from "../../shop/shop.service";
import {Car} from "../../shared/models/car";

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  cars: Car[];
  car: Car;
  tableMode: boolean = true;
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
   this.load();
  }

  load(){
    // @ts-ignore
    this.shopService.getAllProduct().subscribe((data: IProduct[]) => {
        this.cars = data;
      },error => {
        console.log(error);
      })
  }

  save(){
    if (this.car.id == null) {
      this.shopService.addCar(this.car)
        .subscribe(() => this.load());
    } else {
      this.shopService.updateCar(this.car)
        .subscribe(() => this.load());
    }
    this.cancel();
  }

  add(){
    this.shopService.addCar(this.car)
      .subscribe(() => this.load());
  }

  cancel() {
    this.tableMode = true;
  }
    delete(car: Car){
      this.shopService.deleteCar(car.id)
        .subscribe(() => this.load(),
            error => console.log(error));
    }

  editProduct(p: Car) {

  }
}
