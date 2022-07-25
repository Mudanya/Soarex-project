import { Component, OnInit } from '@angular/core';
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
  isOpen:boolean = true;
  constructor(private route:ActivatedRoute, 
    private router:Router) { }

  ngOnInit(): void {
   // this.route.fragment.subscribe(fragment => { this.fragment = fragment; });
  }
  toggleNavOff()
  {
    this.isOpen = false;
  }
  toggleNavOn()
  {
    this.isOpen = true;
  }
}
