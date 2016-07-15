# auctionata-online-web-api

This is a web api to be consumed by any SPA.

# Stack

+ Clean architecture (Mix of onion architecture);
+ ASP.NET Web API;
+ SQLServer;
+ Migrations;
+ Entity Framework;
+ Ninject;
+ SpecFlow (BDD);
+ NUnit and Moq (TDD);

# Routes (Rest)

## [Buyers]

### Get all Buyers

`auctionata/api/v1/buyers`

```JSON
[
  {
    "id": 1,
    "name": "Martin Pernecky"
  },
  {
    "id": 2,
    "name": "Maycon Beserra"
  }
]
```

### Get Buyer By ID

`auctionata/api/v1/buyers/{buyerid}`

```JSON
{
  "id": 2,
  "name": "Maycon Beserra"
}
```

## [Auctions]

### Get All Auctions

`auctionata/api/v1/auctions`

```JSON
[
  {
    "bids": [
      {
        "buyer": {
          "id": 2,
          "name": "Maycon Beserra"
        },
        "id": 1,
        "auctionId": 1,
        "buyerId": 2,
        "bidValue": 110,
        "createdAt": "2016-03-23T00:59:01.78"
      }
    ],
    "item": {
      "id": 1,
      "name": "Bracelet",
      "description": "Bracelet, 14K Gold, Enamel, Sapphire & Diamonds, USA, c. 1965",
      "picturePath": "https://d2c2dsgt13elzw.cloudfront.net/resources/1000x1000/c6/fc/8b3e-ca98-4bda-8ef4-1028ae5a73ba.jpg",
      "initialPrice": 100
    },
    "id": 1,
    "itemId": 1,
    "highestBid": 110,
    "highestBidder": 2,
    "highestBidderName": "Maycon Beserra"
  },
  {
    "bids": [
      {
        "buyer": {
          "id": 1,
          "name": "M Pernecky"
        },
        "id": 3,
        "auctionId": 3,
        "buyerId": 1,
        "bidValue": 350,
        "createdAt": "2016-03-23T01:01:08.923"
      }
    ],
    "item": {
      "id": 3,
      "name": "Earrings",
      "description": "Earrings, 18K Yellow Gold and Lapis, Italy, c. 1980",
      "picturePath": "https://d2c2dsgt13elzw.cloudfront.net/resources/1000x1000/e3/2f/29fb-7a7d-4691-9de0-fcb7f490486e.jpg",
      "initialPrice": 300
    },
    "id": 3,
    "itemId": 3,
    "highestBid": 350,
    "highestBidder": 1,
    "highestBidderName": "M Pernecky"
  }
]
```

### Post - Create an auctoin

`auctionata/api/v1/auctions`

```JSON
{
    itemId: 3
}
```

### Place a Bid

`auctionata/api/v1/auctions/bid/{auctionid}/{buyerid}?bidvalue=99`
