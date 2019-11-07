namespace banheiro_livre.ViewModel
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T response)
        {
            Data = response;
        }

        public T Data { get; set; }
    }
}