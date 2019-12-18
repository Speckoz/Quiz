using Newtonsoft.Json;

namespace MobileQuiz.Models
{
    public class QuestionModel
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Question { get; set; }

        [JsonProperty]
        public string CorrectAnswer { get; set; }

        [JsonProperty]
        public string Category { get; set; }

        [JsonProperty]
        public string IncorrectAnswers { get; set; }

        [JsonConstructor]
        /// <summary>
        ///
        /// </summary>
        /// <param name="str">
        /// <para>0 - <see cref="Id"/></para>
        /// <para>1 - <see cref="Question"/></para>
        /// <para>2 - <see cref="CorrectAnswer"/></para>
        /// <para>3 - <see cref="Category"/></para>
        /// <para>4 - <see cref="IncorrectAnswers"/></para>
        /// </param>
        public QuestionModel(string id, string qt, string ca, string c, string ia)
        {
            Id = id;
            Question = qt;
            CorrectAnswer = ca;
            Category = c;
            IncorrectAnswers = ia;
        }

        [JsonConstructor]
        public QuestionModel() { }
    }
}