namespace Store.Core.DbContext;

public class LiteDbOptions
{
    public const string SectionName = "LiteDbOptions";

    public string DatabaseLocation { get; set; }
    public string CollectionName { get; set; }
}
