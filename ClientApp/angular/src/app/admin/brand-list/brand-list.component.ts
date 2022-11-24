import { Component, OnInit } from '@angular/core';
import {ShopService} from "../../shop/shop.service";
import {CarBrand} from "../../shared/models/carBrand";

@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.scss']
})
export class BrandListComponent implements OnInit {
  brands: CarBrand[];
  brand : CarBrand = new CarBrand();
  tableMode: boolean = true;
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.shopService.getBrands()
      .subscribe((data: CarBrand[]) => this.brands = data,
        error => console.log(error))
  }

  save(){
    if (this.brand.id == null) {
      this.shopService.addBrand(this.brand)
        .subscribe(() => this.load());
    } else {
      this.shopService.updateBrand(this.brand)
        .subscribe(() => this.load());
    }
    this.cancel();
  }

  add(){
    this.cancel();
    this.tableMode = false;
  }

  cancel() {
    this.brand = new CarBrand();
    this.tableMode = true;
  }
  delete(brand: CarBrand){
    this.shopService.deleteBrand(brand.id)
      .subscribe(() => this.load(),
        error => console.log(error));
  }

  edit(brand: CarBrand){}

  editBrand(b: CarBrand) {

  }
}
