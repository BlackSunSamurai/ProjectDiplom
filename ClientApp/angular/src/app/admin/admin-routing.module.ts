import {RouterModule, Routes} from "@angular/router";
import {AdminComponent} from "./admin/admin.component";
import {ProductListComponent} from "./product-list/product-list.component";
import {ProducttypeListComponent} from "./producttype-list/producttype-list.component";
import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {BrandListComponent} from "./brand-list/brand-list.component";

const routes: Routes = [
  {path: '',component: AdminComponent},
  {path: 'product-list', component: ProductListComponent,data: {breadcrumb: {alias: 'product-list'}}},
  {path: 'productType-list', component: ProducttypeListComponent,data: {breadcrumb: {alias: 'productType-list'}}},
  {path: 'brand-list', component: BrandListComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule,
  ]
})
export class AdminRoutingModule { }
