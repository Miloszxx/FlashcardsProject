namespace FlashCardsProject;
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