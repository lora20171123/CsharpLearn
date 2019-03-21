using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test321
{
    public class DocumentManager<TDocument>
        where TDocument:IDocument
    {
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();
        public void AddDocument(TDocument doc)
        {
            lock(this)
            {
                documentQueue.Enqueue(doc);
            }
        }
        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }
       //----------------默认值
        public TDocument GetDocument()
        {
            TDocument doc = default(TDocument);//default 用于将泛型类型初始化为null或者0
            lock(this)
            {
                doc = documentQueue.Dequeue();

            }
            return doc;
        }

        public void DisplayAllDocument()
        {
            foreach (TDocument doc in documentQueue)
            {
                Console.WriteLine(((IDocument)doc).Title);
            }
        }
        public static void Main(string[] args)
        {
            var dm = new DocumentManager<Document>();
            dm.AddDocument(new Document("Title A","Simple A"));
            dm.AddDocument(new Document("Title B","Simple B"));

            dm.DisplayAllDocument();
            if(dm.IsDocumentAvailable)
            {
                Document d = dm.GetDocument();
                Console.WriteLine(d.Content);
            }
        }
    }
    //----------------约束
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }

    public class Document : IDocument
    {
        public Document()
        {

        }
        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    
   
}
