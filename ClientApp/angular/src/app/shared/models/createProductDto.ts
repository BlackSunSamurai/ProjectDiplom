export class CreateProductDto{
  constructor(public name: string,
              public imageUrl: string,
              public description: string,
              public price: number,
              public productType: string,
              public productBrand: string) {
  }
}
