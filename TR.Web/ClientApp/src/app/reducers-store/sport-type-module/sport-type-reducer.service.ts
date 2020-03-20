import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import * as _ from 'lodash';
import { TrSportTypeModel } from './../../models/tr-sport-type-model';
import { map, catchError } from 'rxjs/operators';
import { GenericService } from '../../services/generic.service';


@Injectable()
export class SportTypeReducerService {

  constructor(private genericService: GenericService, ) { }


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


  public getSportsType(): Observable<TrSportTypeModel[]> {


    return this.genericService.get('api/sporttype', '').pipe(
      map((res: any) => {
        const sportType = _.map(res,
        function (element) {
          return _.extend({}, element, {
            id: element.sportTypeId
          });
        });
      return (sportType as TrSportTypeModel[]);
      }));


    //return this.genericService.get("ddd", "dsd")
    //.pipe(map((result: any) => {
    //  const sportType = _.map(result,
    //    function (element) {
    //      return _.extend({}, element, {
    //        id: element.sportTypeId
    //      });
    //    });
    //  return (sportType as TrSportTypeModel[]);
    //}));


    //return this.genericService.get("", "")
    //  .pipe(map((schoolAggregate: TrSportTypeModel[]) => {
    //    return schoolAggregate;
    //  }));

    //const accessToken = this.localStorage.getItem(this.constant.storageKey.accessToken);
    //const api = this.constant.adminDashboard.schoolAggregate.api;
    //const option = this.util.getConfigOption(accessToken);

  }


}
