# Using Mock Service Workers

## Angular

Good guide here, just remember to `npm i msw`

[Using MSW (Mock Service Worker) in an Angular project - Tim Deschryver](https://timdeschryver.dev/blog/using-msw-in-an-angular-project#setup)

[MSW – Seamless API mocking library for browser and Node | Mock Service Worker (mswjs.io)](https://mswjs.io/)

## Steps

Install msw:

```shell
npm i -D msw
```
Also install:

```shell
npm i -D @types/events
```

Use NPX to initialize

```shell
npx msw init src
```


In `angular.json`:

```json
{
  "build": {
    "options": {
	   ...
      "assets": ["src/favicon.ico", "src/assets", "src/mockServiceWorker.js"],
      ...	  
    }
  }
}
```

In `src/mocks/browser.ts`

```typescript
import { setupWorker, rest } from 'msw';
import * as cuid from 'cuid';

const url = 'http://localhost:1337/locations';
export const mocks = [
	rest.post(url, async (req, res, ctx) => {
		const reqBody = await req.json();
		const authHeader = (req.headers.get('Authorization')?.split('.')[1] || 'none');

		const sub = JSON.parse(atob(authHeader)).sub;

			return res(
				ctx.status(201),
				ctx.json({
					id: cuid(),
					addedBy: sub,
					addedOn: new Date().toISOString(),
					...reqBody
			})
	)
}),

	rest.get('http://localhost:1337/locations', (req, res, ctx) => {
	
		return res(
		ctx.status(200),
		ctx.json({
		_embedded: [
				{
					id: '1',
					name: "Aladdin's Eatery",
					description: 'On Mayfield, good lunch time - lots of options for vegetarians',
					addedBy: 'Bob',
					addedOn: '2023-01-01',
				},
			],
		})
		);
	}),
];

const worker = setupWorker(...mocks);

worker.start();

export { worker, rest };
```

In the `environment.development.ts`

```typescript
import '../mocks/browser';

export const environment = {
  locationsApi: 'http://localhost:1337/',
  auth: {
    authority: 'http://localhost:8090',
    clientId: 'default',
    scope: 'openid profile offline_access',
  },
};
 
```

> Note: If you don't have environments `ng add environments`

