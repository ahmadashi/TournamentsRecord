import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import * as _ from 'lodash';
import { GenericService } from './generic.service';
import { TrSportTypeModel } from './tr-sport-type-model';
//import { map } from 'rxjs/operators';
import { map } from 'rxjs/operators';

@Injectable()
export class TournamentService {

  constructor(private genericService: GenericService,) { }

  xx: TrSportTypeModel[];

  //public getSchoolTypes(): Observable<TrSportTypeModel[]> {
  //  //const accessToken = this.localStorage.getItem(this.constant.storageKey.accessToken);
  //  //const api = this.constant.schools.schoolTypes.api;
  //  //const option = this.util.getConfigOption(accessToken);
  //  return this.genericService.get("ddd", "dsd")
  //    .pipe(map((result: TrSportTypeModel[]) => {
  //      const sportType = _.map(result,
  //        function (element) {
  //          return _.extend({}, element, {
  //            id: element.sportTypeId
  //          });
  //        });
  //      return sportType;
  //    }));
  //}


  public getSchoolAggregate(): Observable<TrSportTypeModel[]> {
    //const accessToken = this.localStorage.getItem(this.constant.storageKey.accessToken);
    //const api = this.constant.adminDashboard.schoolAggregate.api;
    //const option = this.util.getConfigOption(accessToken);

    //this.genericService.get('https://example.com/api/items', "").pipe(map(data: any => { })).subscribe(result => {
    //  return result;
    //});

    //return this.genericService.get("", "")
    //  .pipe();

    //return this.genericService.get("/api/url", "")
    //  .pipe(map(data => data.map(v => new TrSportTypeModel())));

    //let xx: TrSportTypeModel[];
    //this.genericService.get("", "")
    //  .pipe(map(result: TrSportTypeModel[]) => {
    //    this.xx = result;
    //  });

    //return this.xx;
  }


}
