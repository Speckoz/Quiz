using System.ComponentModel;

namespace Quiz.Dependencies.Enums
{
    public enum UserTypeEnum
    {
        [Description("Membro")]
        Normal,

        [Description("Administrador")]
        Admin
    }
}