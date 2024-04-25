**********************Elevator Simulator******************
This project was created as an challenge to create an algorithm in order to simulate the workings of an elevator system in a buiding.

Running Application
-------------------

For security the application needs to have a txt file in the project folder that contains a key in order to decrypt the connection string. 
Please contact Web Design ZA ( Jaco Hoffman : jaco@webdesignza.co.za ) for the file.

Database
--------

The database is hosted on an azure server. It consists of tables which can be populated to simulate different numbers of Buildings, Elevators, Shafts, Floors and Elevator Types.

Application UI
--------------

Application starts up with a main menu with to options :
1. Elevator Operation 
2. Exit Program

option 1 takes user to operations simulator of the elevator
option 2 exists the program

Once the user has selected the operations section, they will be taken to an option to select the building of the elevators they want to simulate (setup in the database).
When a building has been selected, they will be taken to a screen that will simulate the elevators
a visual representation of the building will be displayed that will represent the elevators.
 ------------------------------
|       Elevator1 | Elevator 2 |
-------------------------------
| Ground |                     |
| 1st    |                     |
| 2nd    |                     |
| 3rd    |                     |

and so on.

The user can either input <esc> , <Bcksp> or <x> to be taken back to the main menu.
Any other key will give the user the oportunity to input the following options to simulate the elevators
Enter Number of Passengers
Enter Pickup Floor Number
Enter Drop Off Floor number
After entering these values the application will now simulate the elevator movement by moving up and down the elevator shafts to the respective floors 
with numbers representing the number of passangers carried.
They will leave a trail of numbers to better track their movement up and down.

