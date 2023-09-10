# Go API Demo

go.mod file

```
module oncallapi

  

go 1.18
```

main.go
```go
package main

  

import (

    "encoding/json"

    "net/http"

    "time"

)

  

type Developer struct {

    Name  string `json:"author"`

    Email string `json:"email"`

}

  

func helloWorld(w http.ResponseWriter, r *http.Request) {

    var onCall Developer

    currentTime := time.Now()

    if currentTime.Hour() >= 8 && currentTime.Hour() < 17 {

        onCall = Developer{Name: "Joe", Email: "joe@aol.com"}

    } else {

  

        onCall = Developer{Name: "Jeff", Email: "jeff@hypertheory.com"}

    }

    w.Header().Set("Content-Type", "application/json")

  

    json.NewEncoder(w).Encode(onCall)

}

  

func main() {

    http.HandleFunc("/", helloWorld)

    http.ListenAndServe("", nil)

  

}
```


Dockerfile

```dockerfile
FROM golang:alpine3.16 as build

WORKDIR /app

COPY go.mod .

COPY *.go .

RUN go build -o ./out/oncall .

  

FROM alpine as final

WORKDIR /app

COPY --from=build /app/out/oncall .

  

EXPOSE 80

CMD [ "/app/oncall" ]
```
