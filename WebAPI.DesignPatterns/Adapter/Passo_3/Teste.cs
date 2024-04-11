using WebAPI.DesignPatterns.Adapter.Passo_1;
using WebAPI.DesignPatterns.Adapter.Passo_2;

namespace WebAPI.DesignPatterns.Adapter.Passo_3;

public class Teste
{
    public Teste()
    {
        // Testando a funcionalidade Adapter
        string[,] employeesArray = new string[5, 4]
        {
            {"101","John","SE","10000"},
            {"102","Smith","SE","20000"},
            {"103","Dev","SSE","30000"},
            {"104","Pam","SE","40000"},
            {"105","Sara","SSE","50000"}
        };
        ITarget target = new TurnArrayInListAdapter();
        target.TurnArrayInList(employeesArray);
    }
}
