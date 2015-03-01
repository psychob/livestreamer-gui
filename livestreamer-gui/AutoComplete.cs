using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace livestreamer_gui
{
 public partial class AutoComplete : Form
 {
  public AutoComplete()
  {
   InitializeComponent();
  }

  public UsedUrls[] usedUrls = null;

  private void AutoComplete_Load(object sender, EventArgs e)
  {
   if ( usedUrls != null )
    foreach (UsedUrls it in usedUrls)
     lbItems.Items.Add(it.url);
  }

  private void btnRemove_Click(object sender, EventArgs e)
  {
   if ( lbItems.SelectedIndex != -1 )
   {
    int index = lbItems.SelectedIndex;
    lbItems.Items.RemoveAt(index);
    var tmp = usedUrls.ToList();
    tmp.RemoveAt(index);
    usedUrls = tmp.ToArray();

    if (usedUrls.Length == 0)
     usedUrls = null;
   }
  }

  private void btnClearList_Click(object sender, EventArgs e)
  {
   usedUrls = null;
   lbItems.Items.Clear();
  }
 }
}
