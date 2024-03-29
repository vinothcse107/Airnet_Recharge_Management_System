import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { AddonService } from 'src/app/services/addon.service';
import { AddonsModel } from '../../../shared/AddonModel';

@Component({
      selector: 'app-add-addon',
      templateUrl: './add-addon.component.html',
      styleUrls: ['./add-addon.component.css'],
})
export class AddAddonComponent implements OnInit {

      /**
       * @param _addonService 
       * @using AddonService
       */
      constructor(private _addonService: AddonService) { }

      // Reactive Form Controls Initialization
      AddAddonForm!: UntypedFormGroup;
      ngOnInit(): void {
            this.AddAddonForm = new UntypedFormGroup({
                  _AddonName: new UntypedFormControl(null, [Validators.required]),
                  _AddonPrice: new UntypedFormControl(null, [Validators.required, Validators.pattern("[0-9]{1,5}")]),
                  _AddonDetails: new UntypedFormControl(null, [Validators.required]),
                  _AddonId: new UntypedFormControl(null, [Validators.required]),
                  _AddonValidity: new UntypedFormControl(null, [Validators.required, Validators.pattern("[0-9]{1,5}")]),
            });
      }

      // *----------------*--------------*-------------

      /**
       * @Action Add's New Addon Plan
       * Http Post Method To Add New Plan
       */
      AddAddons() {
            // Gets The value from the Addon Page Fields
            const body: AddonsModel = {
                  addonId: this.generateRandomNumber(),
                  addonName: this.AddAddonForm?.get('_AddonName')?.value,
                  addonPrice: this.AddAddonForm?.get('_AddonPrice')?.value,
                  addonDetails: this.AddAddonForm?.get('_AddonDetails')?.value,
                  addonValidity: this.AddAddonForm?.get('_AddonValidity')?.value,
            };

            // Post Request from Admin Service.
            this._addonService.AddAddon(body).subscribe({
                  error: () => { console.log("Error"); },
                  complete: () => { console.log("Error") }
            })

            setTimeout(() => {
                  this._addonService.router.navigate(["admin/addon/view-addons"]);
            }, 100);
      }

      // *----------------*--------------*-------------

      /**
       * @Action AddonId Generator
       * @returns A Random Number
       */
      generateRandomNumber(): number {
            var minm = 100000;
            var maxm = 999999;
            return Math.floor(Math.random() * (maxm - minm + 1)) + minm;
      }
}
