using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace FlashCardsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Flashcard> flashcards = new List<Flashcard>();

            if (File.Exists("flashcards.json"))
            {
                string ImportedText = File.ReadAllText("flashcards.json");
                flashcards = JsonSerializer.Deserialize<List<Flashcard>>(ImportedText);
            }

            Console.Clear();


            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]What would you like to do[/]?")
                    .AddChoices(new[]
                    {
                        "Add flashcard",
                        "Study mode",
                        "Exit"
                    })
            );
            switch (choice)
            {
                case "Add flashcard":
                {
                    Console.WriteLine("Question:");
                    string question = Console.ReadLine();
                    Console.WriteLine("Answer:");
                    string answer = Console.ReadLine();
                    flashcards.Add(new Flashcard(question, answer));
                    string json = JsonSerializer.Serialize(flashcards);
                    File.WriteAllText("flashcards.json", json);
                    break;
                }

                case "Study mode":
                {
                    List<Flashcard> cardsToStudy;

                    string input = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Randomize flashcards order? \n")
                            .AddChoices(new[]
                            {
                                "YES",
                                "NO",
                            })
                    );

                    if (input == "YES")
                    {
                        cardsToStudy = flashcards.OrderBy(x => Random.Shared.Next()).ToList();
                    }
                    else
                    {
                        cardsToStudy = flashcards;
                    }

                    Console.Clear();
                    List<Flashcard> incorrect = new List<Flashcard>();

                    foreach (Flashcard flashcard in cardsToStudy)
                    {
                        AnsiConsole.Markup("[bold green]Question: [/]" + flashcard.question + "\n");

                        while (true)
                        {
                            string answer = Console.ReadLine();

                            if (answer == "1")
                            {
                                Console.WriteLine("Word starts with: " + flashcard.answer[0]);
                                continue;
                            }

                            if (answer.ToLower().Trim() == flashcard.answer)
                            {
                                AnsiConsole.Markup("[bold green]Correct!\n[/]");
                                break;
                            }
                            else
                            {
                                AnsiConsole.Markup("[bold red]Incorrect! [/] Correct answer is " + flashcard.answer);
                                incorrect.Add(flashcard);
                                System.Threading.Thread.Sleep(2000);
                                break;
                            }
                        }

                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }

                    if (incorrect.Count > 0)
                    {
                        AnsiConsole.Markup("[bold green]You need to study:\n[/]");
                        
                        foreach (Flashcard flashcard in incorrect)
                        {
                            Console.WriteLine();
                            AnsiConsole.Markup("[bold green]"+ flashcard.question + "\n[/]");
                            Console.WriteLine(flashcard.answer);
                        }

                        Console.WriteLine();
                    }

                    break;
                }
                case "Exit":
                {
                    break;
                }
            }
        }
    }
}