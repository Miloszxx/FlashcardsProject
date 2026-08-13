using System; 
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

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

			int choice = 0;
			Console.Clear();
			while (choice != 3)
			{
				Console.WriteLine("What would you like to do?");
				Console.WriteLine("1. Add flashcard");
				Console.WriteLine("2. Study mode");
				Console.WriteLine("3. Exit");
				if (!int.TryParse(Console.ReadLine(), out choice))
				{
					Console.WriteLine("Wrong input");
					continue;
				}
				switch (choice)
				{
					case 1:
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

					case 2:
						Console.WriteLine("Randomize flashcards order? y/n");
						string input = Console.ReadLine();
						List<Flashcard> cardsToStudy;

						
						if (input != null && input.ToLower().Trim() == "y")
						{
							cardsToStudy = flashcards.OrderBy(x => Random.Shared.Next()).ToList();
						}
						else
						{
							cardsToStudy = flashcards; 
						}
						System.Threading.Thread.Sleep(1000);	
						Console.Clear();
						List<Flashcard> incorrect = new List<Flashcard>();
						
						foreach (Flashcard flashcard in cardsToStudy)
						{
							Console.WriteLine("Question: " + flashcard.question);
							string answer = Console.ReadLine();
							if (answer.ToLower().Trim() == flashcard.answer)
							{
								Console.WriteLine("Correct!");
							}
							else
							{
								Console.WriteLine("Incorrect! Correct answer is " +  flashcard.answer );
								incorrect.Add(flashcard);
							}
							System.Threading.Thread.Sleep(1000);
							Console.Clear();

						}

						if (incorrect.Count > 0)
						{
							Console.WriteLine("You need to study: "); ;
							foreach (Flashcard flashcard in incorrect)
							{
								Console.WriteLine();
								Console.WriteLine(flashcard.question);
								Console.WriteLine(flashcard.answer);
							}
							Console.WriteLine();
						} 
						break;
				}
				
			}

		}
	}
}