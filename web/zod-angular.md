```ts
import { Injectable } from "@angular/core";

import { Actions, concatLatestFrom, createEffect, ofType } from "@ngrx/effects";

import { Store } from "@ngrx/store";

import { catchError, filter, map, of, tap } from "rxjs";

import { z } from 'zod';

import { selectCountData } from "..";

import { CounterCommands, CounterDocuments } from "../actions/count-actions";

import { CountState } from "../reducers/count-reducer";

@Injectable()

export class CounterDataEffects {

  

    private readonly COUNT_DATA_KEY = 'count-data';

    private readonly CountDataSchema = z.object({

        current: z.number(),

        by: z.union([z.literal(1), z.literal(3), z.literal(5)]),

    });

  

    // CounterCommandsLoad => ?? => CounterDocuments.counter

    loadCountData$ = createEffect(() => {

        return this.actions$.pipe(

            ofType(CounterCommands.load), // we only care about this action

            map(() => localStorage.getItem(this.COUNT_DATA_KEY)),

            filter(x => !!x), // stop here if we don't have anything in local storage

            map((stringy) => JSON.parse(stringy || "{}") as CountState), // try to parse it with a dummy object to make TS happy

            map(obj => this.CountDataSchema.parse(obj) as CountState), // Zod parse, will throw if it isn't.

            map((data) => CounterDocuments.counter({ payload: data })),

            catchError(err => of(({type: 'error', source: 'counter-prefs', message: 'we have ourselves a hacker here!', payload: err})))

        )

    }, {dispatch: true})

  

    saveCountData$ = createEffect(() => {

        return this.actions$.pipe(

            ofType(CounterCommands.countby, CounterCommands.decremented, CounterCommands.incremented, CounterCommands.reset), // stop here if it isn't one of these.

            concatLatestFrom(() => this.store.select(selectCountData)), // => subscribed observable of our data returned from selectCountData

            map(([, data]) => JSON.stringify(data) ), // turn that data into a string so I can write it local storage

            tap(data => localStorage.setItem(this.COUNT_DATA_KEY, data)) // write that sucker to localstorage

  

        )

    }, {dispatch: false}) // whatever emerges here has to be action, and it is sent to the store.

  
  

    constructor(private actions$: Actions, private store:Store) {}

}
```