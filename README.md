
# GameOfChance

## Overview
This coding challenge involves creating a simple REST API using .NET and C# to simulate a game of chance.

## Game Rules
- The game generates a random number between 0 and 9.
- Players predict the random number.
- Each player starts with an account of 10,000 points.
- Players can wager any number of points on their prediction.
- If the prediction is correct, the player wins 9 times their stake.
- If the prediction is incorrect, the player loses their stake.

## Task Description
Players interact with the game by sending their bet through a request to the API.

### Placing a Bet
Players send their prediction and stake in the request body. For example:

   
    {
      "points": 100,
      "number": 3
    }

### Winning a Bet
If the bet is successful, the API responds with the player's updated account balance, status, and points won. For example:


    {
      "account": 10900,
      "status": "won",
      "points": "+900"
    }

### Implementation

Added validation for when the bet is lower than 0 or higher than they player's balance.

Added validation for when the guessed number is not within the interval 0-9.

In the request you need to add the id of the player. 

The database has been seeded with 2 players but you can add more directly or by modifying the DbInitializer class.

To run the program:

1. In the package manager console run the following command to generate the tables: Update-Database
2. Run

