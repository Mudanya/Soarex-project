import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { Service } from "src/app/models/service";
import { Utility } from "src/app/models/utility";
import { UtilityService } from "src/app/services/utility.service";

@Component({
	selector: "app-home",
	templateUrl: "./home.component.html",
	styleUrls: ["./home.component.scss"],
})
export class HomeComponent implements OnInit {
	text?: string;
	text2?: string;
	settings$!: Observable<Utility>;
	services$!:Observable<Service[]>;
	constructor(private utility: UtilityService) {}

	ngOnInit(): void {
		this.text =
			"eatetstdfughoi uffufggiuigui uvufufufufufyfy igfygyffyfyuf uyfufyufyuf fyufuftu";
		this.text2 = "Robbie ako ndani ya mjengo";
    this.getSettings()
	}
	getSettings() {
		this.settings$ = this.utility.getUtilitySettings();
		this.services$ = this.utility.getServices();
		
	}
}
