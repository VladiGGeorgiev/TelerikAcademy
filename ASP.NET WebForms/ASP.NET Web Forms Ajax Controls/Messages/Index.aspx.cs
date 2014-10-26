using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Messages
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            MessagesEntities context = new MessagesEntities();

            var messages =
                (from message in context.Messages
                select message).Take(10).OrderByDescending(m => m.Id).ToList();
            this.ListViewMessages.DataSource = messages;
            this.ListViewMessages.DataBind();
        }

        protected void AddMessage_Click(object sender, EventArgs e)
        {
            MessagesEntities context = new MessagesEntities();

            Message newMessage = new Message()
            {
                Text = this.NewMessage.Text
            };

            context.Messages.Add(newMessage);
            context.SaveChanges();

            this.NewMessage.Text = "";
        }
    }
}