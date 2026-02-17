# Overview

My purpose in creating this project was to familiarize myself with the Unity game engine and to practice using C#. I began working on a tutorial called Sprite Flight from the Unity Hub Learning Center. It was extremely informative and pivotal to my success in creating my Pong project. The Sprite Flight content was modern and up to date.

The Pong tutorials and articles I found online were over six years old. Many of the libraries and modules they used were deprecated, which turned out to be a helpful learning experience. It forced me to figure out how to accomplish tasks like handling audio and detecting user input using current Unity tools, rather than simply following exact solutions.

This has been a fun project and a great introduction to creating 2D games in Unity.

My Pong game operates similarly to the classic arcade version. The player moves the left paddle up and down using the arrow keys, while the right paddle is controlled by a basic AI. The AI works well initially, but the speed and bounce of the ball increase with each round, making the game progressively more challenging. Scores for both the player and the computer are displayed at the top of the screen on their respective sides. The tutorials I followed did not cover adding sound, so I implemented audio feedback myself for paddle hits and scoring.

I did spend time learning how to use Unity, this is the pre-project that I created through tutorials and challenges that helped me do that. This is the Unity Play link for it: https://play.unity.com/en/games/9ce95fda-eb2b-4c48-ba55-da5aed69eb7c/web-builds

# Demo video

[Pong Demo Video](https://www.loom.com/share/bd307d4c52e14d7eb679cb10bbff2292)

# How to View the Project

You can play the game directly in your web browser using the Unity Play link below—no installation is required. Simply click the link, and the game will load.

GAME LINK
https://play.unity.com/en/games/655580bc-dd6a-4041-8c83-05e9d18c46b2/pong

Instructions for playing:

Move the player paddle: Use the Up and Down arrow keys to move the left paddle.

Game objective: Try to prevent the ball from passing your paddle while the AI controls the right paddle.

Scoring: Each time the ball passes a paddle, the opposite side scores a point. Scores are displayed at the top of the screen.

Restart the game: Press R to start a new game.

# Development Environment

Tools Used:

Unity Hub 3.16.1

Visual Studio Code with Unity extension

GitHub and Git

C# programming language

C# is the primary language used in Unity to control game behavior. It allows you to write scripts that handle player movement, collisions, keyboard or mouse input, scoring, and UI updates. Unity provides many built-in components, such as Rigidbody, Transform, and AudioSource, which your scripts can interact with. Methods like Update() run every frame to check input or update visuals, while FixedUpdate() runs at fixed intervals for physics calculations. C# gives you precise control over how your game objects behave and respond to events.

Although C# is used, this project is not a standard .NET application; it uses the Unity-specific C# extension and runtime.

# Useful Websites

- [Pong in Unity Video](https://www.youtube.com/watch?v=AcpaYq0ihaM)
- [Unity for first time users](https://docs.unity3d.com/Manual/first-time-user.html)
- [Learn Unity site](https://learn.unity.com/course/2d-beginner-game-sprite-flight)
- [My finished tutorial game project](https://play.unity.com/en/games/9ce95fda-eb2b-4c48-ba55-da5aed69eb7c/web-builds)
- [Ten minute Unity](https://www.youtube.com/watch?v=7z0hKe9KaAc)
- [Pong Unity Retro video game](https://www.youtube.com/watch?v=OYqA6c_VWck)
- [Sprite Flight Unity](https://www.youtube.com/watch?v=BS3crUA9Xzk&t=338s)
- [Online Unity Manual, C# for Unity documentation](https://docs.unity.com/en-us)

- 2/3/26 — 3 hours: Researching Unity, installing software, creating GitHub repo, watching tutorial videos.
- 2/4/26 — 4 hours: Watching videos and reading Unity Hub documentation.
- 2/12/26 — 2 hours: Began Sprite Flight tutorials and extra challenges.
- 2/13/26 — 3 hours: Continued tutorials, learned how to use sound in Unity.
- 2/14/26 — 2 hours: Finished Sprite Flight, created Pong project.
- 2/15/26 — 12 hours: Published to Unity Play, debugged and tested Pong project, recorded demo video, and submitted.
