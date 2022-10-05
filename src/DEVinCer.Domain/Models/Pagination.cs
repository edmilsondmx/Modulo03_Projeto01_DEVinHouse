namespace DEVinCer.Domain.Models;

public class Pagination
{
    public int Take { get; set; }
    public int Skip { get; set; }

    public Pagination(int take, int skip)
    {
        Take = take;
        Skip = skip;
    }
    public Pagination()
    {
        
    }
}
