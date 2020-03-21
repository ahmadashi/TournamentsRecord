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
import { TournamentTypeRequested } from '../../reducers-store/tournament-type-module/tournament-type/tournament-type.actions';
import { TrTournamentTypeModel } from '../../models/tr-Tournament-type-model';
import { selectAllTournamentTypes } from '../../reducers-store/tournament-type-module/tournament-type/tournament-type.selectors';



@Component({
  selector: 'app-create-tournament',
  templateUrl: './create-tournament.component.html',
  styleUrls: ['./create-tournament.component.css']
})
export class CreateTournamentComponent implements OnInit {
  public sportTypes: TrSportTypeModel[] = [];
  public tourTypes: TrTournamentTypeModel[] = [];
  
  public createTourForm: any;
  public loading$: Observable<boolean>;
  public loaded$: Observable<boolean>;
  public mode: string = 'indeterminate';


  constructor(private formBuilder: FormBuilder,
    private store: Store<AppState>) {      

      let nameValidators = [
        Validators.required,
        Validators.maxLength(25)];

    let reqValidators = [
      Validators.required
      ];


      this.createTourForm = this.formBuilder.group({
        name: new FormControl('', nameValidators),        
        sportType: new FormControl('', reqValidators),
        tourType: new FormControl('', reqValidators),
        startDate: new FormControl()
      });
    }

    ngOnInit() {
      this.loadSportTypes();
      this.loadTourtTypes();
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


  private loadTourtTypes(): void {
    this.store.pipe(select(selectAllTournamentTypes),
      tap(tourTypes => {
        if (tourTypes.length > 0) {
          this.tourTypes = tourTypes;
        }
        else {
          this.store.dispatch(new TournamentTypeRequested());
        }
      }),
      catchError(() => of([]))
    ).subscribe();
    
  }


  


}

  


