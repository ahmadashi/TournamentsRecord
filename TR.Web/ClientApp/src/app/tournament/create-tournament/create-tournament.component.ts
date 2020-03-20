import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormControl, Validators } from '@angular/forms';
import { Store, select } from '@ngrx/store';
import { AppState } from '../../reducers';
import { TrSportTypeModel } from '../../models/tr-sport-type-model';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { tap, catchError, map } from 'rxjs/operators';
import { selectAllSportTypes, selectSportTypeLoading } from '../../reducers-store/sport-type-module/sport-type/sport-type.selectors';
import { SportTypeRequested, SportTypeLoaded } from '../../reducers-store/sport-type-module/sport-type/sport-type.actions';



@Component({
  selector: 'app-create-tournament',
  templateUrl: './create-tournament.component.html',
  styleUrls: ['./create-tournament.component.css']
})
export class CreateTournamentComponent implements OnInit {
  public sportTypes: TrSportTypeModel[] = [];
  public createTourForm: any;
  public loading$: Observable<boolean>;
  public loaded$: Observable<boolean>;
  public mode: string = 'indeterminate';


  constructor(private formBuilder: FormBuilder,
    private store: Store<AppState>) {

      let emailValidators = [
        Validators.required,
        Validators.email];

      let nameValidators = [
        Validators.required,
        Validators.maxLength(25)];

    let sportTypeValidators = [
      Validators.required
      ];


      this.createTourForm = this.formBuilder.group({
        name: new FormControl('', nameValidators),
        address: new FormControl('', emailValidators),
        sportType: new FormControl('', sportTypeValidators)
      });
    }

    ngOnInit() {
      this.loadSportTypes();
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

  private loadSportTypes(): void {
    this.store.pipe(select(selectAllSportTypes),
      tap(sportTypes => {
        if (sportTypes.length > 0) {          
          this.sportTypes = sportTypes;
        }
        else {
          this.store.dispatch(new SportTypeRequested());
        }
      }),
      catchError(() => of([]))
    ).subscribe();

    this.loading$ = this.store.pipe(select(selectSportTypeLoading));
    this.loaded$ = this.loading$.pipe(map(loading => !loading));
  }


  


}

  


