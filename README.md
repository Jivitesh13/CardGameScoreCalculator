

## **Task**

A card game is played and at the end of the game, a score is calculated based on the cards the 
winner has left at the end of the game. Each card (in a standard deck of cards) has a value, based on
its value and suit, according to the rules below:
- Number cards are worth their face value; e.g. 4 equals 4 points.
- A Jack is worth 11 points, a Queen 12 points, a King 13 points and an Ace 14 points.
- The suit of the card determines what to multiply the card’s value by:
o Club: Multiply by 1
o Diamond: Multiply by 2
o Heart: Multiply by 3
o Spade: Multiply by 4
For example, the Ace of Spades point value would be 56 (14 x 4).
The point values for each card are added up to give a final score. If a Joker appears anywhere in the 
list of cards, the score for that hand is doubled. 
Each card can only appear once in the list, however a Joker may appear twice (as a deck contains 
two Jokers), however a Joker cannot appear three or more times.

## **Tools Used**

Visual Studio 2019, .net core 3.1 MVC with Razor view UI

## Project Structure

Folder /CardGameScoreCalculator contains solution and project files.

**There are two projects in the solution.**

CardGameScoreCalculator.Web - Contains REST web api and Angular code. (Generated by Angular-Web api template from Visual Studio 2019)
CardGameScoreCalculator.Web.Test - Unit tests for Model, Validator and controller

**How to run the application?**

Clone or download the code locally.

Open solution file in Visual Studio 2019.

Build the project.

Run the web project in Visual Studio. 

Home page will be appeared in browser.
