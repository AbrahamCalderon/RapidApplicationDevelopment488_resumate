using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Linq;
using System.Web;
using DataLayer;

public class Utilities
{
    private Utilities() { }

    /// <summary>
    /// Returns a clean version of a string, stripped of all characters
    /// that could allow for SQL Injeciton attacks.
    /// </summary>
    /// <param name="s"></param>
    public static void ConvertIn(Page page)
    {
        foreach (Control c in EnumerateControlsRecursive(page))
        {
            if (c is TextBox)
            {
                TextBox tbx = (TextBox)c;
                tbx.Text = tbx.Text.Replace("\"", "&#34;");
                tbx.Text = tbx.Text.Replace("\'", "&#39;");
            }
        }
    }

    /// <summary>
    /// Returns a clean version of a string, stripped of all characters
    /// that could allow for SQL Injeciton attacks.
    /// </summary>
    /// <param name="s"></param>
    public static void ConvertOut(Page page)
    {
        foreach (Control c in EnumerateControlsRecursive(page))
        {
            if (c is TextBox)
            {
                TextBox tbx = (TextBox)c;
                tbx.Text = tbx.Text.Replace("&#34;", "\"");
                tbx.Text = tbx.Text.Replace("&#39;", "\'");
            }
        }
    }

    private static IEnumerable<Control> EnumerateControlsRecursive(Control parent)
    {
        foreach (Control child in parent.Controls)
        {
            yield return child;
            foreach (Control descendant in EnumerateControlsRecursive(child))
                yield return descendant;
        }
    }
}