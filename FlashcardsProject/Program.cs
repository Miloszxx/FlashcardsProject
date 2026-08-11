using System; 

namespace FlashCardsProject
{
	class Program
	{
		static void Main(string[] args)
		{
			
		}
	}

	class Flashcard
	{
		public string question {get; set; }
		public string answer {get; set; }

		public Flashcard(string question, string answer)
		{this.question = question ;this.answer = answer;}
			
	}
}