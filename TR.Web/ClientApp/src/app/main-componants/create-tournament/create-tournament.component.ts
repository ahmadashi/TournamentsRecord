import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-create-tournament',
  templateUrl: './create-tournament.component.html',
  styleUrls: ['./create-tournament.component.css']
})
export class CreateTournamentComponent implements OnInit {

    createTourForm;

    constructor(private formBuilder: FormBuilder) {

      let emailValidators = [
        Validators.required,
        Validators.email];

      let nameValidators = [
        Validators.required,
        Validators.maxLength(25)];    


      this.createTourForm = this.formBuilder.group({
        name: new FormControl('', nameValidators),
        address: new FormControl('', emailValidators)
      });
    }

    ngOnInit() {

    }

    onSubmit(customerData) {
      // Process checkout data here
      console.warn('Your order has been submitted', customerData);    
    }    

  public getErrorMessage(control : any) {
    return control.hasError('required') ? 'You must enter a value' :
      control.hasError('maxLength') ? 'Not a valid value excied mac length' :        
        control.hasError('email') ? 'Not a valid email' :
              '';
    }

  public shouldShowErrors(control: any): boolean | any {
      let showError: boolean | any = false;
      if (control && control.errors) {
        showError = (control.dirty || control.touched);
      }
      return showError;
    }

  }

  


