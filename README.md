# CatFacts App

A simple ASP.NET Core MVC 9.0 web application that displays random cat facts and saves them to a local text file.

## Features

- Fetches random cat facts from [CatFact.ninja API](https://catfact.ninja)
- Displays facts with their character length
- **Creates new timestamped file on each application launch**
  - Format: `Data/CatFacts_YYYYMMDD_HHMMSS.txt`
- Automatically clears the file on application startup
- Clean MVC architecture with separate services
- Thread-safe singleton file management

## File Management

- On each application start:
  - Creates new file with current timestamp
  - All facts fetched during session are saved to this file