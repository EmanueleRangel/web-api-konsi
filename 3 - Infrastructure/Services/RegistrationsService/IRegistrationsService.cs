public interface IRegistrationsService
{
    List<Registration> GetMatriculas(string cpf);
    void IndexarMatriculas(string cpf, List<Registration> registrations);
    Registration CreateMatricula(Registration registration);
    Registration UpdateMatricula(Registration registration);
    void DeleteMatricula(string cpf, int registrationId);
}
