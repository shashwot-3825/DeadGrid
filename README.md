================================================================================

       SEMESTER PROJECT PROPOSAL: 3D PHYSICS-BASED LOGIC & DSA PUZZLE GAME

================================================================================



1. PROJECT OVERVIEW & PROBLEM STATEMENT

--------------------------------------------------------------------------------

This project proposes the design and development of a 3D, closed-world, 

physics-based puzzle-solving game built in the Unity Engine. The player assumes 

full third-person kinematic control over a protagonist trapped within a 

self-contained, interactive facility and must manipulate environmental objects 

to solve spatial, mechanical, and algorithmic challenges.



The primary academic objective of this project is to bridge theoretical computer 

science concepts with real-time interactive simulation. Rather than treating 

algorithms as abstract backend routines, core Data Structures & Algorithms 

(such as Breadth-First Search) and Digital Logic Gates are engineered directly 

into the game's core mechanics, physics interactions, and level progression.





2. TECHNOLOGY STACK & DEVELOPMENT ENVIRONMENT

--------------------------------------------------------------------------------

- Game Engine & Rendering: Unity 6 utilizing the Universal Render Pipeline (URP) 

  for real-time lighting, shadow mapping, and post-processing.

- Programming Language: C# (Object-Oriented Programming, Event-Driven Architecture)

- Runtime & Framework: .NET SDK

- Integrated Development Environment (IDE): Visual Studio Code (with C# Dev Kit)

- Physics & Collision Engine: Unity Physics (Rigidbodies, Colliders, Raycasting)

- Version Control & CI/CD Workflow: Git & GitHub (Distributed repository management)





3. CORE GAMEPLAY MECHANICS & ENGINE TECHNIQUES

--------------------------------------------------------------------------------

- Kinematic & Rigid-Body Physics Simulation:

  The player navigates a 3D environment using a Character Controller governed by 

  custom gravitational acceleration and vector velocity calculations. Environmental 

  puzzles utilize dynamic Rigidbodies, collision meshes, and Physics Raycasting 

  to detect, grab, and apply force vectors to weighted objects.



- State-Machine Driven Character Animation:

  Character locomotion and environmental interactions are managed via a Finite 

  State Machine (FSM) within Unity's Animator Controller, utilizing parameter 

  transitions, inverse kinematics (IK), and root-motion blending.



- Event-Driven Architecture (Observer Pattern):

  To keep gameplay systems decoupled and scalable, environmental triggers (such 

  as pressure plates, switches, and laser receivers) broadcast state changes 

  using C# Delegates and Events rather than relying on expensive frame-by-frame 

  polling.





4. ALGORITHMIC & DIGITAL LOGIC IMPLEMENTATION (DSA & GATES)

--------------------------------------------------------------------------------

A. Boolean Algebra & Digital Logic Gate Systems

   - Architectural Design: Environmental actuators (security doors, moving 

     platforms, energy barriers) serve as binary outputs driven by virtual 

     AND, OR, NOT, NAND, and XOR logic gates.

   - Technical Implementation: Each interactive trigger acts as a binary input 

     node emitting boolean states (`true`/`false` or `1`/`0`). Modular C# gate 

     classes evaluate bitwise and logical operations across multiple inputs in 

     real time. Complex multi-stage puzzles are constructed by chaining gate 

     outputs as inputs into higher-order combinational logic circuits.



B. Graph Theory & Breadth-First Search (BFS) Traversal

   - Architectural Design: Grid-based floor conduits, energy-routing puzzles, 

     and automated pathfinding guidance systems are modeled as unweighted graphs.

   - Technical Implementation: 

     1. Energy Conduit & Grid Verification: Puzzle grids are represented in C# 

        as Adjacency Lists or 2D node matrices. When a player alters the 

        orientation or position of conductive blocks, a Queue-based Breadth-First 

        Search (`Queue<Node>`) executes from the power source vertex to determine 

        reachability and compute the shortest valid path to the exit terminal.

     2. Unweighted Shortest-Path Guidance: A companion scanner/hint mechanic 

        utilizes BFS across room waypoint graphs to calculate and visually render 

        the optimal shortest path toward active puzzle objectives.



C. Core Data Structures Utilized

   - Queues (`Queue<T>`): Used for First-In-First-Out (FIFO) frontier exploration 

     during Breadth-First Search graph traversals.

   - Stacks (`Stack<T>`): Used for Last-In-First-Out (LIFO) state history tracking, 

     enabling a "Time Rewind / Undo Move" mechanic by pushing and popping spatial 

     transform coordinates (`Vector3` & `Quaternion`).

   - HashSets & Dictionaries (`HashSet<T>`, `Dictionary<TKey, TValue>`): Used to 

     achieve $O(1)$ average time-complexity lookups when tracking visited graph 

     vertices during BFS and mapping unique node IDs to world objects.





5. EXPECTED OUTCOMES & DELIVERABLES

--------------------------------------------------------------------------------

- A fully playable 3D closed-world prototype featuring multiple interconnected 

  puzzle chambers.

- Modular, reusable C# codebase demonstrating clean Object-Oriented Design 

  principles (Encapsulation, Polymorphism, and Inheritance).

- Visualized algorithmic execution where players directly observe Boolean logic 

  propagation and BFS graph traversal in real time.

================================================================================
