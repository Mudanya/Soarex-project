import { Component, OnInit,Input} from '@angular/core';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {
  @Input() src?:string;
  constructor() { }

  ngOnInit(): void {
  }

}
