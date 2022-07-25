import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material/tabs';

import { BaseRoutingModule } from './base-routing.module';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { EnquiryComponent } from './enquiry/enquiry.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { BaseComponent } from './base.component';
import { AboutComponent } from './about/about.component';
import { ServicesComponent } from './services/services.component';
import { ReviewComponent } from './review/review.component';
import { CardComponent } from './card/card.component';
import { UtilityService } from '../services/utility.service';
import { SettingsComponent } from './settings/settings.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    NavComponent,
    FooterComponent,
    HomeComponent,
    EnquiryComponent,
    ContactUsComponent,
    BaseComponent,
    AboutComponent,
    ServicesComponent,
    ReviewComponent,
    CardComponent,
    SettingsComponent,
    FeedbackComponent
  ],
  imports: [
    CommonModule,
    BaseRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatTabsModule,
    SharedModule
  ],
  providers: [UtilityService],
})
export class BaseModule { }
