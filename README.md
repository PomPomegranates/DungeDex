# DungéDex

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

> *"Finally, a reliable Pokemon-to-Dungeons-and-Dragons-Monster Converter that we can all believe in!"*
> 
> -- Someone, probably

## Table of Contents
- [Introduction](#introduction)
- [Technologies](#technologies)
- [Features](#features)
- [Setup](#setup)
- [Usage](#usage)
- [Endpoints](#endpoints)
  - [Example Endpoint Usage](#example-endpoint-usage)
- [License](#license)
- [To-Do](#to-do)

---

## Introduction
Always looking for a way to convert your favourite Pokémon into Dungeons and Dragons Monsters? Well we have you covered!

We've tamed the open source [PokéAPI](https://github.com/PokeAPI/pokeapi) and [DnD5eAPI](https://github.com/5e-bits/5e-database) to finally allow you to spawn vicious monsters based on your favourite PokéCritters!

We take data the Pokémon data and apply ancient Alteration algorithms to build monsters for each challenge rating in DnD5e!

Underwhelmed by the spells and actions that your newly forged Dungémon wields? Well, they're fully customisable!

Futher thematic properties are produced for Dungemon, based on expecations about its type and level in the PokéWorld.

The complexity of data and call frequency demanded both client and server side caching which are implemented at both the API and client levels.

Your Dungémon can be saved for later retrieval, just sign up and login first!

Authentication takes is implemented JSON Web Tokens (JWTs), if using a client other than the provided Blazor app, attach your `Authorization: Bearer {TOKEN}` header to subsequent requests.

Using our website was intended to be simple and intuitive. You can find any randomly generated Dungemon by first inputting the name of a Pokemon into the search bar, or by inputting its Pokedex number. If you leave the searchbar blank, a number will be provided for you and you'll be taken to a random page instead.

Here you can see your generated Dungemon! If you wish to edit it, you'll be prompted to sign in. By signing in, you can edit any of the values on the dungemon page, and then by clicking publish, you can add it to the list of published, user-generated Dungemon. 

---

## Technologies
- **Languages:** C#, HTML/Razor syntax, CSS, ECMAScript 
- **Framework:** [ASP.NET Core 9.0](https://learn.microsoft.com/en-us/aspnet/core)
- **Tools:** 
  - [Entity Framework Core](https://learn.microsoft.com/en-us/ef/)
  - [NUnit](https://nunit.org/)
  - [Moq](https://github.com/moq/moq4)
  - [AutoFixture](https://autofixture.github.io/)
  - [Fluent Assertions](https://fluentassertions.com/)
  - [Blazored Session Storage](https://github.com/Blazored/SessionStorage)
- **Database:** SQL Server

---

## Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

---

## Features
- RESTful API design.
- JWT Authentication.
- CRUD operations for Dungémon & Users.
- Build a Dungémon from your favourite Pokémon base

---

## Setup
1. Clone the repository:
   ```pwsh
   git clone https://github.com/PomPomegranates/DungeDex
   cd ./DungeDexBE/
   ```

2. Install dependencies:
   ```pwsh
   dotnet restore
   ```

3. Update database connection string and JWT key in a new file, `Secrets.json` in the root directory of the DungeDexBE project:
    ```json
    {
      "ConnectionStrings": 
      {
        "MyCnString": "Server=YOUR_SERVER_DETAILS_HERE"
      },
      "Jwt":
      {
        "Key": "my-32-character-ultra-secure-and-ultra-long-secret"
      }
    }
    ```

4. Apply migrations:
   ```pwsh
   dotnet ef database update
   ```

5. Run the application:
   ```pwsh
   dotnet run
   ```

The client application will be accessible at http://localhost:7107
The web API will be accessible at http://localhost:7298

---

### Usage
- The API is easily accessible through the Blazor client application
- If you would like to test the endpoints, use a tool such as Postman or cURL

---

## Endpoints

### Resource: Pokemon

| HTTP Method | Endpoint                             | Description                                                   |
|-------------|--------------------------------------|---------------------------------------------------------------|
| `GET`       | `/api/pokemon/{idOrName}`            | Get Pokémon by ID or name                                     |
| `GET`       | `/api/pokemon/{idOrName}/monsterify` | Get A Dungémon based on the Pokémon with the given ID or name |

### Resource: Spells

| HTTP Method | Endpoint                    | Description                                     |
|-------------|-----------------------------|-------------------------------------------------|
| `GET`       | `/api/spells`               | Get a dictionary of all spell indices and names |
| `GET`       | `/api/spells/{nameOrIndex}` | Get a spell by its name or index                |

### Resource: Dungémon

| HTTP Method | Endpoint             | Description                                  |
|-------------|----------------------|----------------------------------------------|
| `GET`       | `/api/dungemon/{id}` | Get a Dungémon by its ID                     |
| `GET`       | `/api/dungemon`      | Requires query parameters, see below section |

These HTTP Requests require authentication:

| HTTP Method | Endpoint             | Description                           |
|-------------|----------------------|---------------------------------------|
| `POST`      | `/api/dungemon`      | Add a new Dungémon                    |
| `PATCH`     | `/api/dungemon`      | Update a Dungémon with new properties |
| `DELETE`    | `/api/dungemon/{id}` | Delete a Dungémon by its ID           |

### Resource: User

| HTTP Method | Endpoint                | Description                                    |
|-------------|-------------------------|------------------------------------------------|
| `POST`      | `/api/users/login`      | Login with UserName and Password               |
| `POST`      | `/api/users/register`   | Register a new user with UserName and Password |
| `GET`       | `/api/users/{username}` | Get a user by their username                   |

---

#### Query Parameters for `GET /api/dungemon`

The `GET /api/dungemon` requires two query parameters and allows a third:

| Parameter     | Type     | Description                                           |
|---------------|----------|-------------------------------------------------------|
| `number`      | `int`    | Provides the number of Dungémon to get                |
| `offset`      | `int`    | Provides the index at which to start getting Dungémon |
| `basePokemon` | `string` | The base Pokémon to filter Dungémon by                |

---

### Example Endpoint Usage

#### Get Dungémon by ID
**Request:**
```pwsh
Invoke-RestMethod -Uri "http://localhost:7298/api/dungemon/1" -Method Get
```

**Response:**
```json
{
  "id": 1,
  "userId": "2ab2181a-61be-4d24-bada-ee99a64c6638",
  "user": null,
  "basePokemon": "Lilligant",
  "nickName": "Lilly",
  "challengeRating": 12,
  "proficiencyBonus": 0,
  "armorClass": 12,
  "strength": 14,
  "dexterity": 18,
  "constitution": 13,
  "intelligence": 12,
  "wisdom": 14,
  "charisma": 9,
  "hitPoints": 100,
  "imageLink": "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/549.png",
  "spriteLink": "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/549.png",
  "spells": [
    {
      "id": 1,
      "dungemonId": 1,
      "name": "Sunburst",
      "description": "Brilliant sunlight flashes in a 60-foot radius centered on a point you choose within range. Each creature in that light must make a constitution saving throw. On a failed save, a creature takes 12d6 radiant damage and is blinded for 1 minute. On a successful save, it takes half as much damage and isn't blinded by this spell. Undead and oozes have disadvantage on this saving throw."
    }
  ],
  "actions": [
    {
      "id": 1,
      "dungemonId": 1,
      "name": "Tackle",
      "description": "Melee: +5 to hit, reach 5 ft. Hit: 4d6 + 0 Bludgeoning damage."
    }
  ],
  "proficiencies": "Nature +8",
  "cry": "https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/549.ogg",
  "description": "Even veteran Trainers face a challenge in getting its beautiful flower to bloom. This Pokémon is popular with celebrities.",
  "type": ""
}
```

#### Post Dungemon
**Required Fields for POST:**
- `userId` (string): The current user's ID.
- `basePokemon` (string): The name of the Dungémon's base Pokémon.
- `NickName` (string): The Dungémon's NickName.
- `challengeRating` (float): The Dungémon's Challenge Rating (CR).
- `proficiencyBonus` (integer): The Dungémon's Proficiency Bonus.
- `ArmorClass` (integer): The Dungémon's Armor Class (AC).
- `Strength` (integer): The Dungémon's Strength.
- `Dexterity` (integer): The Dungémon's Dexterity.
- `Constitution` (integer): The Dungémon's Constitution.
- `Intelligence` (integer): The Dungémon's Intelligence.
- `Wisdom` (integer): The Dungémon's Wisdom.
- `Charisma` (integer): The Dungémon's Charisma.
- `HitPoints` (integer): The Dungémon's Hit Points (HP).
- `ImageLink` (string): A URL to the Dungémon's sprite.
- `SpriteLink` (string): A URL to the Dungémon's sprite link.

**Request:**
```pwsh
Invoke-RestMethod -Uri "http://localhost:7298/api/dungemon/" -Method Post -Body @{
    // AS ABOVE
} -ContentType "application/json"
```

---

## License

This project is licensed under the [MIT License](./LICENSE.txt).

- Pokémon, Pokémon names and its intellectual property are trademarks of Nintendo.
- Dungeons and Dragons, DnD and its intellectual property are trademarks of Wizards of the Coast.
- The PokéAPI is licensed under the BSD-3-Clause License.
- The DnD5eAPI is licensed under the MIT license.