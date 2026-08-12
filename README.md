# Flashcards CLI

A simple terminal app written in C# to create and review study flashcards. Card data is automatically saved to a local `flashcards.json` file.

## Features

- **Add flashcards:** Quickly input new question and answer pairs.
- **Study mode:** Interactively review your cards with instant feedback.
- **Randomize order:** Option to shuffle cards before starting a review session.
- **Review mistakes:** Automatically lists all incorrectly answered cards at the end of a run.
- **JSON persistence:** Uses `System.Text.Json` to save and reload your deck between sessions.

## Built With

- C# / .NET
- `System.Text.Json`
- LINQ

## How to Run

1. Make sure you have the [.NET SDK](https://dotnet.microsoft.com/) installed.
2. Clone the repository:
   ```bash
   git clone [https://github.com/Miloszxx/FlashcardsProject.git](https://github.com/Miloszxx/FlashcardsProject.git)
