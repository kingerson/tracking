namespace Trackings.Application.Utility
{
    public class AreaValidationMessages
    {
        public const string NAME_EMPTY = "Debe ingresar el nombre del área.";
        public const string NAME_LENGTH = "La longitud del nombre no debe sobrepasar los 50 caracteres.";
        public const string NAME_INVALID = "El nombre solo permite campos dentro del alfabeto";

        public const string DESCRIPTION_EMPTY = "Debe ingresar la descripción del área.";
        public const string DESCRIPTION_LENGTH = "La longitud del nombre no debe sobrepasar los 150 caracteres.";

        public const string AREA_INVALID_STATUS = "No puede registrar un Área en estado inactivo";
        public const string AREA_NAME_REPEATED = "El nombre del Área ya se encuentra registrado.";

        public const string INSERT_FAIL = "Hubo un problema al realizar el registro del Área.";
        public const string UPDATE_FAIL = "Hubo un problema al realizar el registro del Área.";
    }

    public class ItemComponentMessages
    {
        public const string NAME_EMPTY = "Debe ingresar el nombre del componente.";
        public const string NAME_LENGTH = "La longitud del nombre no debe sobrepasar los 50 caracteres.";
        public const string NAME_INVALID = "El nombre solo permite campos dentro del alfabeto";

        public const string DESCRIPTION_EMPTY = "Debe ingresar la descripción del componente.";
        public const string DESCRIPTION_LENGTH = "La longitud del nombre no debe sobrepasar los 150 caracteres.";

        public const string AREA_INVALID_STATUS = "No puede registrar un Componente en estado inactivo";
        public const string AREA_NAME_REPEATED = "El nombre del Componente ya se encuentra registrado.";

        public const string INSERT_FAIL = "Hubo un problema al realizar el registro del Área.";
        public const string UPDATE_FAIL = "Hubo un problema al realizar el registro del Área.";
    }
}
