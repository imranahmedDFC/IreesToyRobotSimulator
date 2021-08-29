# IreesToyRobotSimulator
<b> Toy Robot Code Challenge </b>

This toy robot simulator is a C# .Net solution which moves the toy on a square table top, of dimensions 5 units x 5 units. There are no other obstructions on the table surface. The robot is free to roam around the surface of the table and prevented from falling to destruction. 
Any movement that would result in the robot falling from the table is ignored, however further valid movement commands are allowed.

<h3> Instructions and Design Patterns </h3>
User inputs are validated and return appropriate object types or error messages through classes, and the class methods are unit tested before being set to work with the rest of the application. The following commands are read by the application:

  PLACE X,Y,F 
  MOVE  
  LEFT  
  RIGHT  
  REPORT  
  
PLACE X,Y,FACING : This puts the toy on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. If the toy is already placed, issuing another valid PLACE command will place the toy in the newly specified location.
MOVE : This moves the toy one unit forward in the direction it is currently facing.
LEFT : This rotates the toy 90 degrees to the left (i.e. counter-clockwise) without changing the position.
RIGHT : This rotates toy 90 degrees to the right (i.e. clockwise) without changing the position.
REPORT : This announces the X,Y and direction of the toy by printing to the console.

