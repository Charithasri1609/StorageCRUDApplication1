namespace StorageCRUDApplication.Models
{
    public class TableEntity : Microsoft.Azure.Cosmos.Table.TableEntity
    {
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
