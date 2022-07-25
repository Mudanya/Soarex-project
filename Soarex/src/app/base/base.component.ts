import { Component, OnInit,HostListener } from '@angular/core';
import { Observable } from 'rxjs';
import { Utility } from '../models/utility';
import { UtilityService } from '../services/utility.service';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.scss']
})
export class BaseComponent implements OnInit {
  text?:string;
  text2?:string;
  isHyper = false;
  settings$!:Observable<Utility>;
  constructor(private settings:UtilityService) { }

  ngOnInit(): void {
    this.settings$ = this.settings.getUtilitySettings();
  }

  @HostListener("document:scroll") 
  scrollFunction() {
    if(document.body.scrollTop > 0 || document.documentElement.scrollTop > 0){
      this.isHyper = true;
    }
    else{
      this.isHyper = false;
    }
  }
}
