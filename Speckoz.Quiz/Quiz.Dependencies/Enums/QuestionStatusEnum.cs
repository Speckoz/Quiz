using System.ComponentModel;

namespace Quiz.Dependencies.Enums
{
    public enum QuestionStatusEnum
    {
        [Description("Aprovada")]
        Approved,

        [Description("Pendente")]
        Pending,

        [Description("Negada")]
        Denied
    }
}