# Galytix
# CountryGwp API

The CountryGwp API is a self-hosted web API that calculates the average gross written premium (GWP) for selected lines of business (LOB) in a given country over the period 2008-2015. The API accepts CSV files containing GWP data for different countries and lines of business.

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Testing](#testing)

## Getting Started

### Prerequisites

To run the CountryGwp API, you need to have the following installed:

- .NET 6 SDK
- Git (optional for cloning the repository)

### Installation

Follow these steps to set up and run the CountryGwp API:

1. Clone the repository to your local machine (skip this step if you have already downloaded the project):

```bash
git clone https://github.com/your-username/CountryGwpAPI.git

```

Navigate to the project directory:
cd CountryGwpAPI

Build the project:
dotnet build

Run the API

The API will now be running and listening on port 9091.

##Usage
To interact with the CountryGwp API, you can use tools like Postman or cURL to send HTTP requests. The API has one endpoint that accepts a POST request to calculate the average GWP for selected lines of business.

API Endpoints
Calculate Average GWP (POST /server/api/CountryGwp/avg)
This endpoint calculates the average GWP for selected lines of business in a given country over the period 2008-2015. The request should include a CSV file with GWP data for the country.

Request:

URL: http://localhost:9091/server/api/CountryGwp/avg
Method: POST
Headers:
Content-Type: multipart/form-data
Parameters:
country (string): The country code ("ae").
lob (array of strings): An array of line of business codes (e.g., ["property", "transport"]).
Response:

The response will be a JSON object containing the average GWP for each line of business. For example:
```
{
    "transport": 446001906.1,
    "liability": 634545022.9
}

