using System; 
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

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

			while (choice != 3)
			{
				Console.WriteLine("What would you like to do?");
				Console.WriteLine("1. Add flashcard");
				Console.WriteLine("2. Study mode");
				Console.WriteLine("3. Exit");
				choice = Convert.ToInt32(Console.ReadLine());
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
						Console.Clear();
						List<Flashcard> incorrect = new List<Flashcard>();
						foreach (Flashcard flashcard in flashcards)
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
							Console.Write("You need to study: ");
							foreach (Flashcard flashcard in incorrect)
							{
								Console.WriteLine("\n");
								Console.WriteLine(flashcard.question);
								Console.WriteLine(flashcard.answer);
							}
						}

						break;
				}
				
			}

		}
	}

	class Flashcard
	{
		
		public string question {get; set; }
		public string answer {get; set; }

		public Flashcard()
		{
		}

		public Flashcard(string question, string answer)
		{this.question = question ;this.answer = answer;}
			
	}
}