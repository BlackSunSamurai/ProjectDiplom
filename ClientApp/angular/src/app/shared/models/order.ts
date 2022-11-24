import { IAddress } from './address';

export interface IOrderToCreate {
    cartId: number;
    deliveryMethodId: number;
    shipToAddress: IAddress;
}

export interface IOrder {
    id: number;
    userEmail: string;
    orderDate: string;
    address: IAddress;
    delivery: string;
    shippingPrice: number;
    orderItems: IOrderItem[];
    subtotal: number;
    total: number;
    status: string;
    paymentIntentId: string;
}

export interface IOrderItem {
    carId: number;
    carName: string;
    pictureUrl: string;
    price: number;
    quantity: number;
}
