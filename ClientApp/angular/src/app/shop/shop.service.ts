import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import {CarType} from '../shared/models/carType';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import {ShopParams} from "../shared/models/shopParams";
import {Car} from "../shared/models/car";
import {CarBrand} from "../shared/models/carBrand";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString()); // 'key', value
    }

    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }

    if(shopParams.search)  {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sortSelected); // add ?sort=sortSelected value

    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'car', {observe: 'response', params})
      .pipe( // inside pipe methods we can chain as many rxjs operators as we want
        map(response => { // we are converting the 'response' to a IPagination object from body of the response
          return response.body;
        })
      );
  }

  getAllProduct(){
    return this.http.get(this.baseUrl + 'car/allcars');
  }

  addCarType(productType: CarType){
    return this.http.post(this.baseUrl + 'car/cartypes',productType);
  }

  addCar(car: Car){
    return this.http.post(this.baseUrl + 'car',car);
  }

  updateCar(car: Car){
    return this.http.post(this.baseUrl + 'car',car);
  }

  deleteCar(id: number){
    return this.http.delete(this.baseUrl + 'car/' + id)
  }

  deleteCarType(id: number){
    return this.http.delete(this.baseUrl + 'car/cartypes/' + id);
  }

  getCar(id: number){
    return this.http.get<Car>(this.baseUrl + 'car/' + id);

  }

  getBrands() {
    return this.http.get<CarBrand[]>(this.baseUrl + 'car/brands');
  }

  getTypes() {
    return this.http.get<CarType[]>(this.baseUrl + 'car/types');
  }

  updateCarType(carType: CarType){
    return this.http.post(this.baseUrl + 'products/types',carType);
  }

  addBrand(brand: CarBrand) {
    return this.http.post(this.baseUrl + "car/brands",brand);
  }


  updateBrand(brand: CarBrand) {
    return this.http.post(this.baseUrl + "car/carbrands",brand);
  }

  deleteBrand(id: number) {
    return this.http.delete(this.baseUrl + "car/carbrands/" + id)
  }
}
