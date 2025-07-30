# CatFacts App

A simple ASP.NET Core MVC 9.0 web application that displays random cat facts and saves them to a local text file.

## Features

- Fetches random cat facts from [CatFact.ninja API](https://catfact.ninja)
- Displays facts with their character length
- Saves all fetched facts to `Data/catfacts.txt`
- Automatically clears the file on application startup
- Clean MVC architecture with separate services