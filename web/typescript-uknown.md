# Unknown in TypeScript

```ts
  

let x:unknown;

  

x = 12;

  

if(typeof x === "number") {

  x += 100;

}

  

x = 'Horse';

  

if(typeof x === "string") {

  console.log(x.length);

}

  

class Monkey {

  

  constructor(public name: string){}

}

  

x = new Monkey('George');

  

let demeanor = '';

  

if(x instanceof Monkey) {

  demeanor = 'Curious';

} else {

  demeanor = 'Do not know';

}

  

// Good Example Here https://mariusschulz.com/blog/the-unknown-type-in-typescript#example-reading-json-from-localstorage
```

