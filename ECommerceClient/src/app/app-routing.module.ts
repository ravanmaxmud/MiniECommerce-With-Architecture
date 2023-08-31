import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { HomeComponent } from './ui/companents/home/home.component';

const routes: Routes = [
   {
    path:"admin",component:LayoutComponent,children:[
      {path:"", component:DashboardComponent},
      {path:"customers",loadChildren:()=> import("./admin/components/customer/customer.module")
      .then(module=> module.CustomerModule)},
      {path:"products",loadChildren:()=> import("./admin/components/products/products.module")
      .then(module=> module.ProductsModule)},
      {path:"orders",loadChildren:()=> import("./admin/components/orders/orders.module")
      .then(module=> module.OrdersModule)},
    ]
  },

  {path:"",component:HomeComponent},
  {path:"basket",loadChildren:()=> import("./ui/companents/basket/basket.module").then(module=> module.BasketModule)},
  {path:"products",loadChildren:()=> import("./ui/companents/products/products.module").then(module=> module.ProductsModule)}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
