This is my pet project in the 2d platformer genre. in this project, I tried to implement a flexible and extensible architecture. 
I chose the Bootstrap approach for initialization, as I considered it an ideal solution for a small project. 
To notify classes about important events, I chose EventBus. The player himself is represented by the State pattern, which I create with the Factory pattern. 
Although there is very little UI in this game, I separated its model from the visual. 
In the game, you need to collect all the keys to the levels to pass to the next level, traps are presented in the form of spikes that cause damage.
