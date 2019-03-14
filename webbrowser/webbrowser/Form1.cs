using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
namespace webbrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text.Trim());
            while (webBrowser1.ReadyState < WebBrowserReadyState.Complete)
                Application.DoEvents();
            HtmlElement ImageCodeTag = webBrowser1.Document.GetElementById("vcodeimg");
            Image FinalImage = GetCodeImage(webBrowser1, ImageCodeTag);

            pictureBox1.Image = FinalImage;
        }
        private Image GetCodeImage(WebBrowser webControlName,HtmlElement ImgeTag)
        {
            HTMLDocument hdoc = (HTMLDocument)webControlName.Document.DomDocument;
            HTMLBody hbody = (HTMLBody)hdoc.body;
            IHTMLControlRange hcr = (IHTMLControlRange)hbody.createControlRange();
            IHTMLControlElement hImg = (IHTMLControlElement)ImgeTag.DomElement;
            hcr.add(hImg);
            hcr.execCommand("Copy", false, null);
            Image codeImage = Clipboard.GetImage();
            return codeImage;
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
