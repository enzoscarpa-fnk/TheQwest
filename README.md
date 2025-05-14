<p align="center">
  <img src="https://i.ibb.co/YN2sLRT/the-qwest.png" alt="The Qwest logo" />
</p>

# The Qwest

This project is a role-playing game (RPG) developed in C#, featuring classes, resources, and a main executable.  
Below is an overview to help you install, run, and customize the game.

---

## 🧾 **Basic Elements**

### Hero:
- Health Points (~20 HP)
- One attack
- Defense stat (damage reduction)

### Map:
- Different environments (Forest, Meadows)
- One or two boss zones
- Spawn/respawn point

### Enemies & Bosses:
- At least 3 enemies per zone and 1 boss
- Health Points
- One attack
- Defense stat

### Fountain of Life:
- Restores between 5 and 15 HP
- Visible on the map
- Randomly placed on the map

### Chests:
- Attack bonuses from different weapon types (Axe, Sword…) and materials (Wood, Bronze, Gold…)
- Defense bonuses from different armor materials (Plate, Cloth, Leather…)

---

## 🚀 Getting Started

### Prerequisites

Make sure the following tools are installed:

- **.NET 8.0 SDK or newer** — Required to build and run the project  
  → [Download here](https://dotnet.microsoft.com/)

- **A code editor** — e.g., Visual Studio or Visual Studio Code

### Installation

Clone this repository or download it as a ZIP archive:

```bash
git clone https://github.com/ArnaudClarat/JDR.git
cd JDR
```

Restore dependencies if needed:

```bash
dotnet restore
```

---

## ▶️ Running the Game

To launch the game, run the following command:

```bash
dotnet run
```

This will start the main program defined in `Program.cs`.

---

## 🛠️ Built With

- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) – Frontend framework using C#  
- [Blazor WebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) – WebAssembly runtime

---

## 👥 Authors

- **Anthony Chang** _aka_ [@changzhiho](https://github.com/changzhiho)  
- **Arnaud Clarat** _aka_ [@ArnaudClarat](https://github.com/ArnaudClarat)  
- **Kévin Goossens** _aka_ [@KGOx](https://github.com/KGOx)  
- **Enzo Scarpa** _aka_ [@enzoscarpa-fnk](https://github.com/enzoscarpa-fnk)

---

## 🧱 Project Development Steps

### 🕹️ Game Foundation:

- Created a 10x10 grid-based game board (map)
- Created a hero that can move on the map (with sprite animations)
- Added a fountain of life to heal the hero

### ⚔️ Combat Module:

- **v1.0:**
  - Added `Character` class with basic properties (level, XP, HP...)
  - Added basic methods (attack, take damage, heal, die...)
  - Added `Hero_Mage` class (inherit from `Character`)
  - Created a UI interface for combat

- **v2.0:**
  - Added a console component to display combat info in the UI

- **v3.0:**
  - Added level progression system
  - Added hero stat calculation system
  - Added monsters + dynamic monster level based on hero level

- **v4.0:**
  - Integrated combat system with the map
  - Added hero movement and interaction methods
  - Added end-of-game logic
  - Introduced `Hero` class between `Character` and hero subclasses
  - Added specialized spells for Mage

- **v5.0:**
  - Added combat module trigger (show/hide based on state)
  - Introduced primary (Endurance, Strength, Spirit…) and secondary (Haste, Crit Chance…) stats
  - Updated hero methods to account for new stats
  - Added `Item` class to apply stat bonuses via equipment

- **v6.0:**
  - Added escape mechanic
  - Redefined stat calculations for leveling
  - Integrated mechanics like energy regeneration, haste, dodge, and gear-based bonuses

### 🗺️ Map System:

- Added `Map` class and component to clean up `Home` file
- Moved map properties and methods to `Map`
- Handled display and interactions within `Map` component
- Integrated map component into `Home`
- Added event handlers for inter-component communication

### 💰 Treasure & Items:

- Added `Treasure` class to manage chest behavior
- Added `Armor` and `Weapon` classes to equip the hero
- Defined rarity and performance via probability-based calculations

### 🏠 Home File:

- Added character creation module (name, class) at game start
- Added hero stat display module
- Added hero inventory display module

### 🔄 Game Flow:

- Switched from real-time to turn-based combat system

### ➕ What's Next?

- Game balance
- Tooltips for items
- Enhanced graphic design
- Audio feedback integration
- Add doors/teleporters to navigate between maps (with other bosses, quests, treasures…)
- Integrate NPCs for shop/quests/dialogue
- Add basic storyline with main and side quests
- Convert combat, stats, and inventory modules into components
- Add difficulty levels based on scaling factors
- Combat animations
- Procedural map generation (normal maps, height maps, Perlin noise…)

---

<p align="center">
  <img src="https://i.ibb.co/7JVsQGvP/theqwest1.png" alt="New game" />
</p>

<p align="center">
  <img src="https://i.ibb.co/FqcNmN7q/theqwest2.png" alt="Fight" />
</p>

<p align="center">
  <img src="https://i.ibb.co/G4f1Hh58/theqwest3.png" alt="Treasure" />
</p>

---
