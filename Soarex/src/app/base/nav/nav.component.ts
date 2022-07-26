import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { fade } from 'src/app/animations';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
  animations: [
    fade
  ]
})
export class NavComponent implements OnInit {
  isOpen:boolean = true
  @Input() logo?:string
  constructor(private route:ActivatedRoute,
    private router:Router) { }

  ngOnInit(): void {
    debugger
    const log = this.logo;
   // this.route.fragment.subscribe(fragment => { this.fragment = fragment; });
  }
  toggleNavOff()
  {
    this.isOpen = false
  }
  toggleNavOn()
  {
    this.isOpen = true
  }
}
