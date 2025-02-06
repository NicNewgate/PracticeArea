package main

import (
	"net/http"

	"github.com/labstack/echo/v4"
)

// album represents data about a record album.
type album struct {
	ID     string  `json:"id"`
	Title  string  `json:"title"`
	Artist string  `json:"artist"`
	Price  float64 `json:"price"`
}

// albums slice to seed record album data.
var albums = []album{
	{ID: "1", Title: "Blue Train", Artist: "John Coltrane", Price: 56.99},
	{ID: "2", Title: "Jeru", Artist: "Gerry Mulligan", Price: 17.99},
	{ID: "3", Title: "Sarah Vaughan and Clifford Brown", Artist: "Sarah Vaughan", Price: 39.99},
}

func main() {
	e := echo.New()
	e.GET("/albums", getAlbums)
	e.GET("/albums/:id", getAlbumByID)
	e.POST("/albums", postAlbums)

	e.Logger.Fatal(e.Start(":1323"))
}

// getAlbums responds with the list of all albums as JSON.
func getAlbums(c echo.Context) error {
	return c.JSON(http.StatusOK, albums)
}

// e.GET("/albums/:id", getAlbumByID)
func getAlbumByID(c echo.Context) error {
	id := c.Param("id")

	// Loop over the list of albums, looking for
	// an album whose ID value matches the parameter.
	for _, a := range albums {
		if a.ID == id {
			return c.JSON(http.StatusOK, a)
		}
	}
	return c.String(http.StatusNotFound, "album not found")
}

// postAlbums adds an album from JSON received in the request body.
func postAlbums(c echo.Context) error {
	newAlbum := new(album)

	if err := c.Bind(newAlbum); err != nil {
		return err
	}

	// Add the new album to the slice
	albums = append(albums, *newAlbum)
	return c.JSON(http.StatusCreated, newAlbum)
}
