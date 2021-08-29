# Irees Toy Robot Simulator
<b> Toy Robot Code Challenge </b>

This toy robot simulator is a C# .Net solution which moves the toy on a square table top, of dimensions 5 units x 5 units. There are no other obstructions on the table surface. The robot is free to roam around the surface of the table and prevented from falling to destruction. 
Any movement that would result in the robot falling from the table is ignored, however further valid movement commands are allowed.

<h3> Instructions and Design Patterns </h3>
User inputs are validated and return appropriate object types or error messages through classes, and the class methods are unit tested before being set to work with the rest of the application. The following commands are read by the application:

<ul>
  <li>PLACE X,Y,FACING : This puts the toy on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. If the toy is already placed, issuing another valid PLACE command will place the toy in the newly specified location.</li>
  <li>MOVE : This moves the toy one unit forward in the direction it is currently facing.</li>
  <li>LEFT : This rotates the toy 90 degrees to the left (i.e. counter-clockwise) without changing the position.</li>
  <li>RIGHT : This rotates toy 90 degrees to the right (i.e. clockwise) without changing the position. </li>
  <li>REPORT : This announces the X,Y and direction of the toy by printing to the console. </li>
</ul>


<h3> Testing Framework </h3>
Unit tests are created using MSTest framework. The test project is called ToyRobotSimulator.Test which can be found <a href="https://github.com/imranahmedDFC/IreesToyRobotSimulator/tree/master/ToyRobotSimulator.Test">here<a/>

<h3> Running Robot Simulator Application </h3>
There is a single executable file which runs the application and it can be run by double clicking it. The above mention instructions or on screen instructions can be followed to type the user input commands. The executable file is located <a href="https://github.com/imranahmedDFC/IreesToyRobotSimulator/blob/master/ToyRobotSimulator.exe">here.</a>
  
<h3> Supported Operating Systems </h3>
The simulator application has been developed on 64-bit Windows operating system and it should run Windows environment.

<h3> CD/CI Pipeline </h3>
Continuous Integration is been setup using GitHub Action Workflow. Whenever there is a new commit to the repository the workflow will be triggered which will check the build and run all test cases, the workflow file is located <a href="https://github.com/imranahmedDFC/IreesToyRobotSimulator/blob/master/.github/workflows/ToyRobotSimulator.yml"> here.</a>
