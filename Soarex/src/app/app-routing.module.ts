import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './base/about/about.component';
import { BaseComponent } from './base/base.component';
import { ContactUsComponent } from './base/contact-us/contact-us.component';
import { EnquiryComponent } from './base/enquiry/enquiry.component';

const routes: Routes = [
  {path:'', redirectTo:'/index', pathMatch:'full'},
  {path:'', component:BaseComponent},
  // {path:'about', component:AboutComponent},
  // {path:'contact-us', component:ContactUsComponent},
  // {path:'enquiry', component:EnquiryComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
