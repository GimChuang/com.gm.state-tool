# Unity State Tool 🎮

![StateTool_Example](https://github.com/GimChuang/com.gm.state-tool/blob/master/readme_information/StateTool_Example.jpg)

A component based tool to achieve State Pattern in Unity.

Please check out the sample scene called **Test_StateTool** in *Test* folder. If you cannot open the scene, copy it to your Assets folder.

How to Use
---
1. **Create GameStateManager**
   Create a gameobject and add **GameStateManager** script to it.

2. **Create GameStates**
   Create several gameobjects and add **GameState** script to them separately. How many GameStates to create? It depends on your game design. For example, if there are *StandBy*, *CountDown*, *Playing*, *GameOver* states in my game then I create 4 GameStates.

3. **Hook up GameStates**
   Drag **GameState** gameobjects you just created into **GameStateManager**'s `States` array in the inspector. Note that the order has to to match your game design.

4. **Add GameState Logic**
   You'll find **StateLogicChecker**s in StateLogicChecker folder. They're going to help checking:  "if some situation is achieved, then we can go to the next GameState!".
Add one (or multiple, if you want) **StateLogicChecker** script to the GameState gameobjects you just created. 
For example, attach a StateButtonChecker to my *StandBy* GameState gameobject so the game goes to *CountDown* GameState when a specified button is pressed.
There are several types of  **StateLogicChecker**:
        - **StateAnimChecker**: check if an animation is completed
        - **StateButtonChecker**: check if a UI button is pressed
        - **StateHoverChecker**: check if a gameobject has been hovered over some duration
        - **StateKeyChecker**: check if a key is pressed
        - **StateTimeChecker**: check if time has passed over some duration
        
5. **Add GameState Transition (optional)**
   **StateTransitionSetter** is helpful if you want some transition between **GameStates**.
Attach one to a GameState's gameobject, and assign it to `StateTransitionSetter` field in the inspector.
eg. Add a **CanvasGroupTransition** script to my *StandBy* GameState, assign my *StandBy* UI cancas group, and set the transition durations. The canvas group will fade in when *StandBy* GameState enters and fade out when it exits.

6. **You're all set**
   Press play. **GameStateManager** automatiically starts the gameflow. The first **GameState** enters. The **StateLogicChecker** attached to this **GameState** checks if the situation you specified is achieved. If yes, current **GameState** exits and the next **GameState** enters.


How to Install with Unity Package Manager
---
In the `dependencies` section of your 'manifest.json', add
```
"com.gm.state-tool": "https://github.com/GimChuang/com.gm.state-tool.git"
```
(don't forget to add a comma if you need one)
