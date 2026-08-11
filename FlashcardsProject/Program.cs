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
				string ImportedFlashcards =  JsonSerializer.Deserialize<List<Flashcard>>(File.ReadAllText("flashcards.json"));
			}
			else
			{
				
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