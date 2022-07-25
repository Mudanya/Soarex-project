import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Utility } from "src/app/models/utility";
import { UtilityService } from "src/app/services/utility.service";

@Component({
	selector: "app-settings",
	templateUrl: "./settings.component.html",
	styleUrls: ["./settings.component.scss"],
})
export class SettingsComponent implements OnInit {
	utility: Utility = {};
	utilityForm = new FormGroup({});
	utilityFormData = new FormData();
	validationMessages = {
		heroName: { required: "Hero Name is required" },
		heroDesc: { required: "Hero Description is required" },
		slogan: { required: "slogan is required" },
		strengthDesc: { required: "strength Description is required" },
		phone: { required: "phone is required" },
		email: { required: "email is required" },
		fbLink: { required: "facebook link is required" },
		instaLink: { required: "instagram link is required" },
		inLink: { required: "linkedin link is required" },
		twitLink: { required: "twitter link is required" },
	};
	formErrors = {
		heroName: "",
		heroDesc: "",
		slogan: "",
		strengthDesc: "",
		phone: "",
		email: "",
		fbLink: "",
		instaLink: "",
		inLink: "",
		twitLink: "",
	};

	constructor(
		private fb: FormBuilder,
		private utilityService: UtilityService
	) {}

	ngOnInit(): void {
		this.utilityForm = this.fb.group({
			heroName: ["", Validators.required],
			heroDesc: ["", Validators.required],
			heroImage: [""],
			logo: [""],
			slogan: ["", Validators.required],
			strengthDesc: ["", Validators.required],
			phone: ["", Validators.required],
			email: ["", Validators.required],
			fbLink: ["", Validators.required],
			instaLink: ["", Validators.required],
			inLink: ["", Validators.required],
			twitLink: ["", Validators.required],
		});

		this.utilityForm.valueChanges.subscribe(data => {
			this.logValidationErrors(this.utilityForm);
		});
		this.utilityService.getUtilitySettings().subscribe({
			next: (data: Utility) => {
				debugger;
				this.utility = data;
				this.patchUtility(data);
				console.log(this.utilityForm);
			},
			error: err => console.log(err),
		});
	}
	uploadLogo(files: FileList | null) {
		if (files) {
			this.utilityFormData.append("logo", this.uploadFile(files) as File);
		}
	}
	uploadHeroImage(files: FileList | null) {
		if (files) {
			this.utilityFormData.append("heroImage", this.uploadFile(files) as File);
		}
	}
	MapUtilitySettings() {
		this.utility.phone = this.utilityForm.value.phone as string;
		this.utility.heroName = this.utilityForm.value.heroName;
		this.utility.heroDesc = this.utilityForm.value.heroDesc;
		this.utility.slogan = this.utilityForm.value.slogan;
		this.utility.strengthDesc = this.utilityForm.value.strengthDesc;
		this.utility.fbLink = this.utilityForm.value.fbLink;
		this.utility.twitLink = this.utilityForm.value.twitLink;
		this.utility.inLink = this.utilityForm.value.inLink;
		this.utility.instaLink = this.utilityForm.value.instaLink;
		this.utility.email = this.utilityForm.value.email;
	}
	patchUtility(utility: Utility) {
		if (utility) {
			this.utilityForm.patchValue({
				heroName: utility.heroName,
				heroDesc: utility.heroDesc,
				slogan: utility.slogan,
				strengthDesc: utility.strengthDesc,
				phone: utility.phone,
				email: utility.email,
				fbLink: utility.fbLink,
				inLink: utility.inLink,
				instaLink: utility.instaLink,
				twitLink: utility.twitLink,
			});
		}
	}
	SaveUtilitySettings() {
		this.MapUtilitySettings();
		this.utilityFormData.append("utility", JSON.stringify(this.utility));
		debugger;
		if (this.utility.id) {
			this.utilityService
				.updateUtilitySettings(this.utilityFormData)
				.subscribe({
					next: success => console.log(success),
					error: error => console.log(error),
				});
		} else {
			this.utilityService.postUtilitySettings(this.utilityFormData).subscribe({
				next: success => console.log(success),
				error: error => console.log(error),
			});
		}
	}
	uploadFile(files: FileList) {
		if (files) {
			return files[0];
		}
		return null;
	}

	logValidationErrors(group: FormGroup): void {
		Object?.keys(group.controls).forEach((key: string) => {
			// @ts-ignore
			this.formErrors[key] = "";
			const abstractControl = group.controls[key];
			if (
				abstractControl &&
				!abstractControl.valid &&
				(abstractControl.touched || abstractControl.dirty)
			) {
				// @ts-ignore
				const messages = this.validationMessages[key];
				for (const keyError in abstractControl.errors) {
					if (keyError) {
						// @ts-ignore
						this.formErrors[key] = messages[keyError];
					}
				}
			}
		});
	}
}
