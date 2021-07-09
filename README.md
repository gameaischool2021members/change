# CHANGE
**C**ollaborative **H**uman to **A**I **N**PC **G**ame **E**nvironment - is a testbed for development of Human-AI collaboration inside sandboxed game environment. 

The main goal is to teach a companion agent to _anticipate_ player desires, without direct communication and other cues, simply based on player actions.
* Players can progress to the next level only if the AI-agent can correctly predict player intent whilst minimising the number of actions taken.
  * The AI-agent plays an assistant (supportive/companion) role
  * The human player is the problem solving lead - leading the problem solving effort.
* Our gym environments aim to **enforce** collaboration, and eliminate options to win using _optional collaboration_
  * This is achieved by the level design and by placing movement constraints on the human player
  * Levels are built using 'intention based challenges' in mind
* World state observer confirms victory conditions based on actions performed by human player using standard game logic

**Team Members**: 
- LJ Arendse (@LJArendse) 🇿🇦
- Christian Cecconi (@ChristianCecconi) :it:
- Anna Dollbo (@dollbo) 🇸🇪
- Björn P Mattsson (@Plankton555) :sweden:
- Vladyslav Ieliashevskyi (@vieliashevskyi) :ukraine:

![change_world](change_world.png)

## What is CHANGE?
`CHANGE` is a gym environment for collaborative companion agents. 
In the current build there are four collaborative domains centered around human-ai team collaboration.:
- Intent and Act
- Escort Human
- Win, get cake?
- TeamAI Dungeon

## Objective
The aim of project `change` is to provide several game domains/environments which are centered around human-ai team collaboration.
Each of these environments enforce dependency on the companion agent. In other words, the human needs the help of the AI agent
companion to solve the problem. Furthermore, each problem solving collaborative game environment has:
- a shared global goal between the human and agent
- enforces collaboration between the human and ai agent, thus ensuring collaboration over optional cooperation
Regarding the problem solving effort, the human player is the leader and the ai agent is the companion assistant.
In other words, whilst the human is hypothesizing and leading the problem solving effort, how should the companion agent assist and help? 


## technology
We are thinking of using the Unity ML toolkit and the Unity ML python API, in some way to build out the game and enable agent creation.

Unity ML links:
- Unity ML agents https://github.com/Unity-Technologies/ml-agents
  - ML agents overview: https://github.com/Unity-Technologies/ml-agents/blob/main/docs/ML-Agents-Overview.md
- Unity ML getting started: https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Getting-Started.md
- How to create a new environment in Unity ML: https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Learning-Environment-Create-New.md
  - environment examples: https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Learning-Environment-Examples.md

## other collaborative game domains which inspired this project
- Minidungeons:
  - http://antoniosliapis.com/projects/project_minidungeons.php
  - gameplay: https://www.youtube.com/watch?v=8aRxeA2KA5A
- Portal 2 co-op mode
  - https://www.youtube.com/watch?v=A88YiZdXugA
- Dearth game domain
  - http://gambit.mit.edu/loadgame/dearth.php
  - gameplay: https://www.youtube.com/watch?v=fpMt3xs2Y9s
- Geometry Friends Coop Track
  - This game domain is from the "Conference on Games" (see https://ieee-cog.org/2020/competitions_conference and https://ieeexplore.ieee.org/document/7317949)
  - gameplay: https://www.youtube.com/watch?v=DBWUFRMw754

## Unity references
- Creating Your Level from a text file: https://learntocreategames.com/creating-your-level-from-a-text-file/

## Research on Human-AI Communication/Collaboration 
- https://www.aaai.org/AAAI21Papers/AAAI-8636.BansalG.pdf
- https://scholarspace.manoa.hawaii.edu/bitstream/10125/70652/0035.pdf
- https://dl.acm.org/doi/abs/10.1145/3415167
- https://arxiv.org/abs/2105.11000
- https://www.nature.com/articles/d41586-021-01170-0
