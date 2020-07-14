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