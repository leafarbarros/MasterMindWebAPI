using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMind.Entity
{
    public class Guess
    {
        public User User { get; set; }

        public GameColor[] Colors { get; set; }

        private EnumFeedback[] _feedback { get; set; }
        public EnumFeedback[] Feedback { get { return _feedback; } }

        public Guess(User user, GameColor[] colors)
        {
            User = user;
            Colors = colors;
        }

        public bool IsTheFeedbackTheCorrectAnswer
        {

            get
            {
                return Feedback.All(feedbackItem => feedbackItem == EnumFeedback.Correct);
            }

        }

        public void FillFeedbackFromCorrectAnwser(GameColor[] correctAnswer)
        {
            _feedback = new EnumFeedback[correctAnswer.Length];

            for (int i = 0; i < correctAnswer.Length; i++)
            {
                FillFeedbackItem(correctAnswer, i);
            }

        }

        private void FillFeedbackItem(GameColor[] correctAnswer, int i)
        {
            if (correctAnswer[i].Equals(Colors[i]))
            {
                _feedback[i] = EnumFeedback.Correct;
            }
            else if (correctAnswer.Any(c => c.Equals(Colors[i])))
            {
                _feedback[i] = EnumFeedback.FoundButNotCorrect;
            }
            else
            {
                _feedback[i] = EnumFeedback.NotFound;
            }
        }


    }
}
