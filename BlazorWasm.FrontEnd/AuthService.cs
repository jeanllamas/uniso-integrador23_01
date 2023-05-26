// AuthService.cs
using System;

public class AuthService
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public bool RealizarLogin(string email, string senha)
    {
        // Verificar as credenciais do cliente
        // Se as credenciais forem válidas, armazenar as informações do cliente
        // Caso contrário, retorne false

        // Exemplo de código:
        if (email == "cliente@example.com" && senha == "senha")
        {
            Nome = "Nome do Cliente";
            Sobrenome = "Sobrenome do Cliente";
            return true;
        }

        return false;
    }

    public void Logout()
    {
        // Limpar as informações do cliente
        Nome = string.Empty;
        Sobrenome = string.Empty;
    }
}
