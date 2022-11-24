import { Component, OnInit } from '@angular/core';
import {ShopService} from "../../shop/shop.service";
import {CarType} from "../../shared/models/carType";
import {Car} from "../../shared/models/car";

@Component({
  selector: 'app-producttype-list',
  templateUrl: './producttype-list.component.html',
  styleUrls: ['./producttype-list.component.scss']
})
export class ProducttypeListComponent implements OnInit {
  carType: CarType =  new CarType();
  carTypes: CarType[];
  tableMode: boolean = true;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.shopService.getTypes()
      .subscribe((data: CarType[]) => this.carTypes = data,
          error => console.log(error));
  }

  delete(id: number){
    this.shopService.deleteCarType(id)
      .subscribe(() => this.load(),
        error => console.log(error));
  }

  save(){
    if (this.carType.id == null) {
      this.shopService.addCarType(this.carType)
        .subscribe(() => this.load());
    } else {
      this.shopService.updateCarType(this.carType)
        .subscribe(() => this.load());
    }
    this.cancel();
  }

  cancel(){
    this.carType = new CarType();
    this.tableMode = true;
  }


  editProductType(pt: CarType) {

  }

  add() {
    this.cancel();
    this.tableMode = false;
  }
}
