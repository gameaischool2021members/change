### V.Ieliashevskyi workspace
# CHAINGE

**C**ollaborative **H**uman to **AI** **N**PC **G**ame **E**nvironment - is a testbed for development of Human-AI collaboration inside sandboxed game environment. The main goal is to teach agend to _anticipate_ player desires, without direct communication and other cues, simply based on player actions.
* Player can progress to the next level only in case if AI-agent correctly predicts player intent and using limited number of moves correctly helps human player to reach desired goal
  * AI-agent takes assistant (supportive) role
* Environment must **enforce** collaboration, thus eliminating options to win using _optional collaboration_
  * This is achieved using level layout and movement constraints placed on human player
  * Levels are build using 'intention based challenges' in mind
* World state observer confirms victory conditions based on actions performed by human player using standard game logic

## Summer School 2021 Jam Objectives
* Create single game level using Unity
* Implement "human proxy" to facilitate learning duration
  * Having human involved in training will lead to massive time increase, therefor is not an optimal solution
  * "Human proxy" randomly selects 1 of 3 possible desires, and one of two available actions: **Move to Desired location** or **Interact with an item to lead by example**
  * After this controls are given back to AI-agent
* Leverage Unity ml-agents to train actual AI-agent
* Allow substitution of a proxy by human input
* **Have fun and learn something new**

### Level Requirements
* 2D Grid based level with top-down camera, nothing fancy
* Composed out of simple building blocks
* Player can't reach all elements required to complete any of available objectives, but he can display intent to complete any of those
* 2-3 possible solutions that will lead to victory conditions
  * Collect cubes
  * Collect spheres
  * Open a door (gather keys)
* Non-violent level for this iteration, in other words - puzzle based

### AI requirements
* Simplified navigation (teleportation)
* Clearly defined action space
* Clearly defined world-descriptive data
* Defined reward function
  * This includes negative reward for not completing desired actions after N-moves
