package main

import (
	"fmt"
	"log"

	"rsc.io/quote"

	"example.com/greetings"
)

func main() {
	fmt.Println("Hello, World!")
	fmt.Println()
	fmt.Println(quote.Go())
	fmt.Println()

	// Old Practice-Code: Get a greeting message and print it.
	//message := greetings.Hello("Gladys")
	//fmt.Println(message)

	// Error Handling

	// Set properties of the predefined Logger, including
	// the log entry prefix and a flag to disable printing
	// the time, source file, and line number.
	log.SetPrefix("log-greetings: ")
	log.SetFlags(0)

	// Request a greeting message
	message, err := greetings.Hello("Gladys")
	// If an error was returned, print it to the console and
	// exit the program.
	if err != nil {
		log.Fatal(err)
	}

	// If no error was returned, print the returned message
	// to the console.
	fmt.Println(message)

	// Print out a bunch of Hello messages

	// A slice of names
	names := []string{"Gladys", "Samantha", "Darrin"}

	// Request greeting messages for the names
	messages, err := greetings.Hellos(names)
	if err != nil {
		log.Fatal(err)
	}

	// If no error was returned, print the returned map of
	// messages to the console.
	fmt.Println()
	fmt.Println(messages)
	fmt.Println()
	for i, helloMessage := range messages {
		fmt.Printf("Message Key - %v: %v\n", i, helloMessage)
	}
}
