import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { BaseComponent } from './base.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { EnquiryComponent } from './enquiry/enquiry.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { HomeComponent } from './home/home.component';
import { SettingsComponent } from './settings/settings.component';

const routes: Routes = [
  {
    path:'',
    component:BaseComponent,
    children: [
      {
        path:'index',component:HomeComponent
      },
      {
        path:'about', component:AboutComponent
      },
      {
        path:'contact-us', component:ContactUsComponent
      },
      {
        path:'enquiry', component:EnquiryComponent
      },
      {
        path:'settings', component:SettingsComponent
      }
      ,
      {
        path:'feedback', component:FeedbackComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BaseRoutingModule { }
