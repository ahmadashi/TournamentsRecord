import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import * as fromSportType from './sport-type/sport-type.reducers';
import { EffectsModule } from '@ngrx/effects';
import { SportTypeEffects } from './sport-type/sport-type.effect';
import { ModuleWithProviders } from '@angular/compiler/src/core';
import { GenericService } from '../../services/generic.service';
import { SportTypeReducerService } from './sport-type-reducer.service';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    //StoreModule.forRoot({}),
    //EffectsModule.forRoot([]),
    StoreModule.forFeature('sportTypeReducer', fromSportType.SportTypeReducer),
    EffectsModule.forFeature([
      SportTypeEffects
    ])
  ]
})

export class SportTypeModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SportTypeModule,
      providers: [
        GenericService,
        SportTypeReducerService
      ]
    }
  }
}
  
  
