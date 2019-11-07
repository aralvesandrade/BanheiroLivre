namespace banheiro_livre.ViewModel
{
    public class AdicionarBanheiroPostRequest
    {
        public string Descricao { get; set; }
    }

    public class AdicionarBanheiroPostResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}