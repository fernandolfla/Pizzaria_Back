namespace Pizzaria_back.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        void Inserir(T objeto);
        void Atualizar(T objeto);
        void Deletar(int id);
        List<T> Buscar();
        T? Buscar(int id);
        bool Validar(T objeto);
       
    }
}
