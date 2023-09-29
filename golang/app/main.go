package main

import (
	"encoding/json"
	"fmt"
	"net/http"
	"time"
)

type Developer struct {
	Name  string `json:"author"`
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
	fmt.Println("Starting server...")
	http.HandleFunc("/", helloWorld)

	http.ListenAndServe("", nil)

}
