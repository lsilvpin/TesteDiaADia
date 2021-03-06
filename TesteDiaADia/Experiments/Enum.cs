using System.ComponentModel;

namespace TesteDiaADia
{
    public enum Enum
    {
        [Description("Creado")]
        Created = 1,

        [Description("Acción ejecutada")]
        ActionExecuted = 2,

        [Description("Asignado")]
        Assigned = 3,

        [Description("Inicio de la ejecución")]
        ExecutionStart = 4,

        [Description("Pausa - Inicio")]
        PauseStart = 5,

        [Description("Pausa - Fin")]
        PauseEnd = 6,

        [Description("Assigned - Manual")]
        AssignedManual = 7,

        [Description("UnAssigned")]
        UnAssigned = 8,

        [Description("Application rule of return")]
        ApplicationRuleOfReturn = 9,

        [Description("Con error")]
        TicketWithError = 10,

        [Description("Liberación manual del error")]
        ManualErrorRelease = 11,

        [Description("Estado manual cambiado por un robot")]
        RobotUpdateInManualState = 12
    }
}
