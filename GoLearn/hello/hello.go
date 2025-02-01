package main

import (
	"fmt"

	"rsc.io/quote"

	"example.com/greetings"
)

func main() {
	fmt.Println("Hello, World!\n")
	fmt.Println(quote.Go()+"\n")
	
	// Get a greeting message and print it.
	message := greetings.Hello("Gladys")
	fmt.Println(message)
}