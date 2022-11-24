import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import {
  IBasket,
  IBasketItem,
  Basket,
  IBasketTotals,
} from '../shared/models/basket';
import { map } from 'rxjs/operators';
import { IDeliveryMethod } from '../shared/models/deliveryMethod';
import { ToastrService } from 'ngx-toastr';
import {Car} from "../shared/models/car";

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null);
  basketTotal$ = this.basketTotalSource.asObservable();
  shipping = 0;

  constructor(private http: HttpClient) {}

  setBasketId(car?: Car, quantity?: number) {
    if (localStorage.getItem('basket_id') === null) {
      this.http
        .post<any>(this.baseUrl + 'cart/create', {})
        .subscribe((response) => {
          localStorage.setItem('basket_id', response.guid.toString());
          this.basketSource.next(new Basket());
          this.basketSource.value.guid = localStorage.getItem('basket_id');
          if (car) {
            this.addItemToBasket(car, quantity);
          }
        });
    } else {
      this.loadBasket();
    }
  }

  loadBasket() {
    if (localStorage.getItem('basket_id')) {
      this.http
        .get<IBasket>(
          this.baseUrl + 'cart/' + localStorage.getItem('basket_id')
        )
        .subscribe(
          (response) => {
            this.basketSource.next(response);
            this.calculateTotals();
          },
          (error) => {
            localStorage.removeItem('basket_id');
          }
        );
    }
  }

  addItemToBasket(car: Car, quantity: number) {
    const basket = this.basketSource.value;

    if (basket === null) {
      this.setBasketId(car, quantity);
      return;
    }
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(car, quantity);

    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.updateBasket(basket);
  }

  updateBasket(basket: IBasket) {
    this.http.post<IBasket>(this.baseUrl + 'cart/update', basket).subscribe(
      (response) => {
        this.basketSource.next(response);
        this.calculateTotals();
      },
      (error) => {
        console.log(error);
      }
    );
  }

  private addOrUpdateItem(
    items: IBasketItem[],
    itemToAdd: IBasketItem,
    quantity: number
  ): IBasketItem[] {
    const index = items.findIndex((i) => i.carId === itemToAdd.carId);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }

  calculateTotals() {
    const basket = this.basketSource.value;
    const shipping = this.shipping;
    const subtotal = basket.items.reduce((a, b) => b.price * b.quantity + a, 0);
    const total = subtotal + shipping;
    this.basketTotalSource.next({ shipping, total, subtotal });
  }

  incrementItemQuantity(item: IBasketItem) {
    const basket = this.basketSource.value;
    const foundItemIndex = basket.items.findIndex((x) => x.carId === item.carId);
    basket.items[foundItemIndex].quantity++;
    this.updateBasket(basket);
  }

  decrementItemQuantity(item: IBasketItem) {
    const basket = this.basketSource.value;
    const foundItemIndex = basket.items.findIndex((x) => x.carId === item.carId);
    if (basket.items[foundItemIndex].quantity > 1) {
      basket.items[foundItemIndex].quantity--;
      this.updateBasket(basket);
    } else {
      this.removeItemFromBasket(item);
    }
  }

  removeItemFromBasket(item: IBasketItem) {
    const basket = this.basketSource.value;
    if (basket.items.some((x) => x.carId === item.carId)) {
      basket.items = basket.items.filter((i) => i.carId !== item.carId);
      if (basket.items.length > 0) {
        this.updateBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }

  deleteBasket(basket: IBasket) {
    return this.http.delete(this.baseUrl + 'car/' + basket.guid).subscribe(
      () => {
        this.basketSource.next(null);
        this.basketTotalSource.next(null);
        localStorage.removeItem('basket_id');
      },
      (error) => {
        console.log(error);
      }
    );
  }

  private mapProductItemToBasketItem(
    item: Car,
    quantity: number
  ): IBasketItem {
    return {
      carId: item.id,
      name: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity,
      brand: item.carBrand,
      type: item.carType,
    };
  }

  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.shipping = deliveryMethod.price;
    this.calculateTotals();
  }

  getCurrentBasketValue(){
    return this.basketSource.value;
  }
}
