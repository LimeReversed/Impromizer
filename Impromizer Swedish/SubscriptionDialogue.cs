using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Headline_Randomizer
{
    public partial class SubscriptionDialogue : Form
    {
        //[ComImport]
        //[Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
        //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        //public interface IInitializeWithWindow
        //{
        //    void Initialize(IntPtr hwnd);
        //}

        public SubscriptionDialogue()
        {
            InitializeComponent();
            Common.InsertText(rtbFull, "TextSwe\\Fullversion.rtf");
            cbStoreId.SelectedIndex = 0;
            this.Show();
        }

        private void RtbAbout_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSvenska_Click(object sender, EventArgs e)
        {
            Subscription subscription = new Subscription();
            subscription.OpenBuyNowDialogue();
            this.Close();
        }

        private void SubscriptionDialogue_Load(object sender, EventArgs e)
        {

        }

        private void CbStoreId_TextChanged(object sender, EventArgs e)
        {
            Subscription.subscriptionStoreId = cbStoreId.Text;
        }
    }
}
