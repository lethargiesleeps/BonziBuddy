using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms;

/// <summary>
/// Form for displaying content of an Article.
/// <see cref="NewsForm"/>
/// <seealso cref="ApiHelper"/>
/// </summary>
public partial class Article : Form
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="title">Article title</param>
    /// <param name="summary">Article contents</param>
    public Article(string title, string summary)
    {
        InitializeComponent();
        titleLabel.Text = title.Split(": ")[1];
        summaryBox.Text = summary;
        dateLabel.Text = PersistenceHelper.ArticlePublishDate;
        linkLabel.Text = "View Online";
        linkLabel.Links.Add(0, PersistenceHelper.ArticleUrl!.Length, PersistenceHelper.ArticleUrl);
    }

    /// <summary>
    /// Opens a URL in default browser when link label is clicked.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        UiHelper.OpenUrl(PersistenceHelper.ArticleUrl!);
        Dispose(true);
        Close();
    }

    /// <summary>
    /// Closes form.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void closeButton_Click(object sender, EventArgs e)
    {
        Dispose(true);
        Close();
    }
}