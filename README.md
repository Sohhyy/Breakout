# Breakout

A breakout game with two levels and one multiball powerup

## Unity Version
2020.3.36f1

## Platform
Windows

## How to play
Use A/D or ←→ to control the paddle. <br/>
Press Space to launch the ball.<br/>
Collect blue powerup to trigger multiball.

## Scripts
There are 10 scripts in total.<br/>
Ball.cs: Ball Class which controls the launch, movement and collision of the ball. <br/>
BallManager.cs: Ball manager which controls the spawn, reset, clear of all the balls in the game <br/>
Brick.cs: Brick class which controls the collision of the brick. <br/>
BrickManager.cs: Brick Manager which controls creating, reseting and destorying levels<br/>
Paddle.cs: Paddle class which controls the movement of the paddle.<br/>
Collectable.cs: Abstract Class for all collectable powerups.<br/>
MultiBalls.cs: Multiball powerup.<br/>
CollectableManager.cs: Collectable Manager which controls the spawn of collectable powerups and the clear of powerups<br/>
UIManager.cs: UI Manager which manages all the UI function.<br/>
GameManager.cs: Game Manager which controls the game flow, score and life.<br/>
