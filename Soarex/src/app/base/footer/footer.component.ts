import { Component, Input, OnInit } from '@angular/core';
import { Utility } from 'src/app/models/utility';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  @Input() util?:string;
  @Input() settings!:Utility | null;
  constructor() { }

  ngOnInit(): void {
  }

}
