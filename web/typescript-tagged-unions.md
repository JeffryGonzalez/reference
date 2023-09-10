# TypeScript Tagged Union Type

```ts
type SuccessResult<T> = {
  status: 'OK';
  value: T;
};

type ErrorResult = {
  status: 'ERROR';
  message?: string;
};

function isEven(x: number): SuccessResult<number> | ErrorResult {

  if (x % 2 === 0) {

    const result: SuccessResult<number> = {
      status: 'OK',
      value: 2,
    };
    return result;
  } else {
    const result: ErrorResult = {
      status: 'ERROR',
      message: 'Not Even!',
    };
  }
}

const r = isEven(2);

if (r.status === 'OK') {

  console.log(`That is even ${r.value} ${r.value * 2}`);

} else {

  const msg = r.message ? r.message : 'No Message Provided!';

  console.log(`It is not even. Message ${msg}`);

}
```

## Extended Example

```ts
type SuccessResult<T> = {

  status: 'OK';

  value: T;

};

  

type ErrorResult = {

  status: 'ERROR';

  message?: string;

};

  

function isEven(x: number): SuccessResult<number> | ErrorResult {

  if (x % 2 === 0) {

    const result: SuccessResult<number> = {

      status: 'OK',

      value: 2,

    };

    return result;

  } else {

    const result: ErrorResult = {

      status: 'ERROR',

      message: 'Not Even!',

    };

  }

}

  

const r = isEven(2);

  

if (r.status === 'OK') {

  console.log(`That is even ${r.value} ${r.value * 2}`);

} else {

  const msg = r.message ? r.message : 'No Message Provided!';

  

  console.log(`It is not even. Message ${msg}`);

}

  

interface CountData {

  current: number;

  by: 1 | 3 | 5;

}

  

const c: CountData = { current: 99, by: 3 };

  

localStorage.setItem('count', JSON.stringify(c));

  

function getCountData(): SuccessResult<CountData> | ErrorResult {

  const stored = localStorage.getItem('count');

  if (stored) {

    let data: any;

    try {

      data = JSON.parse(stored);

    } catch {

      return {

        status: 'ERROR',

        message: 'Not valid JSON',

      };

    }

    if (typeof data.by === 'number' && typeof data.current === 'number') {

      return {

        status: 'OK',

        value: data as CountData,

      };

    } else {

      return {

        status: 'ERROR',

        message: 'Data not in correct format ',

      };

    }

  } else {

    return {

      status: 'ERROR',

      message: 'No Data Stored',

    };

  }

}

  

const countDataResult = getCountData();

switch (countDataResult.status) {

  case 'OK': {

    console.log(countDataResult.value);

    break;

  }

  case 'ERROR': {

    console.log(countDataResult.message);

  }

}
```