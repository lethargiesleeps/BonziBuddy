using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms;

public partial class Article : Form
{
    public Article(string title, string summary)
    {
        InitializeComponent();
        titleLabel.Text = title.Split(": ")[1];
        summaryBox.Text = summary;
        dateLabel.Text = PersistenceHelper.ArticlePublishDate;
        linkLabel.Text = "View Online";
        linkLabel.Links.Add(0, PersistenceHelper.ArticleUrl.Length, PersistenceHelper.ArticleUrl);
    }

    private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        UIHelper.OpenUrl(PersistenceHelper.ArticleUrl);
        Dispose(true);
        Close();
    }


    private void closeButton_Click(object sender, EventArgs e)
    {
        Dispose(true);
        Close();
    }
}