# Mazesolver (Trouve Ta Rue)

<img src = "https://github.com/devicons/devicon/blob/master/icons/unity/unity-original.svg" width="10px" height = "10px"> Unity&nbsp;
<img src="https://github.com/devicons/devicon/blob/master/icons/csharp/csharp-original.svg" width="10px" height = "10px"> C#

## Introduction
*Trouve Ta Rue* (French for 'Find your way'), internally called Mazesolver, was round 2 of the Praestantia event conducted by the MRITS CSI student chapter in December 2022. All participants were given a procedurally generated maze that they needed to solve within 20 minutes.

This repository contains all the code, assets, and more we've used to build the Mazesolver game. We've used Unity to make this game, so a little familiarity with Unity or with gamedev in general helps in understanding this repository a little clearly, though a general knowledge of programming is enough to understand somewhat the C# scripts in `/Assets/Scripts`.

## Repository

`/Assets/` contains basically everything we've written in this repository:

* `/Assets/Animations/` contains the animations used in te game (used when switching scenes.)
* `/Assets/Editor/` contains the Editor Scripts used to generate mazes in editor view and package it as part of the scene.
* `/Assets/Materials/` contains the Materials used for objects in the game.
* `/Assets/Prefabs/` contains the `MazeNode` prefabs used in maze generation.
* `/Assets/Pictures/` contains the pictures used in the game.
* `/Assets/Scenes/` contains the Scenes created in the game.
* `/Assets/Scripts/` contains the C# scripts we've written for the game. This the major part of our work, and all the filenames are pretty descriptive to give a general sense of what they do. `MazeGenerator.cs` contains code used for maze generation, `MazeNode.cs` contains the code for MazeNodes, `GameManager.cs` contains the code used to manage user details, remaining time, etc., `GameOver.cs` has code that runs on game over, `Menu.cs` contains code for the login menu, `Compass.cs` contains the implementation of the compass, and `Helpers.cs` contains some helper functions used in the game.

Other folders in `/Assets/` are assets we've imported from the Unity Asset Store. Only free assets were used, and not a lot of them.

`/Library/` contains the Unity libraries used in this code, while `/Packages/` contains the Unity packages used in this code. `.csproj` and `.sln` files are the Visual Studio project and solution files.


All other files and folders relate to either Unity or Visual Studio configuration, and are not relevant to the game itself.

Feel free to fork this project and work on it yourself, though you will need to remove the API calls and re-enable dynamic maze generation. You can create a pull request if you have some changes to add. The code in this repo is pretty messy, but it is structured in an easily understandable way, and we think it is written in a way that doesn't necessitate the use of comments.

If you have any questions, feel free to contact us on Instagram [@csimrits](https://instagram.com/csimrits), though we will not be able to guarantee responses regarding this repository.

Happy coding and thank you all for showing interest in our event and our code (and all the blood and tears we've spent in writing it)!