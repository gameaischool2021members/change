# CHANGE

## What is CHANGE?
**C**ollaborative **H**uman to **A**I **N**PC **G**ame **E**nvironment - is a testbed for development of Human-AI collaboration inside sandboxed game environment.
Each of presented environments enforces dependency on the AI-companion agent. In other words, the human needs the help of the AI agent to proceed. Furthermore, each problem solving collaborative game environment has:
* A shared global goal between the human and agent
* Enforces collaboration between the human and AI agent, thus ensuring collaboration over optional cooperation
 
In terms of solving effort, the human player is the leader and the AI agent is the companion assistant that tries to anticipate human intent, without any additional cues: vocal or action-based (e.g: mouse click), only based on environment observations.

The main goal is to teach a companion agent to _anticipate_ player desires, without direct communication and other cues, simply based on player actions.
* Players can progress to the next level only if the AI-agent can correctly predict player intent whilst minimising the number of actions taken.
  * The AI-agent plays an assistant (supportive/companion) role
  * The human player is the problem solving lead - leading the problem solving effort.
* Our gym environments aim to **enforce** collaboration, and eliminate options to win using _optional collaboration_
  * This is achieved by the level design and by placing movement constraints on the human player
  * Levels are built using 'intention based challenges' in mind
* World state observer confirms victory conditions based on actions performed by human player using standard game logic

Current there are 4 collaborative domains centered around Human-AI team collaboration:
- **Anticipate Intent** and **Act**
- Escort human avatar
- Win, get cake?
- TeamAI Dungeon

**Team Members**: 
- LJ Arendse (@LJArendse) 🇿🇦
- Christian Cecconi (@ChristianCecconi) :it:
- Anna Dollbo (@dollbo) 🇸🇪
- Björn P Mattsson (@Plankton555) :sweden:
- Vladyslav Ieliashevskyi (@vieliashevskyi) :ukraine:

![change_world](/images/change_world.png)

## Required Software
* Unity 2020.2.1f1 or newer
* Unity ml-agents 0.27.0 or newer
* Python 3.8.8 or newer

### Getting Started with the environment
Setting up **Python**, **Tensorflow**, **Unity** and **Unity ML-agents** does not diviate from general installation requirements. 
_We recommend to run environment on Windows machine to avoid issues with OMP._

Our agent for the "**Anticipate an Intent** and **Act**" environment can be found inside -> **IntentPredictingAgent.cs** file. This is a file to head to in order to alter agent action space, observation and reward.

## Results
We were able to successfuly train an agent that based on his observations predicted Intent displayed by a human avatar. 
System was trained on a **Human-Proxy** which displayed random intents for bot to step on a certain target platform.
**Actions space was limited to:**
* Move Right
* Move Left
* Stand Still

Agent results during the training process ->
![Training Process](/images/learning-process.png)

And our Tensorboard -> 

![Tensorboard](/images/tensorboard.png)

### Recomended Unity ML links
* [Unity ML agents](https://github.com/Unity-Technologies/ml-agents)
 * [ML agents overview](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/ML-Agents-Overview.md)
* [Unity ML getting started](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Getting-Started.md)
* [How to create a new environment in Unity ML](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Learning-Environment-Create-New.md)
 * [Environment examples](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Learning-Environment-Examples.md)

## other collaborative game domains which inspired this project
* [Minidungeons](http://antoniosliapis.com/projects/project_minidungeons.php)
  * [Gameplay Video](https://www.youtube.com/watch?v=8aRxeA2KA5A)
* [Portal 2 co-op mode](https://www.youtube.com/watch?v=A88YiZdXugA)
* [Dearth](http://gambit.mit.edu/loadgame/dearth.php)
  * [Gameplay Video](https://www.youtube.com/watch?v=fpMt3xs2Y9s)
* Geometry Friends Coop Track
  * This game domain is from the "Conference on Games" (see https://ieee-cog.org/2020/competitions_conference and https://ieeexplore.ieee.org/document/7317949)
  * [Gameplay Video](https://www.youtube.com/watch?v=DBWUFRMw754)

## Inspirational Research on Human-AI Communication/Collaboration 
- https://www.aaai.org/AAAI21Papers/AAAI-8636.BansalG.pdf
- https://scholarspace.manoa.hawaii.edu/bitstream/10125/70652/0035.pdf
- https://dl.acm.org/doi/abs/10.1145/3415167
- https://arxiv.org/abs/2105.11000
- https://www.nature.com/articles/d41586-021-01170-0
