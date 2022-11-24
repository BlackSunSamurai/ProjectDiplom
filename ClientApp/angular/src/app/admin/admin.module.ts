import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin/admin.component';
import { ProductListComponent } from './product-list/product-list.component';
import {RouterLinkActive, RouterLinkWithHref} from "@angular/router";
import {FormsModule} from "@angular/forms";
import { ProducttypeListComponent } from './producttype-list/producttype-list.component';
import {AdminRoutingModule} from "./admin-routing.module";
import { BrandListComponent } from './brand-list/brand-list.component';



@NgModule({
  declarations: [
    AdminComponent,
    ProductListComponent,
    ProducttypeListComponent,
    BrandListComponent,
  ],
    imports: [
        CommonModule,
        RouterLinkWithHref,
        RouterLinkActive,
        FormsModule,
        AdminRoutingModule
    ]
})
export class AdminModule { }
