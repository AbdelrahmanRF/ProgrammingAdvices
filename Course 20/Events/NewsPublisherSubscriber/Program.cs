using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisherSubscriber
{
    class NewsArticle
    {
        public string Title { get; }
        public string Content { get; }

        public NewsArticle(string Title, string Content)
        {
            this.Title = Title; 
            this.Content = Content;
        }
    }

    class NewsPublisher
    {
        public event EventHandler<NewsArticle> ArticlePublished;

        public void Publish(string Title, string Content)
        {
            NewsArticle newsArticle = new NewsArticle(Title, Content);

            OnArticlePublished(newsArticle);
        }

        private void OnArticlePublished(NewsArticle Article)
        {
            ArticlePublished?.Invoke(this, Article);
        }
    }

    class NewsSubscriber
    {
        public string Name { get; }

        public NewsSubscriber(string Name)
        {
            this.Name = Name;
        }

        public void Subscribe(NewsPublisher Article)
        {
            Article.ArticlePublished += HandelArticlePublished;
        }

        public void UnSubscribe(NewsPublisher Article)
        {
            Article.ArticlePublished -= HandelArticlePublished;
        }

        private void HandelArticlePublished(object sender, NewsArticle Article)
        {
            Console.WriteLine("\nArticle Published");
            Console.WriteLine($"Subscriber Name : {Name}");
            Console.WriteLine($"Article Title   : {Article.Title}");
            Console.WriteLine($"Article Content : {Article.Content}\n");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            NewsPublisher newsPublisher = new NewsPublisher();
            NewsSubscriber newsSubscriber1 = new NewsSubscriber("Subscriber 1");
            NewsSubscriber newsSubscriber2 = new NewsSubscriber("Subscriber 2");

            newsSubscriber1.Subscribe(newsPublisher);
            newsSubscriber2.Subscribe(newsPublisher);

            newsPublisher.Publish("Apples", "A fruit. They are red, green, or yellow. They grow on trees and are crunchy.");

            newsSubscriber1.UnSubscribe(newsPublisher);

            newsPublisher.Publish("Fish", "They swim. They use fins. Many live in the water, from small to big.");
        }
    }
}
