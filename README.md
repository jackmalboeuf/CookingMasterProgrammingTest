# CookingMasterProgrammingTest
 Programming test for Tentworks


Implementation

Player Movement

To add a player:
1. Enter desired movement speed. 
2. Setup input axes for desired number of players
	a. Create a horizontal and vertical axis in the input manager labeled for each player (P1, P2, etc.)
	b. Enter positive and negative buttons for each player (wasd, arrow keys) excluding alt buttons
	c. Set Gravity and Sensitivity for each axis to at least 50 and keep Dead at 0.001
3. Enter the names of the corresponding axes into the "Horizontal Input" and "Vertical Input" fields for each player


Vegetable Spawner

To add a vegetable:
1. Add the new vegetable's name to the "VegetableObject" script at the end of the "Vegetables" enum
2. Create a new vegetable object from the "create" menu
3. Fill in the fields with the corresponding name and images
4. Drag the object into the vegetable spawner's vegetable object field


Chopping Table

Requires no setup


Customer Manager

1. Make sure the prefabs and object references are defined in the fields at the top of the "Customer Spawner" component
2. Enter the number of vegetable types in the "Size" field and add each vegetable object to the list


Customer Spawn Points

1. Make sure the spawn points are evenly spaced from one another
2. Order the spawn points in the list form top to bottom based on which seats you would like to be filled first


Trash Can

Requires no setup


Plate

1. Create an empty game object and name it "PlateXReturnLocation" where "X" is the number of plate it is
2. Select the empty game object you just made as the reference for "Return Location" in the plate object's "PlateBehavior" component
3. Move the plate return location object to wherever in the scene you want the plate to reset to when throwing food in the trash or delivering orders
4. Move the plate object to the same transform position as the return location but do not parent either of them to one another





Notes

If I were to continue working on this project I would: 

Allow the customer spawner to adjust the time interval between customer spawns based on the game length rather than having it spawn them at a fixed interval. 

Refactor the score reader to allow players to tie if they have the same score when the game ends. 

Find more opportunities to store references to components in variables to clean up the code so there would be less "gameObject.this.that.somethingElse.thisOne".

Fix the bugs that I have found, mainly the ones involving the trash can that give null reference exceptions. 

Add a start menu with the controls or show the controls and have a start button once both players are ready. 