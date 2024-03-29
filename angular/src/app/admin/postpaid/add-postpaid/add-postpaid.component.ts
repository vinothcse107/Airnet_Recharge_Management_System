import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { PostpaidService } from 'src/app/services/postpaid.service';
import { PlanModel } from '../../../shared/PlanModel';

@Component({
    selector: 'app-add-postpaid',
    templateUrl: './add-postpaid.component.html',
    styleUrls: ['./add-postpaid.component.css']
})
export class AddPostpaidComponent implements OnInit {


    // PostPaid Service Initialization
    constructor(private _postPaidService: PostpaidService) { }

    // *----------------*--------------*-------------

    // Reactive Forms Initialization
    AddPostPaidForm!: UntypedFormGroup;
    ngOnInit(): void {
        this.AddPostPaidForm = new UntypedFormGroup({
            _PlanId: new UntypedFormControl(null, [Validators.required]),
            _PlanName: new UntypedFormControl(null, [Validators.required]),
            _PlanPrice: new UntypedFormControl(null, [Validators.required, Validators.pattern("[0-9]{1,5}")]),
            _PlanValidity: new UntypedFormControl(null, [Validators.required, Validators.pattern("[0-9]{1,5}")]),
            _PlanDetails: new UntypedFormControl(null, [Validators.required]),
            _PlanOffers: new UntypedFormControl(null, [Validators.required])
        });
    }

    // *----------------*--------------*-------------

    /**
     * @Action Collects the Value from Fields & Post a Plan 
     */
    AddAddons() {

        // Gets The value from the Fields
        const body: PlanModel = {
            planId: this._postPaidService.generateRandomNumber(),
            planName: this.AddPostPaidForm?.get('_PlanName')?.value,
            planPrice: this.AddPostPaidForm?.get('_PlanPrice')?.value,
            planType: "PostPaid",
            planValidity: this.AddPostPaidForm.get('_PlanValidity')?.value,
            planDetails: this.AddPostPaidForm?.get('_PlanDetails')?.value,
            planOffers: this.AddPostPaidForm?.get('_PlanOffers')?.value

        };

        // Post Request To Service To Add Plan
        this._postPaidService.AddPlan(body).subscribe(
            data => {
                console.log(data);
            }
        );

        // Navigating Back to Postpaid plans
        setTimeout(() => {
            this._postPaidService.router.navigate(['/admin/postpaid/view-post-paid']);
        }, 100);
        
    }
}