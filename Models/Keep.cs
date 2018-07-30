namespace keepr.Models
{

    public class Keep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int views { get; set; }
        public int keeps { get; set; }
        public int Public { get; set; }
        public string AuthorId { get; set; }

        public Keep()
        {
            Public = 1;
        }
    }



}