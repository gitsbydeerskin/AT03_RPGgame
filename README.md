# AT03 RPG Game README

## Intro
### The purpose of this document is to provide a guide and introduction to the AT03 RPG Game project. 

## Project Summary 
### 

With this project we are aiming to create a small but feature-complete game prototype that simulates a simple RPG adventure experience. It will have functional systems like player movement, camera control, and basic saving, loading, and respawning, and furthermore include fundamental RPG systems like choice-based dialogue, stats and levelling, and interactions with the environment. 

## Team Members & Assigned Features
### This section is to outline the project's current team members and which of the features each member is responsible for. 

| Team Member   | Feature       |
| ------------- |:-------------:|
| Ethan         | Camera Control, Player Movement, Interactions     |
| Elijah        | Main Menu, Saving Systems     |
| Bri           | Dialogue, Respawn, Stats & Levelling     |

Note: A more detailed breakdown of each feature is available further down in this document. 

## Project Features

This section will contain the list of features that will be implomented our RPG.

### Menu & Options
 - the Main menu will allow the player to start a new game, load saved games, options and exit.
 - the options menu will allow the player to adjust sound settings, graphics and keybinds. 


### Stats & Leveling 
 - The player will have stats such as health, experience points and level.
 - the leveling system will improve starts as the player advances.


### Dialogue System
 - Players can read through text based responses and make chices that 
- Dialogue options will trigger different responses or actions on player decisions. 


### interaction
- the player can interact with NPC's and objects thorugh simple prompts.
-interactions will trigger actions such as opening doors, picking up items and starting a dialogue.
- The interaction system


### Saving & Loading: Options & Stats 

#### Options:
 - The RPG options menu will allow the the player to save their menu preferences, sound settings, graphics and key binds.
 - These settings will save across sessions and will automaticly load when the game starts.
- The system will store these preferences in a JSON file, enabling retieval and modifications.
#### Stats: 
 - the stats will save during the game save process.
 - Player stats will automaticly save during the gameplay.
 - stats will be stored in a file for easy management and retrieval when the games is loading.
 - the players position, rotation and other transform related data will be saved when the game is saved.
 - when the save is loaded the player will be returned to their exact lost location and state.
  

### Player Movement & Respawn

#### Movement:
- The player can move freely within the game world using WASD.
- the player can change speeds between crouching and sprinting.
- Movement is smooth and responsive, with a simple collision detection system to prevent the player from passing through opjects.
#### Respawn:
- When the player dies, that will respawn at a predefined location, such as a checkpoint or starting area.
- Respawn will restore the player's health to a default value.
- The respawn system will include a short delay before the player respawns to avoid instant re-engagement after death.
- The Game will provide a visual or audio cue to indicate the respawn event, ensuring the player is aware of their return to the game.
- player stats, including XP and level, will remain intact upon respawn maintaining the players progression.


## Technical Specifications
This section covers practices such as branch naming conventions, file structure, and commit directions.

### Branch Naming Conventions

All branches should follow the camel casing for the name of the branch. Also, ensure you use descriptive names with no abbreviation, otherwise it may be hard to identify.

For branches that focus on features, the branch naming convention should be:
- 'feature/Feature-Name'<br>

For branches that focus on bug fixing, the branch naming convention should be:
- 'bugfix/ErrorName'<br>

For branches that express a release version change, the branch naming convention should be:
-'version/VersionNumber'<br>
### File Structure
When structuring your files, keep it clear and simple, ensuring the structure makes sense to both yourself and your teammates. All files should be stored either on the GitHub repository, or on a company device.
### Commit Directions
When committing, you have to ensure you do it correctly in order to avoid merge conflicts and making your teammates lose progress.

In order to properly commit, you should ALWAYS pull origin so you have your teammates most recent work. Once you have done that, stage the recorded changes to change only what you need. Once you have done that, name the commit into something meaningful that summarizes the purpose of the commit, that way it can help teammates understand what the commit is for. Once you have done that, you can then commit the changes into the branch.

### Commit naming convention
#### Summary
For making commits, the naming conventions in which you should be doing is:
- `mod`: for when you are making a change to the code or are adding in new code
- `fix`: for when a bug is being fixed
- `file_Change` for when filed are manipulated(added/removed, moved around etc.)
- `refactor`: for when you improve the code but without changing how it works
- `ui`: for when you are manipulating UI elements(add/remove, move around, modify etc.)
#### Description
The description for commits should be detailed, explaining what the purpose of the commit is and what the commit contains (specifics, aka a change to this specific code or this specific UI element).


### Other File Naming Conventions
Other file naming conventions involve:
- For models, you should use pascal case and use the m_ suffix. Give it a clear name and then state the version it is. Finally, separate the suffix, name and version with underscores. An example as to how this would play out is: m_barrel_v2.mb
- For textures, you shoud use pascal case and use the tex_ suffix. Give it a descriptive name outlining what it is and what version it is. You should also separate the suffix, name and version with underscores. An example as to how this would play out is: tex_barrel_v2.png
- For unity projects, camel case should be used, with the name of the file generally being the name of the game. An example of this would be: RolePlayingGame file



