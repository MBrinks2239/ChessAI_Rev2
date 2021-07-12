# ChessAI_Rev2
## Content
* [How to use](https://github.com/MBrinks2239/ChessAI_Rev2/new/main?readme=1#how-to-use)
* [A word](https://github.com/MBrinks2239/ChessAI_Rev2/new/main?readme=1#a-word)
* [Features](https://github.com/MBrinks2239/ChessAI_Rev2/new/main?readme=1#features)

## How to use
Install the installer from the [Releases](https://github.com/MBrinks2239/ChessAI_Rev2/releases) page. 
You can either train your own AI or use the supplied file found with the installer on the releases page.
Choose Player vs Player, Player vs AI, or AI vs AI!

(Most things said here are not yet in the program)

## A word
I am making this after making [Hexapawn](https://github.com/MBrinks2239/Hexapawn). 
I made Hexapawn when I was in my final year of high school.

Look / use it at your own discretion. The code is very bad and it barely functions. 
I'm still not 100% sure if it actually does what it is suppose to.
If you do decide to use please read the Read me very carefully. (Trust me)

This chess AI will add things that I could not add in hexapawn like Player vs AI.
It will fix problems and best of all it will be coded way better. For more features look at [features](https://github.com/MBrinks2239/ChessAI_Rev2/new/main?readme=1#features).

This will not work on the same principle as hexapawn. Hexapawn worked in a way that for each win the moves it player got rewarded with a win point and losing a game gave it a loss point.
The AI then decided the best move. This would technicaly still work for regular chess. There is a big problem though. After 5 moves, there are already 69,352,859,712,417 different states. 
If we want to have a *working* AI we want it to at least have 10 data points on every move. Lets do the math. Lets say one entire chess match takes 50 ms. This is not based on anything just a wild guess.
If we want our AI to play 5 rounds of chess we need 1,099,582 to train it. Oh sorry I forgot to metion those are years. Yeah... So that is not going to happen. Instead I will be doing it more like other chess bots do it.
I will setup a system that will determine how well the bot is doing by calculating how active its pieces are, how many pieces it has remaining after a turn and other thing to calculate the best move. 
This does take the AI part out of this AI. I am not sure if I will change the project or if I will change something to make it an AI. I will figure this out whilst I code. Lets start small and actually build chess first.

## Features
Here is a list of featers that are either: Already added, In progress, TODO, or Removed.

### Added
* Most movement
* Board reset
* Player vs player

### In progress
* Check / check mate
* Knight and King movement
* Visualize movement

### TODO
* The AI

### Removed
Nothing as of now
