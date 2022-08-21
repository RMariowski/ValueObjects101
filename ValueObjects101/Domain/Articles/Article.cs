namespace ValueObjects101.Domain.Articles;

public class Article
{
    public long Id { get; private set; }
    public string Text { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    public Article(string text)
    {
        Text = text;
        CreatedAt = DateTime.UtcNow;
    }

    private Article()
    {
    }
}
